using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDextra.Domain.Entities;

namespace TesteDextra.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface do Repositório responsável pela persistência de dados do Lanche
    /// </summary>
    public interface ILancheRepository : IRepositoryBase<Lanche>
    {
    }
}
