using Blazor.Shared.Models;

namespace Blazor.UI.IService
{
    public interface ISubElementService
    {
        Task<List<SubElementDto>> GetAllElementList();
        Task<SubElementDto> GetElementById(int id);
        Task<int> CreateOrUpdateElement(SubElementDto orderdto);
        Task<int> DeleteElement(int id);
    }
}
