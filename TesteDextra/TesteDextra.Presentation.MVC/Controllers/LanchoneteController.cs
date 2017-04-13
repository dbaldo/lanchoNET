using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteDextra.Application.Interfaces;
using TesteDextra.VMMV;

namespace TesteDextra.Presentation.MVC.Controllers
{
    public class LanchoneteController : Controller
    {
        private readonly ILancheAppService _lancheAppService;

        public LanchoneteController(ILancheAppService lancheAppService)
        {
            _lancheAppService = lancheAppService;
        }
        /// <summary>
        /// Pagina incial carrega cardápio com preços atualizados e aplicada promoção
        /// </summary>
        public ActionResult Index()
        {
            var lancheIndex = _lancheAppService.TrazObjetoTelaIncial();
            return View(lancheIndex);
        }
        /// <summary>
        /// Calcula Preço lanche customizado
        /// </summary>
        public JsonResult CalculaPreco(IList<IngredienteLancheListViewModel> ingredientes)
        {
            try
            {
                var lanche = new LancheListViewModel()
                {
                    IngredientesLanche = ingredientes
                };
                lanche = _lancheAppService.CalculaPrecoLanchePersonalizado(lanche);
                return Json(new { sucesso = true, preco = lanche.Preco.ToString("N2") });
            }
            catch (Exception e)
            {
                return Json(new { sucesso = false, error = $"Erro ao calcular preço: {e.Message}"});
            }
        }
    }
}
