using Gamer.Models;
using Gamer.Services;
using Gamer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gamer.Controllers
{
    public class GamesController(IGameService gameService,
        ICategoryService categoryService,
        IDeviceService deviceService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var viewModel = new CreateGameFormViewModel
            {
                Catergoris = categoryService.GetSelectList(),
                Devices = deviceService.GetSelectList(),

            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Catergoris = categoryService.GetSelectList();
                viewModel.Devices = deviceService.GetSelectList();
                return View(viewModel);
            }
            await gameService.CreateAsync(viewModel);


            return RedirectToAction(nameof(Index));
        }
    }
}
