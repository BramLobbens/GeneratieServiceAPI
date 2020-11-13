using System;
using System.Threading.Tasks;
using GeneratieServiceAPI.Extensions;
using GeneratieServiceAPI.Models;
using GeneratieServiceAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _loonbriefRepository.GetAsync());
        }

        [HttpGet("{id:guid}")]
        [Produces("application/xml")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _loonbriefRepository.GetAsync(id));
        }

        [HttpPost]
        [Consumes("application/xml")]
#if (DEBUG)
        //[Produces("application/xml")]
#else
        [Produces("application/xml")]
#endif
        public async Task<IActionResult> Post(DtoModel request)
        {
            // Test
            var loonbrief = new Loonbrief()
            {
                Id = Guid.NewGuid(),
                Name = "Foo",
                LastName = "Bar"
            };
            _loonbriefRepository.Add(loonbrief);

            var xmlstring = await Task.Run(() => XmlExtensions.Serialize(loonbrief));

            // HTML result
            if (string.Equals(request.Payload.GenerateDocument.OutputType, "html", StringComparison.OrdinalIgnoreCase))
            {
                //return CreatedAtAction(nameof(GetByIdAsync), new { id = loonbrief.Id }, loonbrief.GenerateHTML());
                return Ok(HtmlExtensions.GenerateHTML(loonbrief));
            }

            // Content-Type specified result
            //return CreatedAtAction(nameof(GetById), new { id = loonbrief.Id }, loonbrief);
            return Ok(xmlstring);
            //return Ok(loonbrief);
        }
    }
}
