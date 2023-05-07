using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.BL.IService
{
    public interface IOrderService
    {
        public Task<ResponseAPI<List<OrderDto>>> GetAllOrder();
        public Task<ResponseAPI<int>> CreateOrUpdateOrder(OrderDto orderDto);
        public Task<ResponseAPI<OrderDto>> GetOrderById(int id);
        public Task<ResponseAPI<int>> DeleteOrder(int id);
    }
}
