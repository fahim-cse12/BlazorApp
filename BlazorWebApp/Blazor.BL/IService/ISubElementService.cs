using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.BL.IService
{
    public interface ISubElementService
    {
        public Task<ResponseAPI<List<SubElementDto>>> GetAllElement();
        public Task<ResponseAPI<int>> CreateOrUpdateElement(SubElementDto orderDto);
        public Task<ResponseAPI<SubElementDto>> GetElementById(int id);
        public Task<ResponseAPI<int>> DeleteSubElement(int id);
    }
}
