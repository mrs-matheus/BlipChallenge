using Blip.Challenge.Domain.Entities;
using Blip.Challenge.Domain.Interfaces.Repositories;
using Blip.Challenge.Domain.Interfaces.Services;

namespace Blip.Challenge.Domain.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly IGitHubRepository _repository;
        public GitHubService(IGitHubRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GitHubOwnerRepository>> GetRepositoriesAsync(string username)
        {
            return await _repository.GetRepositoriesAsync(username);
        }
    }
}
