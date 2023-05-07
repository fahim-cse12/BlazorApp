using Blazor.BL.IService;
using Blazor.DAL.Enitities;
using Blazor.DAL.IRepository;
using Blazor.DAL.Repository;
using Blazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.BL.Service
{
    public class SubElementService : ISubElementService
    {
        private readonly ISubElementRepository _ielementRepository;
        public SubElementService(ISubElementRepository elementRepository)
        {
            this._ielementRepository = elementRepository;
        }
        public async Task<ResponseAPI<int>> CreateOrUpdateElement(SubElementDto elementDto)
        {
            var response = new ResponseAPI<int>();
            try
            {
                if (elementDto == null)
                {
                    response.IsSuccess = false;
                    response.Value = 0;
                    response.Message = "Order data should not be null";

                }
                else
                {
                    var result = await _ielementRepository.AddOrUpdateElement(elementDto);
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

        public async Task<ResponseAPI<int>> DeleteSubElement(int id)
        {
            var response = new ResponseAPI<int>();
            try
            {
                var result = await _ielementRepository.DeleteElement(id);
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

        public async Task<ResponseAPI<List<SubElementDto>>> GetAllElement()
        {
            var response = new ResponseAPI<List<SubElementDto>>();
            try
            {
                var resultList = await _ielementRepository.GetAllElementList();
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

        public async Task<ResponseAPI<SubElementDto>> GetElementById(int id)
        {
            var response = new ResponseAPI<SubElementDto>();
            try
            {
                var result = await _ielementRepository.GetElementById(id);
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
