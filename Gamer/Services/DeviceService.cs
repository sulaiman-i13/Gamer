using Gamer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gamer.Services
{
    public class DeviceService(AppDbContext context) : IDeviceService
    {
        public IEnumerable<SelectListItem> GetSelectList()
        {
           return context.Devices
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
                .OrderBy(c => c.Text)
                .ToList();
        }
    }
}
