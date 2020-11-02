using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GeneratieServiceAPI.Models;
using GeneratieServiceAPI.Repositories;

namespace GeneratieServiceAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_orderRepository.Get());
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_orderRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Post(Order request)
        {
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                ItemsIds = request.ItemsIds
            };

            _orderRepository.Add(order);

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid id, Order request)
        {
            var order = new Order
            {
                Id = id,
                ItemsIds = request.ItemsIds
            };

            _orderRepository.Update(id, order);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _orderRepository.Delete(id);

            return Ok();
        }
    }
}