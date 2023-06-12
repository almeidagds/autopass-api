using AutoPassAPI.Models;
using AutoPassAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoPassAPI.Controllers
{
    [Route("api/client/")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpPut("create")]
        public async Task<ActionResult<Client>> Create(Client client)
        {
            try
            {
                Client createdClient = await _clientRepository.Create(client);
                return Ok(createdClient);
            }
            catch (Exception exception)
            {
                return BadRequest($"It wasn't possible to create the client. Error: {exception.Message}");
            }
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            try
            {
                IEnumerable<Client> clients = await _clientRepository.GetAll();
                return Ok(clients.ToList());
            }
            catch (Exception exception)
            {
                return BadRequest($"It wasn't possible to get the clients. Error:" + exception.Message);
            }
        }

        [HttpGet("get/{clientId}")]
        public async Task<ActionResult<IEnumerable<Client>>> GetById(ulong clientId)
        {
            try
            {
                Client client = await _clientRepository.GetById(clientId);
                return Ok(client);
            }
            catch (Exception exception)
            {
                return BadRequest($"It wasn't possible to get the clients. Error:" + exception.Message);
            }
        }

        [HttpPost("udpate")]
        public async Task<ActionResult<Client>> Update(Client client)
        {
            try
            {
                Client updatedClient = await _clientRepository.Update(client);
                return Ok(updatedClient);
            }
            catch (Exception exception)
            {
                return BadRequest($"It wasn't possible to update the client. Error:" + exception.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(ulong clientId)
        {
            try
            {
                await _clientRepository.Delete(clientId);
                return Ok();
            } catch (Exception exception)
            {
                return BadRequest($"It wasn't possible to delete the client. Error:" + exception.Message);
            }
        }
    }
}
