using System;
using System.Collections.Generic;

#nullable disable

namespace SYAC_OP.model.Models
{
    public partial class Listum
    {
        public Listum()
        {
            InverseTipoListaNavigation = new HashSet<Listum>();
            OrdenPedidoEstados = new HashSet<OrdenPedido>();
            OrdenPedidoPrioridads = new HashSet<OrdenPedido>();
        }

        public int ListaId { get; set; }
        public string Nombre { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? TipoLista { get; set; }

        public virtual Listum TipoListaNavigation { get; set; }
        public virtual ICollection<Listum> InverseTipoListaNavigation { get; set; }
        public virtual ICollection<OrdenPedido> OrdenPedidoEstados { get; set; }
        public virtual ICollection<OrdenPedido> OrdenPedidoPrioridads { get; set; }
    }
}
