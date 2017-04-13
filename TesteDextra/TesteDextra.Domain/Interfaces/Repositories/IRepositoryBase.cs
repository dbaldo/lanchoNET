using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDextra.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface base para repositório
    /// </summary>
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Salva um novo registro
        /// </summary>
        void Add(TEntity obj);
        /// <summary>
        /// Buscar registro por id
        /// </summary>
        TEntity GetById(int id);
        /// <summary>
        /// Buscar todos os registros
        /// </summary>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Atualiza registro
        /// </summary>
        void Update(TEntity obj);
        /// <summary>
        /// Apaga definitivamente do banco registro
        /// </summary>
        void Remove(TEntity obj);
        /// <summary>
        /// Elimina lixo deixado pela requisição da memória do servidor
        /// </summary>
        void Dispose();
    }
}
