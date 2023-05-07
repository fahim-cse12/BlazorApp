using Blazor.DAL.Enitities;
using Blazor.DAL.IRepository;
using Blazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        
        private readonly BlazorDbContext _dbContext;

        public OrderRepository(BlazorDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        public async Task<int> AddOrUpdateOrder(OrderDto orderDto)
        {
            int orderId = 0;
            orderId = orderDto.Id;
            if (orderDto.Id == 0)
            {
                Order order = new Order
                {
                    Id = orderDto.Id,
                    Name = orderDto.Name,  
                    State = orderDto.State    
                };
                await _dbContext.Orders.AddAsync(order);
                await _dbContext.SaveChangesAsync();

                orderId = order.Id;
            }
            else
            {
                Order order = new Order
                {
                    Id = orderDto.Id,
                    Name = orderDto.Name,
                    State = orderDto.State
                };
                _dbContext.Orders.Update(order);
                await _dbContext.SaveChangesAsync();
            }
            
            
            return orderId;
        }

        public async Task<int> DeleteOrder(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id);

            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
                return id;
            }
            else
            {
                return 0;
            }
        
        }

        public async Task<List<OrderDto>> GetAllOrderList()
        {
            var orders = await _dbContext.Orders.ToListAsync();
            if(orders.Count > 0)
            {
                List<OrderDto> ordersList = new List<OrderDto>();
                foreach (var item in orders)
                {
                    OrderDto order = new OrderDto
                    {
                        Id = item.Id,   
                        Name = item.Name,   
                        State = item.State  
                    };
                    ordersList.Add(order);  
                }

                return ordersList;
            }
            else
            {
                return null;
            }
           
           
        }

        public async Task<OrderDto> GetOrderByOrderId(int id)
        {
            var singleOrder = await _dbContext.Orders.FirstOrDefaultAsync(i => i.Id == id);
            if (singleOrder != null)
            {
                OrderDto order = new OrderDto
                {
                    Id = singleOrder.Id,
                    Name = singleOrder.Name,
                    State = singleOrder.State
                };
                return order;
            }
            else
            {
                return null;
            }
        }
    }
}
