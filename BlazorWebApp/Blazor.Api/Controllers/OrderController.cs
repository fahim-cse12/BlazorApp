using Blazor.BL.IService;
using Blazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;   
        public OrderController(IOrderService service)
        {
            _orderService = service;
        }
        // GET: api/<Order>
        [HttpGet]
        [Route("getAllOrder")]
        public async Task<IActionResult> GetAllOrder()
        {
            var response = await _orderService.GetAllOrder();

            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        // GET api/<Order>/5
        [HttpGet]
        [Route("getbyId/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var result = await _orderService.GetOrderById(id);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);  
            }
        }

        // POST api/<Order>
        [HttpPost]
        [Route("createOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate(OrderDto orderDto)
        {
            var result = await _orderService.CreateOrUpdateOrder(orderDto);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            else 
            { 
                return BadRequest(result.Message); 
            }
        }

        [HttpDelete]
        [Route("deleteOrder/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
