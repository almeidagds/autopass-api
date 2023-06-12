using AutoPassAPI.Models;
using AutoPassAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoPassAPI.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppSettingsDbContext _context;
        private readonly ICardRepository _cardRepository;

        public TransactionRepository(AppSettingsDbContext context)
        {
            _context = context;
            _cardRepository = new CardRepository(_context);
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            var transactions = await _context.Transactions.ToListAsync<Transaction>();
            return transactions;
        }

        public async Task<Transaction> Create(Transaction transaction)
        {
            var card = await _cardRepository.GetById(transaction.CardId);
            if (card.Balance + transaction.TransactionValue > card.BalanceLimit)
            {
                throw new Exception("The current balance plus the transaction value is greater than the card balance limit.");
            } else
            {
                card.Balance += transaction.TransactionValue;
                transaction.Date = DateTime.UtcNow;
                await _cardRepository.Update(card);
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
            }
            return transaction;
        }
    }
}
