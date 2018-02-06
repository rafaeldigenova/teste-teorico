using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnico.Infrastructure.Persistency
{
    public interface IBaseRepository<T> where T : Dominio.EntityBase
    {
        Task<T> GetById(int id);
        Task<IQueryable<T>> GetAllLazy();
        Task Add(T entity);
        Task AddMany(IEnumerable<T> entities);
        Task Update(T entity);
        Task Remove(T entity);
    }
}
