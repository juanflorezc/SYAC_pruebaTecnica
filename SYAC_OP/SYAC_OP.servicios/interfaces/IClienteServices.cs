using SYAC_OP.model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SYAC_OP.servicios
{
    public interface IClienteServices
    {
        Task<List<Cliente>> getClients();
        Task<List<string>> GetClientName();
    }
}
