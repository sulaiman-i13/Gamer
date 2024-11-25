using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gamer.Services
{
    public class CategoryService(AppDbContext context) : ICategoryService
    {
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return context.Categories
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
                .OrderBy(c => c.Text)
                .ToList();
        }
    }
}
