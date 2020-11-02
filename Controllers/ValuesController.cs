using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GeneratieServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        // private IPaymentService paymentService { get; set; }

        // public ValuesController(IPaymentService paymentService)
        // {
        //     this.paymentService = paymentService;
        // }

        // public string Get()
        // {
        //     //return string.Empty;
        //     return paymentService.GetMessage();
        // }

        [HttpGet]
        public ActionResult<string> Get([FromServices] IPaymentService paymentService)
        {
            return paymentService.GetMessage();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}