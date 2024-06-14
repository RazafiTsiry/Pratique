using Core.Domain;
using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IClientService
    {
        Task<Client> CreateClient(ClientDto dto);
        Task<List<Client>> GetClients();
    }
}
