using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntities
    {
        //the protect variable for dependency inject    
        protected readonly MyContext _context;
        private DbSet<T> _dataSet;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                if (true)
                {
                    var result = await _dataSet.SingleOrDefaultAsync(p => p.id.Equals(id));
                    if (result == null)
                    {
                        return false;
                    }

                    _dataSet.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                //if empty id , create a random id
                if (item.id == Guid.Empty)
                {
                    item.id = Guid.NewGuid();
                }
                //insert the actual system date 
                item.CreatAt = DateTime.UtcNow;
                _dataSet.Add(item);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return item;

        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.id.Equals(id));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            // criamos uma variavel result para receber as entradas do front
            //caso a entrada seja nula , retornara nulo
            // caso retorne cmo esperado , atualiza a data
            //injeta o nvo valor no valor antigo e na linha
            //80 atualiza o banco de dados sempre com o await
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.id.Equals(item.id));
                if (result == null)
                {
                    return null;
                }

                item.UpdateAt = DateTime.UtcNow;
                item.CreatAt = result.CreatAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {

                throw ex;
            }

            return item;
        }
        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dataSet.AnyAsync(p => p.id.Equals(id));
        }

    }
}
