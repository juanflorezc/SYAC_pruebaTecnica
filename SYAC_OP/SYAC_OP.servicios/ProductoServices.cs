using SYAC_OP.model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYAC_OP.servicios
{
    public class ProductoServices : IProductoServices
    {
        private readonly syac_opContext _context;

        public ProductoServices(syac_opContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetProductName()
        {
            return _context.Clientes.Select(x => x.Nombres).ToList();
        }

        public async Task<List<Producto>> getProducto()
        {
            return _context.Productos.ToList();
        }
    }
}
