using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace GeneratieServiceAPI
{
    public class SampleMiddleware
    {
        private readonly RequestDelegate _next;

        public SampleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // public async Task InvokeAsync(HttpContext context, IPaymentService paymentService)
        // {
        //     // Call the next delegate/middleware in the pipeline
        //     Console.WriteLine(paymentService.GetMessage());
        //     await _next(context);
        // }

        public async Task InvokeAsync(HttpContext context)
        {
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}