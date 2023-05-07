using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.DAL.IRepository
{
    public interface IWindowRepository
    {
        public Task<List<WindowDto>> GetAllWindowList();
        public Task<int> AddOrUpdateWindow(WindowDto windowDto);
        public Task<WindowDto> GetWindowById(int id);
        public Task<int> DeleteWindow(int id);
    }
}
