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

        public Task<List<OrdenPedido>> CreatePedido(OrdenPedido prmOrdenPedido)
        {
            prmOrdenPedido.EstadoId = 3;
            prmOrdenPedido.FechaCreacion = DateTime.Now;
            prmOrdenPedido.CreadoPor = "admin";
            _context.OrdenPedidos.Add(prmOrdenPedido);
            _context.SaveChanges();
            return this.getOrdenes();
        }

        public async Task<List<OrdenPedido>> getOrdenes()
        {
            var ordenpedidoslist= _context.OrdenPedidos.Include(x=>x.OrdenPedidoDetalles).ThenInclude(x=>x.Producto).
                Include(x=>x.Cliente).Include(x=>x.Estado).ToList();
            foreach (var ordenpedido in ordenpedidoslist)
            {
                ordenpedido.Cliente.OrdenPedidos = null;
                ordenpedido.Estado.OrdenPedidoEstados = null;
                ordenpedido.Estado.OrdenPedidoPrioridads = null;
                foreach (var detalles in ordenpedido.OrdenPedidoDetalles)
                {
                    detalles.OrdenPedido = null;//eliminar redundancia
                    detalles.Producto.OrdenPedidoDetalles = null;
                }
            }
            return ordenpedidoslist;
        }

        public Task<List<OrdenPedido>> setOrdenes(OrdenPedido prmOrdenPedido)
        {
            var orden = _context.OrdenPedidos.Find(prmOrdenPedido.OrdenPedidoId);
            orden.EstadoId = prmOrdenPedido.EstadoId;
            _context.OrdenPedidos.Update(orden);
            _context.SaveChanges();
            return this.getOrdenes();
        }
    }
}
