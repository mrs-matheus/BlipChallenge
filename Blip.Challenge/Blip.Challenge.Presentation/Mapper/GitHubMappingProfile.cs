using AutoMapper;
using Blip.Challenge.Domain.Entities;
using Blip.Challenge.Presentation.ViewModels;

namespace Blip.Challenge.Presentation.Mapper
{
    public class GitHubMappingProfile : Profile
    {
        public GitHubMappingProfile()
        {

            CreateMap<GitHubOwnerRepository, GitHubOwnerRepositoryViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(y => y.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description))
                .ForMember(x => x.Picture, opt => opt.MapFrom(y => y.Owner.Avatar_Url))
                .ForMember(x => x.Url, opt => opt.MapFrom(y => y.Url))
                .ForMember(x => x.Created, opt => opt.MapFrom(y => y.Created_At));
        }
    }
}
