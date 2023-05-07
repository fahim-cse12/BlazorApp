using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.DAL.IRepository
{
    public interface IOrderRepository
    {
        public Task<List<OrderDto>> GetAllOrderList();
        public Task<int> AddOrUpdateOrder(OrderDto orderDto);
        public Task<OrderDto> GetOrderByOrderId(int id);
        public Task<int> DeleteOrder(int id);
    }
}
