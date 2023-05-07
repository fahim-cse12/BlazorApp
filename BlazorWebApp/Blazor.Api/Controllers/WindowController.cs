using Blazor.BL.IService;
using Blazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly IWindowService _windowService;
        public WindowController(IWindowService service)
        {
            _windowService = service;
        }
        // GET: api/<WindowController>
        
        [HttpGet]
        [Route("getallwindow")]
        public async Task<IActionResult> GetAllWindow()
        {
            var response = await _windowService.GetAllWindow();

            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        // GET api/<WindowController>/5
        
        [HttpGet]
        [Route("getbyId/{id}")]
        public async Task<IActionResult> GetWindowById(int id)
        {
            var result = await _windowService.GetWindowById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }


        // POST api/<WindowController>
        
        [HttpPost]
        [Route("createorupdate")]
        public async Task<IActionResult> CreateOrUpdate(WindowDto windowDto)
        {
            var result = await _windowService.CreateOrUpdateWindow(windowDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }    

        // DELETE api/<WindowController>/5
       
        [HttpDelete]
        [Route("deletewindow/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _windowService.DeleteWindow(id);
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
