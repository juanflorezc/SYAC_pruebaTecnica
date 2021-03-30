using Microsoft.EntityFrameworkCore;
using SYAC_OP.model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYAC_OP.servicios
{
    public class OrdenPedidoServices : IOrdenPedidoServices
    {
        private readonly syac_opContext _context;

        public OrdenPedidoServices(syac_opContext context)
        {
            _context = context;
        }

       

        public async Task<List<OrdenPedido>> getOrdenes()
        {
            var ordenpedidoslist= _context.OrdenPedidos.Include(x=>x.OrdenPedidoDetalles).ThenInclude(x=>x.Producto).Include(x=>x.Cliente).ToList();
            foreach (var ordenpedido in ordenpedidoslist)
            {
                foreach (var detalles in ordenpedido.OrdenPedidoDetalles)
                {
                    detalles.OrdenPedido = null;//eliminar redundancia
                }
            }
            return ordenpedidoslist;
        }
    }
}
