using Core.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/client")]
    [EnableCors("CorsPolicy")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClient() {
            return Ok(await _clientService.GetClients());
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientDto dto)
        {
            return Ok(await _clientService.CreateClient(dto));
        }
    }
}
