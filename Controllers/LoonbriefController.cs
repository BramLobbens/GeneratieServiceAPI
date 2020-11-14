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

        [HttpGet("{id:guid}")]
        [Produces("application/xml")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_loonbriefRepository.GetAsync(id));
        }

        [HttpPost]
        [Consumes("application/xml")]
#if (DEBUG)
        //[Produces("application/xml", "application/json")]
#else
        [Produces("application/xml")]
#endif
        public async Task<IActionResult> Post(DtoModel request)
        {
            // Create loonbrief
            var loonbrief = new Loonbrief()
            {
                Id = Guid.NewGuid(),
                Name = "Foo",
                LastName = "Bar",
                City = "Bruxelles"
            };
            // Add
            _loonbriefRepository.Add(loonbrief);

            // Return HTML string
            if (string.Equals(request.Payload.GenerateDocument.OutputType, "html", StringComparison.OrdinalIgnoreCase))
            {
                //return CreatedAtAction(nameof(GetByIdAsync), new { id = loonbrief.Id }, loonbrief.GenerateHTML());
                var htmlstring = await Task.Run(() => HtmlExtensions.GenerateHTML(loonbrief));
                return CreatedAtAction(nameof(GetById), new { id = loonbrief.Id }, htmlstring);
                //return Ok(htmlstring);
            }
            // Return XML string
            else if (string.Equals(request.Payload.GenerateDocument.OutputType, "xml", StringComparison.OrdinalIgnoreCase))
            {
                var xmlstring = await Task.Run(() => XmlExtensions.Serialize(loonbrief));
                return CreatedAtAction(nameof(GetById), new { id = loonbrief.Id }, xmlstring);
            }
            // Content-Type specified result
            return CreatedAtAction(nameof(GetById), new { id = loonbrief.Id }, loonbrief);
        }
    }
}
