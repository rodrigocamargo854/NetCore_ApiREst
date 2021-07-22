using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;


//? Interface criada para implmentação do jwt
namespace Api.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntities>
    {
        Task<UserEntities> FindByLogin(string email);

    }
}
