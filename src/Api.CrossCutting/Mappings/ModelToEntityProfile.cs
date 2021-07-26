using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Domain.Models.User;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntities>()
               .ReverseMap();
        }
    }
}
