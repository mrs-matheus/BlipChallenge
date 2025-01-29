using AutoMapper;
using Blip.Challenge.Domain.Interfaces.Services;
using Blip.Challenge.Presentation.Services.Interface;
using Blip.Challenge.Presentation.ViewModels;

namespace Blip.Challenge.Presentation.Services
{
    public class PresentationService : IPresentationService
    {
        private readonly IGitHubService _gitHubService;
        private readonly IMapper _mapper;
        public PresentationService(IGitHubService gitHubService, IMapper mapper)
        {
            _gitHubService = gitHubService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GitHubOwnerRepositoryViewModel>> GetFiveOldestRepositoriesAsync(string username)
        {
            var repositories = _mapper.Map<IEnumerable<GitHubOwnerRepositoryViewModel>>(await _gitHubService.GetRepositoriesAsync(username));

            return repositories.OrderBy(x => x.Created).Take(5);
        }
    }
}
