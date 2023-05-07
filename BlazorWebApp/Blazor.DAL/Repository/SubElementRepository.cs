using Blazor.DAL.Enitities;
using Blazor.DAL.IRepository;
using Blazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.DAL.Repository
{
    public class SubElementRepository : ISubElementRepository
    {
        private readonly BlazorDbContext _dbContext;

        public SubElementRepository(BlazorDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<int> AddOrUpdateElement(SubElementDto subElementDto)
        {
            int elementId = 0;
            elementId = subElementDto.Id;
            if (subElementDto.Id == 0)
            {
                SubElement element = new SubElement
                {
                    Id = subElementDto.Id,
                    Element = subElementDto.Element,
                    Height = subElementDto.Height,
                    Type = subElementDto.Type,
                    Width = subElementDto.Width,
                    WindowId = subElementDto.WindowId
                    
                   
                };
                await _dbContext.SubElements.AddAsync(element);
                await _dbContext.SaveChangesAsync();

                elementId = element.Id;
            }
            else
            {
                SubElement element = new SubElement
                {
                    Id = subElementDto.Id,
                    Element = subElementDto.Element,
                    Height = subElementDto.Height,
                    Type = subElementDto.Type,
                    Width = subElementDto.Width,
                    WindowId = subElementDto.WindowId
                };
                _dbContext.SubElements.Update(element);
                await _dbContext.SaveChangesAsync();
            }


            return elementId;
        }

        public async Task<int> DeleteElement(int id)
        {
            var element = await _dbContext.SubElements.FindAsync(id);

            if (element != null)
            {
                _dbContext.SubElements.Remove(element);
                await _dbContext.SaveChangesAsync();
                return id;
            }
            else
            {
                return 0;
            }

        }

        public async Task<List<SubElementDto>> GetAllElementList()
        {
            var resultList = await _dbContext.SubElements.ToListAsync();
            if (resultList.Count > 0)
            {
                List<SubElementDto> elementList = new List<SubElementDto>();
                foreach (var item in resultList)
                {
                    SubElementDto el = new SubElementDto
                    {
                        Id = item.Id,
                        Element = item.Element,
                        Height = item.Height,   
                        Width = item.Width,
                        Type = item.Type,
                        WindowId = item.WindowId
                        
                    };
                    elementList.Add(el);
                }

                return elementList;
            }
            else
            {
                return null;
            }

        }

        public async Task<SubElementDto> GetElementById(int id)
        {
            var element = await _dbContext.SubElements.FirstOrDefaultAsync(i => i.Id == id);
            if (element != null)
            {
                SubElementDto elementObj = new SubElementDto
                {
                    Id = element.Id,
                    Element = element.Element,  
                    Height = element.Height,    
                    Width = element.Width,  
                    Type = element.Type,    
                    WindowId = element.WindowId
                   
                };
                return elementObj;
            }
            else
            {
                return null;
            }
        }
    }
}
