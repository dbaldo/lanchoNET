using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TesteDextra.Application;
using TesteDextra.Application.Interfaces;
using TesteDextra.Domain.Interfaces.Repositories;
using TesteDextra.Infra.Data.Repositories;
using TesteDextra.Domain.Interfaces.Services;
using TesteDextra.Domain.Services;
using SimpleInjector;

namespace TesteDextra.Infra.BootStrapper
{
    public static class BootStapper
    {
        public static Container RegisterServices()
        {
            var container = new Container();
            //Repository
            container.Register<IIngredienteLancheRepository,IngredienteLancheRepository>();
            container.Register<IIngredienteRepository, IngredienteRepository>();
            container.Register<ILancheRepository, LancheRepository>();
            //Service
            container.Register<IIngredienteLancheService, IngredienteLancheService>();
            container.Register<IIngredienteService, IngredienteService>();
            container.Register<ILancheService, LancheService>();
            //Application
          
            container.Register<ILancheAppService, LancheAppService>();

            container.Verify();

            return container;
        }
    }
}
