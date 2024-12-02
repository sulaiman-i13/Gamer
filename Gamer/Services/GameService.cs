



namespace Gamer.Services
{
    public class GameService(AppDbContext context,
                    IWebHostEnvironment webHostEnvironment
                    ) : IGameService
    {
        private readonly string imagesPath=$"{webHostEnvironment.WebRootPath}{FileSettings.ImagePath}";
        public async Task CreateAsync(CreateGameFormViewModel viewModel)
        {
            var coverFullName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(viewModel.Cover.FileName)}";
            var coverFullPath = Path.Combine(imagesPath, coverFullName);
            using var stream=File.Create(coverFullPath);
            await viewModel.Cover.CopyToAsync(stream);
            var game = new Game
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                CategoryId = viewModel.CategoryId,
                Devices = viewModel.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
            };
            await context.AddAsync(game);
            await context.SaveChangesAsync();

        }


      
    }
}
