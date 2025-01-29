using Blip.Challenge.Presentation.ViewModels;

namespace Blip.Challenge.Presentation.Services.Interface
{
    public interface IPresentationService
    {
        Task<IEnumerable<GitHubOwnerRepositoryViewModel>> GetFiveOldestRepositoriesAsync(string username);
    }
}
