using Blip.Challenge.Domain.Interfaces.Repositories;
using Blip.Challenge.Domain.Interfaces.Services;
using Blip.Challenge.Domain.Services;
using Blip.Challenge.Presentation.Mapper;
using Blip.Challenge.Presentation.Services;
using Blip.Challenge.Presentation.Services.Interface;
using Blip.Challenge.Repository.Repositories;

namespace Blip.Challenge.Api.Configs
{
    public class ConfigIoC
    {
        public static void AddDependencyInjection(IServiceCollection services, IConfiguration config)
        {
            //Services
            services.AddScoped<IGitHubService, GitHubService>();
            services.AddScoped<IPresentationService, PresentationService>();

            //Repositories
            services.AddScoped<IGitHubRepository, GitHubRepository>();

            //AutoMapper
            services.AddAutoMapper(typeof(GitHubMappingProfile));

            services.AddHttpClient<IGitHubRepository, GitHubRepository>(client =>
            {
                client.BaseAddress = new Uri("https://api.github.com/");
                client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });
        }
    }
}
