using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gamer.Services
{
    public interface ISelectListService
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}
