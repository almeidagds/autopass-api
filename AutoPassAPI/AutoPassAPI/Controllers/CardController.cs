using AutoPassAPI.Models;
using AutoPassAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoPassAPI.Controllers
{
    [Route("api/card/")]
    [ApiController]
    public class CardController : Controller
    {
        private readonly ICardRepository _cardRepository;
        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpPut("create")]
        public async Task<ActionResult<Card>> Create(Card card)
        {
            try
            {
                var createdCard = await _cardRepository.Create(card);
                return Ok(createdCard);
            }
            catch (Exception exception)
            {
                return BadRequest($"It wasn't possible to create the card. Error: {exception.Message}");
            }
        }

        [HttpGet("get/{cardId}")]
        public async Task<ActionResult<Card>> GetById(ulong cardId)
        {
            try
            {
                var card = await _cardRepository.GetById(cardId);
                return Ok(card);
            }
            catch (Exception exception)
            {
                return BadRequest($"It wasn't possible to get the specified card. Error: {exception.Message}");
            }
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<Card>>> GetAll()
        {
            try
            {
                var cards = await _cardRepository.GetAll();
                return Ok(cards);
            } catch (Exception exception)
            {
                return BadRequest($"It wasn't possible to get all the cards. Error: {exception.Message}");
            }
        }

        [HttpGet("getByClientId/{clientId}")]
        public async Task<ActionResult<IEnumerable<Card>>> GetByClientId(ulong clientId)
        {
            try
            {
                var cards = await _cardRepository.GetByClientId(clientId);
                return Ok(cards);
            }
            catch (Exception exception)
            {
                return BadRequest($"It wasn't possible to get the specified client's cards. Error: {exception.Message}");
            }
        }

        [HttpGet("getByCardNumber/{cardNumber}")]
        public async Task<ActionResult<IEnumerable<Card>>> GetByCardNumber(string cardNumber)
        {
            try
            {
                var cards = await _cardRepository.GetByCardNumber(cardNumber);
                return Ok(cards);
            }
            catch (Exception exception)
            {
                return BadRequest($"It wasn't possible to get the cards. Error: {exception.Message}");
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<Card>> Update(Card card)
        {
            try
            {
                var updatedCard = await _cardRepository.Update(card);
                return Ok(updatedCard);
            }
            catch (Exception exception)
            {
                return BadRequest($"It wasn't possible to update the card. Error: {exception.Message}");
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Card>> Delete(ulong cardId)
        {
            try
            {
                await _cardRepository.Delete(cardId);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest($"It wasn't possible to delete the card. Error: {exception.Message}");
            }
        }
    }
}
