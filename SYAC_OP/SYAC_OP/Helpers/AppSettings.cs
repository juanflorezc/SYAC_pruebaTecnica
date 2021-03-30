using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYAC_OP.API.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public string petsIssuerJwt { get; set; }

        public string petsAudienceJwt { get; set; }

    }
}
