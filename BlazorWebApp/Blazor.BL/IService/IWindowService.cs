using Blazor.Shared.Models;

namespace Blazor.BL.IService
{
    public interface IWindowService
    {
        public Task<ResponseAPI<List<WindowDto>>> GetAllWindow();
        public Task<ResponseAPI<int>> CreateOrUpdateWindow(WindowDto windowDto);
        public Task<ResponseAPI<WindowDto>> GetWindowById(int id);
        public Task<ResponseAPI<int>> DeleteWindow(int id);
    }
}
