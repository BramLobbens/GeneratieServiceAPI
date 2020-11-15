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

        // GET api/loonbrief
        [HttpGet]
        [Produces("application/xml")]
        public IActionResult Get()
        {
            return Ok(_loonbriefRepository.Get());
        }

        // GET api/loonbrief/{id}
        [HttpGet("{id:guid}")]
        [Produces("application/xml")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_loonbriefRepository.Get(id));
        }

        // GET api/loonbrief/html/{id}
        [HttpGet("html/{id:guid}")]
        public ContentResult GetByIdHtml(Guid id)
        {
            return HtmlExtensions.GenerateHTML(_loonbriefRepository.Get(id));
        }

        // POST api/loonbrief
        [HttpPost]
        [Consumes("application/xml")]
        public async Task<IActionResult> Post(DtoModel request)
        {
            try
            {
                // Create loonbrief object
                var loonbrief = new Loonbrief()
                {
                    Id = Guid.NewGuid(),
                    DateRegister = DateTime.Now,

                    Name = request.Payload.GenerateDocument.Parameters.Name,
                    LastName = request.Payload.GenerateDocument.Parameters.LastName,
                    Registerkey = request.Payload.GenerateDocument.Parameters.Registerkey,
                    Street = request.Payload.GenerateDocument.Parameters.Street,
                    Number = request.Payload.GenerateDocument.Parameters.Number,
                    PostalCode = request.Payload.GenerateDocument.Parameters.PostalCode,
                    City = request.Payload.GenerateDocument.Parameters.City,
                    Status = request.Payload.GenerateDocument.Parameters.Status,
                    Dependents = request.Payload.GenerateDocument.Parameters.Dependents
                };
                // Add
                _loonbriefRepository.Add(loonbrief);

                // Return HTML string
                if (string.Equals(request.Payload.GenerateDocument.OutputType, "html", StringComparison.OrdinalIgnoreCase))
                {
                    ContentResult html = await Task.Run(() => HtmlExtensions.GenerateHTML(loonbrief))
                    .ConfigureAwait(false);

                    return CreatedAtAction(nameof(GetById), new { id = loonbrief.Id }, html);
                }

                // Return XML string
                else if (string.Equals(request.Payload.GenerateDocument.OutputType, "xml", StringComparison.OrdinalIgnoreCase))
                {
                    ContentResult xml = await Task.Run(() => XmlExtensions.Serialize(loonbrief))
                    .ConfigureAwait(false);

                    return CreatedAtAction(nameof(GetById), new { id = loonbrief.Id }, xml);
                }

                // Content-Type specified result
                return CreatedAtAction(nameof(GetById), new { id = loonbrief.Id }, loonbrief);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
