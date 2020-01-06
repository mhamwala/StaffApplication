using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeAmigosOrder.Services
{
    public class FakeOrderService : IOrderService
    {
        public List<OrderDto> _order = new List<OrderDto>
        {
            new OrderDto { Id = 1, CustomerID = 22, ProductID = 3, Quantity = 5, ShippingAddress = "4 drive close", Total = 34 },
            new OrderDto { Id = 12, CustomerID = 254, ProductID = 4, Quantity = 15, ShippingAddress = "4 drive close", Total = 344 },
            new OrderDto { Id = 13, CustomerID = 225, ProductID = 5, Quantity = 3, ShippingAddress = "4 drive close", Total = 234 },
            new OrderDto { Id = 14, CustomerID = 22, ProductID = 32, Quantity = 2, ShippingAddress = "4 drive close", Total = 324 }
        };

        public Task<IEnumerable<OrderDto>> GetOrderAsync()
        {
            return Task.FromResult(_order.AsEnumerable());
        }

        Task<OrderDto> IOrderService.GetOrderDetailsAsync(int Id)
        {
            var order = _order.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(order);
        }

        Task<OrderDto> IOrderService.PostOrderAsync(OrderDto order)
        {
            _order.Add(order);
            return Task.FromResult(order);
        }

        Task<OrderDto> IOrderService.PutOrderAsync(OrderDto order)
        {
            _order.Add(order);
            return Task.FromResult(order);
        }

        Task<OrderDto> IOrderService.EditOrderDetailsAsync(int Id)
        {
            var order = _order.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(order);
        }

        public Task<OrderDto> GetDeleteOrderAsync(int Id)
        {
            var order = _order.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(order);
        }

        public Task<IEnumerable<OrderDto>> GetOrdersAsync(int Id)
        {
            return Task.FromResult(_order.AsEnumerable());
        }

        public Task<OrderDto> DeleteOrderAsync(int Id)
        {
            var order = _order.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(order);
        }
    }
}
