using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Users;

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
        public UserServices(IRepository<UserEntities> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntities> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntities>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<UserEntities> Post(UserEntities user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<UserEntities> Put(UserEntities user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}
