using Blazor.Shared.Models;

namespace Blazor.UI.IService
{
    public interface IWindowService
    {
        Task<List<WindowDto>> GetAllWindowList();
        Task<WindowDto> GetWindowById(int id);
        Task<int> CreateOrUpdateWindow(WindowDto windowdto);
        Task<int> DeleteWindow(int id);
    }
}
