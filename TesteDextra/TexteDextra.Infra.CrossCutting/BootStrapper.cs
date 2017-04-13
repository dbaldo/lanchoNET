using SimpleInjector;
using TesteDextra.Application;
using TesteDextra.Application.Interfaces;
using TesteDextra.Domain.Interfaces.Repositories;
using TesteDextra.Domain.Interfaces.Services;
using TesteDextra.Domain.Services;
using TesteDextra.Infra.Data.Repositories;

namespace TesteDextra.Infra.CrossCutting
{
    public static class BootStrapper
    {
        /// <summary>
        /// Camada de crosscutting onde é feio registro das injeções de dependências
        /// </summary>
        public static void RegisterServices(SimpleInjector.Container container)
        {

            //Repository
            container.RegisterPerWebRequest<IIngredienteLancheRepository, IngredienteLancheRepository>();
            container.RegisterPerWebRequest<IIngredienteRepository, IngredienteRepository>();
            container.RegisterPerWebRequest<ILancheRepository, LancheRepository>();
            //Service
            container.RegisterPerWebRequest<IIngredienteLancheService, IngredienteLancheService>();
            container.RegisterPerWebRequest<IIngredienteService, IngredienteService>();
            container.RegisterPerWebRequest<ILancheService, LancheService>();
            //Application

            container.RegisterPerWebRequest<ILancheAppService, LancheAppService>();


        }
    }
}
