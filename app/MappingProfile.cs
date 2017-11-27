using AutoMapper;
using app.Models;

namespace app
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Deal, DealViewModel>();
        }
    }
}
