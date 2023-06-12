using AutoPassAPI.Models;

namespace AutoPassAPI.Repositories.Interfaces
{
    public interface ICardRepository
    {
        Task<Card> Create(Card card);
        Task<Card> GetById(ulong cardId);
        Task<IEnumerable<Card>> GetAll();
        Task<IEnumerable<Card>> GetByCardNumber(string cardNumber);
        Task<IEnumerable<Card>> GetByClientId(ulong clientId);
        Task<Card> Update(Card card);
        Task Delete(ulong cardId);
    }
}
