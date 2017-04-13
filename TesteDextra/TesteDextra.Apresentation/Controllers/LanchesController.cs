using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteDextra.Application.Interfaces;

namespace TesteDextra.Apresentation.Controllers
{
    public class LanchesController : Controller
    {
        private readonly ILancheAppService _lancheAppService;

        public LanchesController(ILancheAppService lancheAppService)
        {
            _lancheAppService = lancheAppService;
        }
        public ActionResult Index()
        {
            var lancheIndex = _lancheAppService.TrazObjetoTelaIncial();
            return View(lancheIndex);
        }
    }
}
