using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TesteTecnico.Infrastructure.Dominio;
using TesteTecnico.Infrastructure.Persistency;

namespace TesteTecnico.Persistency.Mock
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private static List<T> _entities;

        public BaseRepository()
        {
            _entities = new List<T>();
        }

        public Task Add(T entity)
        {
            return Task.Run(() =>
            {
                _entities.Add(entity);
            });
        }

        public Task AddMany(IEnumerable<T> entities)
        {
            return Task.Run(() =>
            {
                _entities.AddRange(entities);
            });
        }

        public async Task<IQueryable<T>> GetAllLazy()
        {
            return await Task.Run(() =>
            {
                return _entities.AsQueryable();
            });
        }

        public async Task<T> GetById(int id)
        {
            return await Task.Run(() =>
            {
                return _entities.FirstOrDefault(x => x.Id == id);
            });
        }

        public Task Remove(T entity)
        {
            return Task.Run(() =>
            {
                _entities.Remove(entity);
            });
        }

        public Task Update(T entity)
        {
            return Task.Run(() =>
            {
                var currentEntity = _entities.FirstOrDefault(x => x.Id == entity.Id);

                currentEntity.Update(entity);
            });
        }
    }
}
