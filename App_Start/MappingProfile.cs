using AutoMapper;
using SetifyFinal.Dtos;
using SetifyFinal.Models;

namespace SetifyFinal.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Artist, ArtistDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();


            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<ArtistDto, ArtistDto>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}