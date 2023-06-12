using AutoPassAPI.Models;
using System.Collections;

namespace AutoPassAPI.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> Create(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAll();
    }
}
