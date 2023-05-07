using Blazor.DAL.Enitities;
using Blazor.DAL.IRepository;
using Blazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.DAL.Repository
{
    public class WindowRepository : IWindowRepository
    {
        private readonly BlazorDbContext _dbContext;

        public WindowRepository(BlazorDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<int> AddOrUpdateWindow(WindowDto windowDto)
        {
            int windowId = 0;
            windowId = windowDto.Id;
            if (windowDto.Id == 0)
            {
                Window window = new Window
                {
                    Id = windowDto.Id,
                    Name = windowDto.Name,
                    QuantityOfWindows = windowDto.QuantityOfWindows,
                    TotalSubElements = windowDto.TotalSubElements,
                    OrderId = windowDto.OrderId,  
                    
                };
                await _dbContext.Windows.AddAsync(window);
                await _dbContext.SaveChangesAsync();

                windowId = window.Id;
            }
            else
            {
                Window window = new Window
                {
                    Id = windowDto.Id,
                    Name = windowDto.Name,
                    QuantityOfWindows = windowDto.QuantityOfWindows,
                    TotalSubElements = windowDto.TotalSubElements,
                    OrderId = windowDto.OrderId,

                };
                _dbContext.Windows.Update(window);
                await _dbContext.SaveChangesAsync();
            }


            return windowId;
        }      
               
        public async Task<int> DeleteWindow(int id)
        {
            var window = await _dbContext.Windows.FindAsync(id);

            if (window != null)
            {
                _dbContext.Windows.Remove(window);
                await _dbContext.SaveChangesAsync();
                return id;
            }
            else
            {
                return 0;
            }
        }      
               
        public async Task<List<WindowDto>> GetAllWindowList()
        {
            var windows = await _dbContext.Windows.ToListAsync();
            if (windows.Count > 0)
            {
                List<WindowDto> windowList = new List<WindowDto>();
                foreach (var item in windows)
                {
                    WindowDto window = new WindowDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        OrderId= item.OrderId,
                        QuantityOfWindows = item.QuantityOfWindows, 
                        TotalSubElements = item.TotalSubElements   
                    };
                    windowList.Add(window);
                }

                return windowList;
            }
            else
            {
                return null;
            }
        }      
               
        public async Task<WindowDto> GetWindowById(int id)
        {
            var window = await _dbContext.Windows.FirstOrDefaultAsync(i => i.Id == id);
            if (window != null)
            {
                WindowDto windowobj = new WindowDto
                {
                    Id = window.Id,
                    Name = window.Name,
                    OrderId = window.OrderId,
                    QuantityOfWindows = window.QuantityOfWindows,   
                    TotalSubElements = window.TotalSubElements  
                };
                return windowobj;
            }
            else
            {
                return null;
            }
        }
    }
}
