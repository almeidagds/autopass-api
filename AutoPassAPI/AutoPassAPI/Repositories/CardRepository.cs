using AutoPassAPI.Models;
using AutoPassAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoPassAPI.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly AppSettingsDbContext _context;
        public CardRepository(AppSettingsDbContext context) {
            _context = context;
        }
        public async Task<Card> Create(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
            return card;
        }
        public async Task<Card> GetById(ulong cardId)
        {
            return await _context.Cards.FindAsync(cardId);
        }

        public async Task<IEnumerable<Card>> GetAll()
        {
            return await _context.Cards.ToListAsync<Card>();
        }

        public async Task<IEnumerable<Card>> GetByClientId(ulong clientId)
        {
            return await _context.Cards.Where<Card>(card => card.ClientId == clientId).ToListAsync<Card>();
        }

        public async Task<IEnumerable<Card>> GetByCardNumber(string cardNumber)
        {
            return await _context.Cards.Where<Card>(card => card.CardNumber == cardNumber).ToListAsync<Card>();
        }

        public async Task<Card> Update(Card card)
        {
            _context.Entry(card).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task Delete(ulong cardId)
        {
            Card cardToDelete = await _context.Cards.FindAsync(cardId);
            if (cardToDelete != null)
            {
                _context.Cards.Remove(cardToDelete);
                _context.SaveChanges();
            }
        }
    }
}
