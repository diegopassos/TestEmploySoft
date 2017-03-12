using AutoMapper;
using Like.Entities;
using Like.Web.Models;

namespace Like.Web.Infrastructure.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Preference, PreferenceViewModel>();
            CreateMap<Image, ImageViewModel>();
        }
    }
}