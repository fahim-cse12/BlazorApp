using Blazor.BL.IService;
using Blazor.DAL.IRepository;
using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.BL.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _iorderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this._iorderRepository = orderRepository;    
        }
        public async Task<ResponseAPI<int>> CreateOrUpdateOrder(OrderDto orderDto)
        {
            var response = new ResponseAPI<int>();
            try
            {
                if (orderDto == null)
                {
                    response.IsSuccess = false; 
                    response.Value = 0;
                    response.Message = "Order data should not be null";
                    
                }
                else
                {
                    var result = await _iorderRepository.AddOrUpdateOrder(orderDto);
                    if(result > 0)
                    {
                        response.IsSuccess = true;
                        response.Value = result;
                        response.Message = "New Order has been saved";
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Value = 0;
                        response.Message = "Data not saved";
                    }
                    
                }
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.IsSuccess = false;
                response.Value = 0;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseAPI<int>> DeleteOrder(int id)
        {
            var response = new ResponseAPI<int>();
            try
            {
                var result = await _iorderRepository.DeleteOrder(id);
                if (result > 0)
                {
                    response.IsSuccess = true;
                    response.Value = result;
                    response.Message = $"Data has deleted with this id {response.Value}";

                }
                else 
                {
                    response.IsSuccess = false;
                    response.Value = 0;
                }
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.IsSuccess = false;
                response.Value = 0;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseAPI<List<OrderDto>>> GetAllOrder()
        {
            var response = new ResponseAPI<List<OrderDto>>();
            try
            {
                var resultList = await _iorderRepository.GetAllOrderList();
                if (resultList != null)
                {
                    response.IsSuccess = true;  
                    response.Value = resultList;
                }
                else
                {
                    response.IsSuccess = false; 
                    response.Value = null;  
                }
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.IsSuccess = false;
                response.Value = null;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseAPI<OrderDto>> GetOrderById(int id)
        {
            var response = new ResponseAPI<OrderDto>();
            try
            {
                var result = await _iorderRepository.GetOrderByOrderId(id);
                if (result != null)
                {
                    response.IsSuccess= true;   
                    response.Value = result;
                }
                else
                {
                    response.IsSuccess= false;  
                    response.Value = null;
                    response.Message = "Data not found";
                }

                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.IsSuccess = false;
                response.Value = null;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
