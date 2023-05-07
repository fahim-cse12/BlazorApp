using Blazor.BL.IService;
using Blazor.DAL.IRepository;
using Blazor.DAL.Repository;
using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.BL.Service
{
    public class WindowService : IWindowService
    {
        private readonly IWindowRepository _iwindowRepo;
        public WindowService(IWindowRepository windowRepo)
        {
            this._iwindowRepo = windowRepo;
        }
        public async Task<ResponseAPI<int>> CreateOrUpdateWindow(WindowDto windowDto)
        {
            var response = new ResponseAPI<int>();
            try
            {
                if (windowDto == null)
                {
                    response.IsSuccess = false;
                    response.Value = 0;
                    response.Message = "window data should not be null";

                }
                else
                {
                    var result = await _iwindowRepo.AddOrUpdateWindow(windowDto);
                    if (result > 0)
                    {
                        response.IsSuccess = true;
                        response.Value = result;
                        response.Message = "New Order has been saved";
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Value = 0;
                        response.Message = "Data not saved";
                    }

                }
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.IsSuccess = false;
                response.Value = 0;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseAPI<int>> DeleteWindow(int id)
        {
            var response = new ResponseAPI<int>();
            try
            {
                var result = await _iwindowRepo.DeleteWindow(id);
                if (result > 0)
                {
                    response.IsSuccess = true;
                    response.Value = result;
                    response.Message = $"Data has deleted with this id {response.Value}";

                }
                else
                {
                    response.IsSuccess = false;
                    response.Value = 0;
                }
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.IsSuccess = false;
                response.Value = 0;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseAPI<List<WindowDto>>> GetAllWindow()
        {
            var response = new ResponseAPI<List<WindowDto>>();
            try
            {
                var resultList = await _iwindowRepo.GetAllWindowList();
                if (resultList != null)
                {
                    response.IsSuccess = true;
                    response.Value = resultList;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Value = null;
                }
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.IsSuccess = false;
                response.Value = null;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseAPI<WindowDto>> GetWindowById(int id)
        {
            var response = new ResponseAPI<WindowDto>();
            try
            {
                var result = await _iwindowRepo.GetWindowById(id);
                if (result != null)
                {
                    response.IsSuccess = true;
                    response.Value = result;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Value = null;
                    response.Message = "Data not found";
                }

                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.IsSuccess = false;
                response.Value = null;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
