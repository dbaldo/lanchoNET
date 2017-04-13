//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using TesteDextra.Application.Interfaces;

//namespace TesteDextra.Presentation.Controllers
//{
//    /// <summary>
//    /// Constoller principal do software
//    /// </summary>
//    public class IngredienteController : Controller
//    {

//        #region .:Propriedades:.
//        private readonly IIngredienteAppService _IngredienteAppService;
//        #endregion

//        #region .:Constutores:.
//        /// <summary>
//        /// Construtor com interface para injeção de dependência
//        /// </summary>
//        public IngredienteController(IIngredienteAppService IngredienteAppService)
//        {
//            _IngredienteAppService = IngredienteAppService;
//        }
//        #endregion

//        #region .:Actions:.
//        ///// <summary>
//        ///// Rota padrão do software
//        ///// </summary>
//        //public ActionResult Cadastrar()
//        //{
//        //    var IngredienteViewModel = _IngredienteAppService.CarregarObejtoParaViewModel();
//        //    return View(IngredienteViewModel);
//        //}
//        ///// <summary>
//        ///// Carrega Regiões na Partial View
//        ///// </summary>
//        //public PartialViewResult CarregaRegioes()
//        //{
//        //    var regioes = _IngredienteAppService.BuscarTodasRegioes();
//        //    return PartialView("_Regioes", regioes);
//        //}
//        ///// <summary>
//        ///// Salva um nova Região ou Altera de acordo com ação do usuário na tela
//        ///// </summary>
//        //public JsonResult Salvar(IngredienteRegisterViewModel Ingrediente)
//        //{
//        //    try
//        //    {
//        //        _IngredienteAppService.SalvarIngrediente(Ingrediente);
//        //        return Json(new { sucesso = true });
//        //    }
//        //    catch(Exception e)
//        //    {
//        //        return Json(new { sucesso = false, error = e.Message });
//        //    }
//        //}
//        ///// <summary>
//        ///// Inativa o região passando seu ID
//        ///// </summary>
//        //public JsonResult Inativar(int IngredienteID)
//        //{
//        //    try
//        //    {
//        //        _IngredienteAppService.InativarIngredientePorID(IngredienteID);
//        //        return Json(new { sucesso = true });
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        return Json(new { sucesso = false, error = e.Message });
//        //    }
//        //}
//        ///// <summary>
//        ///// Ativa o região passando seu ID
//        ///// </summary>
//        //public JsonResult Ativar(int IngredienteID)
//        //{
//        //    try
//        //    {
//        //        _IngredienteAppService.AtivarIngredientePorID(IngredienteID);
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
