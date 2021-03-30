using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SYAC_OP.API.Helpers;
using SYAC_OP.model.Models;
using SYAC_OP.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYAC_OP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        public readonly IProductoServices ProductoServices;
        private readonly ILogger _logger;
        public ProductoController(IProductoServices prmProductoServices, ILogger<ProductoController> logger,
            IOptions<AppSettings> settings)
        {
            ProductoServices = prmProductoServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Producto>> GetClient()
        {
            return await ProductoServices.getProducto();
        }

        [HttpGet]
        [Route("geName")]
        public async Task<List<string>> GetClientName()
        {
            return await ProductoServices.GetProductName();
        }

    }
}
