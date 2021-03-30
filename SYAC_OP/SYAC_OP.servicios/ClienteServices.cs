using SYAC_OP.model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYAC_OP.servicios
{
    public class ClienteServices : IClienteServices
    {
        private readonly syac_opContext _context;

        public ClienteServices(syac_opContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> getClients()
        {
            return _context.Clientes.ToList();
        }
    }
}
