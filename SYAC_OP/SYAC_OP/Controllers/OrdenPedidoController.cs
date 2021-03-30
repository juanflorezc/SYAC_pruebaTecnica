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
    public class OrdenPedidoController : ControllerBase
    {
        public readonly IOrdenPedidoServices OrdenPedidoServices;
        private readonly ILogger _logger;
        public OrdenPedidoController(IOrdenPedidoServices prmOrdenPedidoServices, ILogger<OrdenPedidoController> logger,
            IOptions<AppSettings> settings)
        {
            OrdenPedidoServices = prmOrdenPedidoServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<OrdenPedido>> GetClient()
        {
            return await OrdenPedidoServices.getOrdenes();
        }
        

    }
}
