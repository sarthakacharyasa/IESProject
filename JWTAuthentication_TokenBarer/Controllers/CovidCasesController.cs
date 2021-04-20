using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace JWTAuthentication_TokenBarer.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]
    public class CovidCasesController : ControllerBase
    {
        
        private readonly ILogger<CovidCasesController> _logger;

        private readonly List<CovidCases> covid = new List<CovidCases>()
        {
            new CovidCases { Rank = 5, Country = "Italy", ActiveCases= 15426623, Deaths= 152244 },
           new CovidCases { Rank = 3, Country = "UK", ActiveCases= 26426624, Deaths= 262234 },
           new CovidCases { Rank = 1, Country = "USA", ActiveCases= 48622159, Deaths= 564452 },
           new CovidCases { Rank = 2, Country = "India", ActiveCases= 3266003, Deaths= 312585 },
           new CovidCases { Rank = 4, Country = "Brazil", ActiveCases= 28426623, Deaths= 86524 },
        };

        public CovidCasesController(ILogger<CovidCasesController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<CovidCases> Get()
        {
            return covid;
          
            }
             [HttpGet("{rank:int}")]
        public CovidCases GetOne(int rank)
        {
            return covid.SingleOrDefault(x => x.Rank == rank );
        }
    }
    }

