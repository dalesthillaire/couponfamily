using System.Collections.Generic;
using AutoMapper;
using app.Models;

namespace app
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<Deal, DealViewModel>()
                .ForMember(m => m.BusinessId, opt => opt.Ignore())
                .ForMember(m => m.City, opt => opt.Ignore())
                .ForMember(m => m.State, opt => opt.Ignore())
                .ForMember(m => m.Phone, opt => opt.Ignore())
                .ForMember(m => m.StreetAddress, opt => opt.Ignore())
                .ForMember(m => m.Zip, opt => opt.Ignore());

            CreateMap<DealViewModel, Deal>()
                .ForMember(vm => vm.Creator, opt => opt.Ignore())
                .ForMember(vm => vm.ImageUrl, opt => opt.Ignore());
        }
    }
}
