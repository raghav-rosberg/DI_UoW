using AutoMapper;
using DI_UoW.Model.Entities;
using DI_UoW.ViewModel;

namespace DI_UoW.Mappings
{

    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AccountViewModel, ApplicationUser>();
        }
    }
}