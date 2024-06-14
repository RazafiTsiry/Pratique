using Core.Domain;
using Core.Dto;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClientService : IClientService
    {
        private readonly DataContext _dataContext;

        public ClientService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Client> CreateClient(ClientDto dto)
        {
            Client client = new Client
            {
                Nom=dto.Nom,
                Telephone=dto.Telephone,
                Lieu=dto.Lieu
            };
            await _dataContext.Clients.AddAsync(client);
            await _dataContext.SaveChangesAsync();
            return client;
        }

        public async Task<List<Client>> GetClients()
        {
            List<Client> clients=await _dataContext.Clients.ToListAsync();
            return clients;
        }
    }
}
