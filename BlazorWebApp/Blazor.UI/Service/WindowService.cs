using Blazor.Shared.Models;
using Blazor.UI.IService;
using System.Net.Http.Json;

namespace Blazor.UI.Service
{
    public class WindowService : IWindowService
    {
        private readonly HttpClient _httpClient;
        public WindowService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }
        public async Task<int> CreateOrUpdateWindow(WindowDto widnowDto)
        {
            var result = await _httpClient.PostAsJsonAsync("api/window/createorupdate", widnowDto);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response.IsSuccess)
            {
                return response.Value;
            }
            else
                throw new Exception(response.Message);
        }

        public async Task<int> DeleteWindow(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/window/deletewindow/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response.IsSuccess)
            {
                return response.Value;
            }
            else
                throw new Exception(response.Message);
        }

        public async Task<List<WindowDto>> GetAllWindowList()
        {
            var response = new ResponseAPI<List<WindowDto>>();
            var windowDtos = await _httpClient.GetFromJsonAsync<List<WindowDto>>("api/window/getallwindow");
            if (windowDtos != null)
            {
                response = new ResponseAPI<List<WindowDto>>
                {
                    Value = windowDtos
                };
                return response.Value;
            }
            else
                throw new Exception(response.Message);
        }

        public async Task<WindowDto> GetWindowById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<WindowDto>>($"api/window/getbyId/{id}");
            if (result.IsSuccess)
                return result.Value;
            else
                throw new Exception(result.Message);
        }
    }
}
