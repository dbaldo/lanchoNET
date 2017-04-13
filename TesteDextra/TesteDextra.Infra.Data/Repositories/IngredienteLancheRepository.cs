using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDextra.Infra.Data.Repositories;
using TesteDextra.Domain.Entities;
using TesteDextra.Domain.Interfaces.Repositories;
using TesteDextra.Service;

namespace TesteDextra.Infra.Data.Repositories
{
    /// <summary>
    /// Repostirório responsável pela persistência de dados do IngredienteLanche
    /// </summary>
    public class IngredienteLancheRepository : RepositoryBase<IngredienteLanche> ,IIngredienteLancheRepository
    {
        
    }
}
