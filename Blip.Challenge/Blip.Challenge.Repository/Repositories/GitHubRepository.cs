using Blip.Challenge.Domain.Entities;
using Blip.Challenge.Domain.Interfaces.Repositories;
using System.Text.Json;

namespace Blip.Challenge.Repository.Repositories
{
    public class GitHubRepository : IGitHubRepository
    {
        private readonly HttpClient _httpClient;
        public GitHubRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<GitHubOwnerRepository>> GetRepositoriesAsync(string username)
        {
            var allRepositories = new List<GitHubOwnerRepository>();
            int page = 1;
            bool hasMoreResults = true;

            while (hasMoreResults)
            {
                var response = await _httpClient.GetAsync($"https://api.github.com/users/{username}/repos?page={page}&per_page=100");

                if (!response.IsSuccessStatusCode)
                {
                    return Enumerable.Empty<GitHubOwnerRepository>();
                }

                var content = await response.Content.ReadAsStringAsync();
                var repositories = JsonSerializer.Deserialize<IEnumerable<GitHubOwnerRepository>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

                if (repositories.Any())
                {
                    allRepositories.AddRange(repositories);
                    page++;
                }
                else
                {
                    hasMoreResults = false;
                }
            }

            return allRepositories;
        }
    }
}
