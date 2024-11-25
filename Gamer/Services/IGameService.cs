using Gamer.ViewModels;

namespace Gamer.Services
{
    public interface IGameService
    {
        Task CreateAsync(CreateGameFormViewModel createGameFormViewModel);
    }
}
