using System;
using System.Collections.Generic;
using System.Linq;
using GeneratieServiceAPI.Models;

namespace GeneratieServiceAPI.Repositories
{
    public class MemoryOrderRepository : IOrderRepository
    {
        private IList<Order> _orders { get; set; }

        public MemoryOrderRepository()
        {
            _orders = new List<Order>();
        }

        public IEnumerable<Order> Get() => _orders;

        public Order Get(Guid orderId)
        {
            return _orders.FirstOrDefault(o => o.Id == orderId);
        }

        public void Add(Order order)
        {
            _orders.Add(order);
        }

         public void Update(Guid orderId, Order order)
        {
            var result = _orders.FirstOrDefault(o => o.Id == orderId);
            if (result != null) result.ItemsIds = order.ItemsIds;
        }

        public Order Delete(Guid orderId)
        {
            var target = _orders.FirstOrDefault(o => o.Id == orderId);
            _orders.Remove(target);

            return target;
        }
    }
}