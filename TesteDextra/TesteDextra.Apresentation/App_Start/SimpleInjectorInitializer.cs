//using System.Reflection;
//using System.Web;
//using System.Web.Mvc;
//using SimpleInjector;
//using TesteDextra.Presentation.App_Start;
//using SimpleInjector;
//using SimpleInjector.Advanced;
//using SimpleInjector.Integration.Web;
//using SimpleInjector.Integration.Web.Mvc;

//using WebActivator;
//using TesteDextra.Infra.BootStrapper;

//[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
//namespace TesteDextra.Presentation.App_Start
//{
//    public static class SimpleInjectorInitializer
//    {
//        public static void Initialize()
//        {
//            var container = new Container();
//            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

//            // Chamada dos módulos do Simple Injector
//            InitializeContainer(container);
//            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

//            container.Verify();

//            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
//        }

//        private static void InitializeContainer(Container container)
//        {
//            BootStapper.RegisterServices(container);
//        }
//    }
//}