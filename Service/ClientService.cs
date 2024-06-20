using Core.Domain;
using Core.Dto;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClientService : BaseService,IClientService
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<ClientService> _logger;    

        public ClientService(DataContext dataContext,ILogger<ClientService> logger):base(logger)
        {
            _dataContext = dataContext;
            _logger = logger;    
        }

        public Task<ApiReponse> CreateClient(ClientDto dto)
        {
            // cas generaliser 
            return ExecuteSafeAsync(async () =>
            {
                Client client = new Client
                {
                    Nom = dto.Nom,
                    Telephone = dto.Telephone,
                    Lieu = dto.Lieu
                };
                await _dataContext.Clients.AddAsync(client);
                await _dataContext.SaveChangesAsync();
                return ApiReponse.Ok(client);
            },"Failed create client");
        }

        public async Task<ApiReponse> GetClients()
        {
            // un par un
            try
            {
                List<Client> clients = await _dataContext.Clients.ToListAsync();
                return ApiReponse.Ok(clients);

            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.StackTrace);
                return ApiReponse.Error(ex.Message);
            }
            return ApiReponse.Ok(null);
        }
    }
}
