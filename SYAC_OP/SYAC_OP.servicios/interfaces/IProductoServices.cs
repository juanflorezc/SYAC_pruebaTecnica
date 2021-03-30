using SYAC_OP.model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SYAC_OP.servicios
{
    public interface IProductoServices
    {
        Task<List<Producto>> getProducto();
        Task<List<string>> GetProductName();
    }
}
