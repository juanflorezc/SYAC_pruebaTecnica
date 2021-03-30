using System;
using System.Collections.Generic;

#nullable disable

namespace SYAC_OP.model.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            OrdenPedidos = new HashSet<OrdenPedido>();
        }

        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public bool Borrado { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<OrdenPedido> OrdenPedidos { get; set; }
    }
}
