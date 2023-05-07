using Blazor.Shared.Models;

namespace Blazor.UI.IService
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllOrderList();
        Task<OrderDto> GetOrderById(int id);
        Task<int> CreateOrUpdateOrder(OrderDto orderdto);
        Task<int> DeleteOrder(int id);
    }
}
