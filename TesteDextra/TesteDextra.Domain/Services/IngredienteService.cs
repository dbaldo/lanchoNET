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
    /// Serviços responsável pela regra de negócio do Ingrediente
    /// </summary>
    public class IngredienteService : ServiceBase<Ingrediente>, IIngredienteService
    {
        #region .:Propriedades:.
        private readonly IIngredienteRepository _IngredienteRepository;
        #endregion
        #region .:Consturoes:.
        /// <summary>
        /// Construtor para injeção de dependência
        /// </summary>
        public IngredienteService(IIngredienteRepository IngredienteRepository)
            : base(IngredienteRepository)
        {
            _IngredienteRepository = IngredienteRepository;
        }
        #endregion
    }
}
