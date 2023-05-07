using Blazor.BL.IService;
using Blazor.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementController : ControllerBase
    {
        private readonly ISubElementService _elementService;
        public ElementController(ISubElementService service)
        {
            _elementService = service;
        }
        // GET: api/<Order>
        [HttpGet]
        [Route("getallelement")]
        public async Task<IActionResult> GetAllElement()
        {
            var response = await _elementService.GetAllElement();

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
        public async Task<IActionResult> GetElementById(int id)
        {
            var result = await _elementService.GetElementById(id);
            if (result.IsSuccess)
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
        public async Task<IActionResult> CreateOrUpdate(SubElementDto elementDto)
        {
            var result = await _elementService.CreateOrUpdateElement(elementDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _elementService.DeleteSubElement(id);
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
