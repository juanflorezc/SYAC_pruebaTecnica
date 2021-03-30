using System;
using System.Collections.Generic;

#nullable disable

namespace SYAC_OP.model.Models
{
    public partial class OrdenPedido
    {
        public int OrdenPedidoId { get; set; }
        public int ClienteId { get; set; }
        public int EstadoId { get; set; }
        public string DireccionEntrega { get; set; }
        public int PrioridadId { get; set; }
        public double ValorTotal { get; set; }
        public bool Borrado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Listum Estado { get; set; }
        public virtual Listum Prioridad { get; set; }
        public virtual OrdenPedidoDetalle OrdenPedidoDetalle { get; set; }
    }
}
