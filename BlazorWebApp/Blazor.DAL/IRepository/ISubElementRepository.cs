using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.DAL.IRepository
{
    public interface ISubElementRepository
    {
        public Task<List<SubElementDto>> GetAllElementList();
        public Task<int> AddOrUpdateElement(SubElementDto subElementDto);
        public Task<SubElementDto> GetElementById(int id);
        public Task<int> DeleteElement(int id);
    }
}
