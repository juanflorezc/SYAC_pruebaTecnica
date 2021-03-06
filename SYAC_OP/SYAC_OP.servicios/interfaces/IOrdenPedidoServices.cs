using SYAC_OP.model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SYAC_OP.servicios
{
    public interface IOrdenPedidoServices
    {
        Task<List<OrdenPedido>> getOrdenes();
        Task<List<OrdenPedido>> setOrdenes(OrdenPedido prmOrdenPedido);
        Task<List<OrdenPedido>> CreatePedido(OrdenPedido prmOrdenPedido);
    }
}
