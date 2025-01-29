using Blip.Challenge.Domain.Entities;

namespace Blip.Challenge.Domain.Interfaces.Repositories
{
    public interface IGitHubRepository
    {
        Task<IEnumerable<GitHubOwnerRepository>> GetRepositoriesAsync(string username);
    }
}
