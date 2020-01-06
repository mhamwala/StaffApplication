using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreeAmigosOrder.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrderAsync();

        Task<IEnumerable<OrderDto>> GetOrdersAsync(int Id);

        Task<OrderDto> GetOrderDetailsAsync(int Id);

        Task<OrderDto> PostOrderAsync(OrderDto OrderDto);

        Task<OrderDto> PutOrderAsync(OrderDto OrderDto);

        Task<OrderDto> EditOrderDetailsAsync(int Id);

        Task<OrderDto> GetDeleteOrderAsync(int Id);

        Task<OrderDto> DeleteOrderAsync(int Id);
    }
}
