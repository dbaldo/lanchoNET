using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDextra.Application.Interfaces;
using TesteDextra.Domain.Entities;
using TesteDextra.Domain.Interfaces.Services;
using TesteDextra.VMMV;

namespace TesteDextra.Application
{
    /// <summary>
    /// Aplicação para o Lanche responsável pelo tratamento de dados e chamadas dos serviços para a controller
    /// </summary>
    public class LancheAppService : AppServiceBase<Lanche>, ILancheAppService
    {
        #region .:Propriedades:.
        private readonly ILancheService _LancheService;
        private readonly IIngredienteService _IngredienteService;
        #endregion


        #region .:Consturoes:.
        /// <summary>
        /// Construtor para injeção de dependência
        /// </summary>
        public LancheAppService(ILancheService LancheService,
                                IIngredienteService IngredienteService)
            :base(LancheService)
        {
            _LancheService = LancheService;
            _IngredienteService = IngredienteService;
        }


        #endregion

        #region .:Funções:.
        /// <summary>
        /// Traz cardápio atual com preços calculados com descontos aplicados
        /// </summary>
        public IList<LancheListViewModel> Cardapio()
        {
            var cardapio = _LancheService.Cardapio();
            var cardapioVM = Mapper.Map<IList<Lanche>, IList<LancheListViewModel>>(cardapio);
            return cardapioVM;
        }
        /// <summary>
        /// Calcula preco de lanche personalizado
        /// </summary>
        public LancheListViewModel CalculaPrecoLanchePersonalizado(LancheListViewModel lanche)
        {
            var ingredientesVM = lanche.IngredientesLanche;
            var ingredientes = Mapper.Map<IList<IngredienteLancheListViewModel>, IList<IngredienteLanche>>(ingredientesVM.ToList());
            var lancheObj = _LancheService.CalculaPrecoLanchePersonalizado(ingredientes);
            var lancheVM = Mapper.Map<Lanche, LancheListViewModel>(lancheObj);

            return lancheVM;
        }

        public LancheIndex TrazObjetoTelaIncial()
        {

            var lancheIndex = new LancheIndex();
            var Ingredientes = _IngredienteService.GetAll();
            var IngredientesVM  = Mapper.Map<IList<Ingrediente>, IList<IngredienteListViewModel>>(Ingredientes.ToList());

            lancheIndex.Cardapio = Cardapio();
            lancheIndex.Ingredientes = IngredientesVM;

            return lancheIndex;
        }


        #endregion
    }
}
