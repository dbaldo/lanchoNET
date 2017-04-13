using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDextra.Application.Interfaces
{
    /// <summary>
    /// Interface da Aplicação Base responsável pelo tratamento de dados e chamadas dos serviços para a controller
    /// </summary>
    public interface IAppServiceBase<TEntity> where TEntity : class
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
