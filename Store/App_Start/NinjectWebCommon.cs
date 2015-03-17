using System.Configuration;
using DataModul.BaseRepository;
using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.IRepository;
using DataModul.Query;
using DataModul.Repository;
using Store.Mappers;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Store.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Store.App_Start.NinjectWebCommon), "Stop")]

namespace Store.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            kernel.Bind<IMapper>().To<CommonMapper>().InSingletonScope();
            
    
            kernel.Bind<IRepositoryCategory>().ToMethod(c => new RepositoryCategory(new CategoryQuery(conStr)));
            kernel.Bind<IRepositoryAccount>().ToMethod(c => new RepositoryAccount(new AccountQuery(conStr)));
            kernel.Bind<IRepositoryAdres>().ToMethod(c => new RepositoryAdres(new AdresQuery(conStr)));
            kernel.Bind<IRepositoryCart>().ToMethod(c => new RepositoryCart(new CartQuery(conStr)));
            kernel.Bind<IRepositoryImage>().ToMethod(c => new RepositoryImage(new ImageQuery(conStr)));
            kernel.Bind<IRepositoryOrder>().ToMethod(c => new RepositoryOrder(new OrderQuery(conStr)));
            kernel.Bind<IRepositoryProduct>().ToMethod(c => new RepositoryProduct(new ProductQuery(conStr)));
            kernel.Bind<IRepositoryState>().ToMethod(c => new RepositoryState(new StateQuery(conStr)));
            kernel.Bind<IRepositoryUser>().ToMethod(c => new RepositoryUser(new UserQuery(conStr)));
            
        }        
    }
}
