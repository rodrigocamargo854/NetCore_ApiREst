using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntities>()
               .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntities>()
               .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntities>()
               .ReverseMap();

        }
    }
}
