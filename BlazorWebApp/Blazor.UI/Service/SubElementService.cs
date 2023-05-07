using Blazor.Shared.Models;
using Blazor.UI.IService;
using System.Net.Http.Json;

namespace Blazor.UI.Service
{
    public class SubElementService : ISubElementService
    {
        private readonly HttpClient _httpClient;
        public SubElementService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }
        public async Task<int> CreateOrUpdateElement(SubElementDto elementDto)
        {
            var result = await _httpClient.PostAsJsonAsync("api/element/createOrUpdate", elementDto);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response.IsSuccess)
            {
                return response.Value;
            }
            else
                throw new Exception(response.Message);

        }

        public async Task<int> DeleteElement(int id)
        {

            var result = await _httpClient.DeleteAsync($"api/element/delete/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response.IsSuccess)
            {
                return response.Value;
            }
            else
                throw new Exception(response.Message);
        }
        
        public async Task<List<SubElementDto>> GetAllElementList()
        {
            var response = new ResponseAPI<List<SubElementDto>>();
            var elementDtos = await _httpClient.GetFromJsonAsync<List<SubElementDto>>("api/element/getallelement");
            if (elementDtos != null)
            {
                response = new ResponseAPI<List<SubElementDto>>
                {
                    Value = elementDtos
                };
                return response.Value;
            }
            else
                throw new Exception(response.Message);
        }

        public async Task<SubElementDto> GetElementById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<SubElementDto>>($"api/element/getbyId/{id}");
            if (result.IsSuccess)
                return result.Value;
            else
                throw new Exception(result.Message);
        }
    }
}
