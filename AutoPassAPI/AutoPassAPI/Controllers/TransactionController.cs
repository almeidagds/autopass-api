using AutoPassAPI.Models;
using AutoPassAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoPassAPI.Controllers
{
    [Route("api/transaction/")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpPut("create")]
        public async Task<ActionResult<Transaction>> Create(Transaction transaction)
        {
            try
            {
                var createdTransaction = await _transactionRepository.Create(transaction);
                return Ok(transaction);
            }
            catch (Exception exception)
            {
                return BadRequest($"It wasn't possible to create the transaction. Error: {exception.Message}");
            }
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetAll()
        {
            try
            {
                var transactions = await _transactionRepository.GetAll();
                return Ok(transactions);
            } catch(Exception exception)
            {
                return BadRequest($"It wasn't possible to get all transactions. Error: {exception.Message}");
            }
        }
    }
}
