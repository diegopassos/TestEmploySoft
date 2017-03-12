using AutoMapper;
using Like.Entities;
using Like.Web.Models;

namespace Like.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PreferenceViewModel, Preference>();
        }
    }
}