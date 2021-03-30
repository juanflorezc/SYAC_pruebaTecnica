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
    public class ClienteController : ControllerBase
    {
        public readonly IClienteServices clienteServices;
        private readonly ILogger _logger;
        public ClienteController(IClienteServices prmClienteServices, ILogger<ClienteController> logger,
            IOptions<AppSettings> settings)
        {
            clienteServices = prmClienteServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Cliente>> GetClient()
        {
            return await clienteServices.getClients();
        }

    }
}
