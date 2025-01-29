using Blip.Challenge.Domain.Entities;

namespace Blip.Challenge.Domain.Interfaces.Services
{
    public interface IGitHubService
    {
        Task<IEnumerable<GitHubOwnerRepository>> GetRepositoriesAsync(string username);
    }
}
