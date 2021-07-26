using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Interfaces.Services.Users;
using Api.Domain.Models.User;
using AutoMapper;

namespace Api.Service.Services
{
    //?Classe criada com os serviços em especifico ao usuário
    //?Regras de negócio
    //*Todos os metodos estão implmentados 

    public class UserServices : IUserService
    {
        //*Repositorio para usuários
        private IRepository<UserEntities> _repository;
        //*    //*Todos os metodos estão implmentados
        //? Utilizando o automapper injetada n construtor da classe UserServices
        private readonly IMapper _mapper;
        public UserServices(IRepository<UserEntities> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity =  await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listentity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(listentity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntities>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntities>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<UserDtoUpdateResult>(result);
            
        }
    }
}
