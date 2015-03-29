using AutoMapper;
using DI_UoW.Model.Entities;
using DI_UoW.ViewModel;

namespace DI_UoW.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ApplicationUser, AccountViewModel>();
        }
    }
}