using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneratieServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeneratieServiceAPI.Controllers
{
    [ApiController]
    [Route("api/loonbrief")]
    public class LoonbriefController : ControllerBase
    {

        public LoonbriefController()
        {}
        
        [HttpGet]
        [Produces("application/xml")]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody]DtoModel request)
        {
            
            return Ok();
        }
    }
}
