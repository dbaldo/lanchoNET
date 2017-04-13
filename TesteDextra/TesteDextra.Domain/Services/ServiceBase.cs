using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDextra.Domain.Interfaces.Repositories;
using TesteDextra.Domain.Interfaces.Services;

namespace TesteDextra.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Salva um novo registro
        /// </summary>
        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }
        /// <summary>
        /// Buscar registro por id
        /// </summary>
        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Buscar todos os registros
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Atualiza registro
        /// </summary>
        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
        /// <summary>
        /// Apaga definitivamente do banco registro
        /// </summary>
        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        /// <summary>
        /// Elimina lixo deixado pela requisição da memória do servidor
        /// </summary>
        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
