using System;
using System.Collections.Generic;

#nullable disable

namespace SYAC_OP.model.Models
{
    public partial class OrdenPedidoDetalle
    {
        public int OrdenPedidoDetalleId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int OrdenPedidoId { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Producto OrdenPedidoDetalle1 { get; set; }
        public virtual OrdenPedido OrdenPedidoDetalleNavigation { get; set; }
    }
}
