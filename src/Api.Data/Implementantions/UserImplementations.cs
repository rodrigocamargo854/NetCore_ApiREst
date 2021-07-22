using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementantions
{
    public class UserImplementations : BaseRepository<UserEntities>, IUserRepository
    {
        private DbSet<UserEntities> _dataset;
        public UserImplementations(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntities>();
        }

        public async Task<UserEntities> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
