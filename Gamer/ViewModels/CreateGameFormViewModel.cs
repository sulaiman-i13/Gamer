using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Gamer.ViewModels
{
    public class CreateGameFormViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Catergoris { get; set; }= [];
        [Display(Name="Supported Devices")]
        public List<int> SelectedDevices { get; set; } = [];
        public IEnumerable<SelectListItem> Devices { get; set; } = [];
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;

        public IFormFile Cover { get; set; } = default!;
    }
}
