using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [Consumes("application/xml")]
        #if (DEBUG)
        [Produces("application/json", "text/html")]
        #else
        [Produces("application/xml", "text/html")]
        #endif
        public IActionResult Post([FromBody]DtoModel request)
        {
            var loonbrief = new Loonbrief()
            {
                // Initialize object with parameters
            };

            // HTML result
            if (string.Equals(request.Payload.GenerateDocument.OutputType, "html", StringComparison.OrdinalIgnoreCase))
            {
                return Ok(loonbrief.GenerateHTML());
            }

            // Content-Type specified result
            return Ok(loonbrief);
        }
    }
}
