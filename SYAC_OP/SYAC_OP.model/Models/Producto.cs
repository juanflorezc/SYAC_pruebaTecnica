using System;
using System.Collections.Generic;

#nullable disable

namespace SYAC_OP.model.Models
{
    public partial class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public double ValorUnitario { get; set; }
        public bool Borrado { get; set; }
        public string CreadoPor { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual OrdenPedidoDetalle OrdenPedidoDetalle { get; set; }
    }
}
