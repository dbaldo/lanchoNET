using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDextra.Domain.Entities;
using TesteDextra.Domain.Interfaces.Repositories;
using TesteDextra.Domain.Interfaces.Services;

namespace TesteDextra.Domain.Services
{
    /// <summary>
    /// Serviços responsável pela regra de negócio do IngredienteLanche
    /// </summary>
    public class IngredienteLancheService : ServiceBase<IngredienteLanche>, IIngredienteLancheService
    {
        #region .:Propriedades:.
        private readonly IIngredienteLancheRepository _IngredienteLancheRepository;
        #endregion
        #region .:Consturoes:.
        /// <summary>
        /// Construtor para injeção de dependência
        /// </summary>
        public IngredienteLancheService(IIngredienteLancheRepository IngredienteLancheRepository)
            : base(IngredienteLancheRepository)
        {
            _IngredienteLancheRepository = IngredienteLancheRepository;
        }
        #endregion
    }
}
