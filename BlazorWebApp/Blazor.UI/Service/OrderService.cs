using Blazor.Shared.Models;
using Blazor.UI.IService;
using System.Net.Http.Json;

namespace Blazor.UI.Service
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        public OrderService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }

        public async Task<int> CreateOrUpdateOrder(OrderDto orderdto)
        {
            var result = await _httpClient.PostAsJsonAsync("api/order/createOrUpdate",orderdto);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response.IsSuccess)
            {
                return response.Value;
            }
            else
                throw new Exception(response.Message);

        }

        public async Task<int> DeleteOrder(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/order/deleteOrder/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();    
            if (response.IsSuccess)
            {
                return response.Value;
            }
            else
                throw new Exception(response.Message);
        }

        public async Task<List<OrderDto>> GetAllOrderList()
        {
            var response = new ResponseAPI<List<OrderDto>>();
            var orderDtos = await _httpClient.GetFromJsonAsync<List<OrderDto>>("api/order/getAllOrder");
            if(orderDtos != null)
            {
                response = new ResponseAPI<List<OrderDto>>
                {
                    Value = orderDtos
                };
                return response.Value;
            }          
            else
                throw new Exception(response.Message);
        }

        public async Task<OrderDto> GetOrderById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<OrderDto>>($"api/order/getbyId/{id}");
            if (result.IsSuccess)
                return result.Value;
            else
                throw new Exception(result.Message);
        }
    }
}
