using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDextra.Domain.Interfaces.Repositories;
using TesteDextra.Infra.Data.Context;

namespace TesteDextra.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório responsável pela persistência de dados de todas as entidades quando for necessário apenas o CRUD
    /// </summary>
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected TesteDextraContext Db = new TesteDextraContext();
        /// <summary>
        /// Salva um novo registro
        /// </summary>
        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }
        /// <summary>
        /// Buscar registro por id
        /// </summary>
        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }
        /// <summary>
        /// Buscar todos os registros
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }
        /// <summary>
        /// Atualiza registro
        /// </summary>
        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
        /// <summary>
        /// Apaga definitivamente do banco registro
        /// </summary>
        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }
        /// <summary>
        /// Elimina lixo deixado pela requisição da memória do servidor
        /// </summary>
        public void Dispose()
        {
            Db = null;
            GC.SuppressFinalize(this);
        }
    }
}
