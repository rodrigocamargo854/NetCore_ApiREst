using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    //?Esta interface de metodos é para toda a aplicação.
    //?Interface genérica
    public interface IRepository<T> where T : BaseEntities
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid item);
        Task<T> SelectAsync(Guid item);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistsAsync(Guid id);




    }
}
