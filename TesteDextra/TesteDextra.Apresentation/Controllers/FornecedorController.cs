//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using TesteDextra.Application.Interfaces;

//namespace TesteDextra.Apresentation.Controllers
//{
//    /// <summary>
//    /// Constoller para action do Lanche
//    /// </summary>
//    public class LancheController : Controller
//    {
//        #region .:Propriedades:.
//        private readonly IIngredienteAppService _IngredienteAppService;
//        private readonly ILancheAppService _LancheAppService;
//        #endregion

//        #region .:Constutores:.
//        /// <summary>
//        /// Construtor com interface para injeção de dependência
//        /// </summary>
//        public LanchoneteController(IIngredienteAppService IngredienteAppService,
//                                    ILancheAppService LancheAppService)
//        {
//            _LancheAppService = LancheAppService;
//            _IngredienteAppService = IngredienteAppService;
//        }
//        #endregion

//        #region .:Actions:.
//        ///// <summary>
//        ///// Rota principal para controller do Lanche
//        ///// </summary>
//        //public ActionResult CadastrarIngrediente()
//        //{
//        //    var LancheViewModel = _LancheAppService.CarregarObejtoParaViewModel();
//        //    return View(LancheViewModel);
//        //}
//        ///// <summary>
//        ///// Busca regiões por forncedorID e retorna um Json
//        ///// </summary>
//        //public JsonResult BuscarRegioes(int LancheID)
//        //{
//        //    try
//        //    {
//        //        var regioes = _LancheAppService.BuscarIngredienteLanchePorForncedorID(LancheID);
//        //        return Json(new { sucesso = true,regioes = regioes });
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        return Json(new { sucesso = false, error = e.Message });
//        //    }
//        //}
//        ///// <summary>
//        ///// Recebe os parametros via Json e Salva no Banco as Alterações Feitas
//        ///// </summary>
//        //public JsonResult SalvarRegioes(int[] RegioesID,int LancheID)
//        //{
//        //    try
//        //    {
//        //        _LancheAppService.SalvarRegioesDoForncedor(RegioesID, LancheID);
//        //        return Json(new { sucesso = true });
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        return Json(new { sucesso = false, error = e.Message });
//        //    }
//        //}
//        #endregion
//    }
//}
