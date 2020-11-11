using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using GeneratieServiceAPI.Models;
using GeneratieServiceAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeneratieServiceAPI.Controllers
{
    [ApiController]
    [Route("api/loonbrief")]
    public class LoonbriefController : ControllerBase
    {

        private readonly ILoonbriefRepository _loonbriefRepository;
        public LoonbriefController(ILoonbriefRepository loonbriefRepository)
        {
            _loonbriefRepository = loonbriefRepository;
        }

        [HttpGet]
        [Produces("application/xml")]
        public IActionResult Get()
        {
            return Ok(_loonbriefRepository.Get());
        }

        [HttpGet("{id:guid}")]
        [Produces("application/xml")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_loonbriefRepository.Get(id));
        }

        [HttpPost]
        [Consumes("application/xml")]
        #if (DEBUG)
        [Produces("application/json", "text/html")]
        #else
        [Produces("application/xml", "text/html")]
        #endif
        public IActionResult Post(DtoModel request)
        {
            // Test
            var loonbrief = new Loonbrief() 
            {
                Id = Guid.NewGuid(),
                Name = "Foo",
                LastName = "Bar"
            };

            _loonbriefRepository.Add(loonbrief);

            // HTML result
            if (string.Equals(request.Payload.GenerateDocument.OutputType, "html", StringComparison.OrdinalIgnoreCase))
            {
                return CreatedAtAction(nameof(GetById), new { id = loonbrief.Id }, loonbrief.GenerateHTML());
            }

            // Content-Type specified result
            return CreatedAtAction(nameof(GetById), new { id = loonbrief.Id }, loonbrief);
        }
    }
}
