using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Users
{
    //?Na camada domain criamos as interfaces para o usuario ou para 
    //?qual entidade necessitar. Metodos especificos que recebem o tipo 
    //?da entidade para
    //? Aqui criamos toda a regra de negocio.
    public interface IUserService
    {
        //*Retorna um usuario 
        Task<UserEntities> Get(Guid id);
        //?Retorna uma lista de usuarios
        Task<IEnumerable<UserEntities>> GetAll();
        Task<UserEntities> Put(UserEntities id);
        Task<UserEntities> Post(UserEntities id);
        Task<bool> Delete(Guid id);


    }
}
