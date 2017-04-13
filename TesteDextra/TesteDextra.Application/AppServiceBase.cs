using System;
using System.Collections.Generic;
using TesteDextra.Application.Interfaces;
using TesteDextra.Domain.Interfaces.Services;

namespace TesteDextra.Application
{
    /// <summary>
    /// Aplicação Base responsável pelo tratamento de dados e chamadas dos serviços para a controller
    /// </summary>
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }
        /// <summary>
        /// Salva um novo registro
        /// </summary>
        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }
        /// <summary>
        /// Buscar registro por id
        /// </summary>
        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }
        /// <summary>
        /// Buscar todos os registros
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }
        /// <summary>
        /// Atualiza registro
        /// </summary>
        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }
        /// <summary>
        /// Apaga definitivamente do banco registro
        /// </summary>
        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }
        /// <summary>
        /// Elimina lixo deixado pela requisição da memória do servidor
        /// </summary>
        public void Dispose()
        {
            _serviceBase.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
