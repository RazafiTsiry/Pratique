using Core.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/client")]
    [EnableCors("CorsPolicy")]

    // code : 200
    // message : object , message d erreur
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClient() {
            return Result(await _clientService.GetClients());
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientDto dto)
        {
            return Result(await _clientService.CreateClient(dto));
        }
    }
}
