[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Pradadge.Service.CoreApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Pradadge.Service.CoreApi.App_Start.NinjectWebCommon), "Stop")]

namespace Pradadge.Service.CoreApi.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using WebApiContrib.IoC.Ninject;
    using Contract.DataRepositoryInterface.Setup;
    using Data.DataRepository.Setup;
    using Data.DataRepository.Business;

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
                System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
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
            kernel.Bind<IStockRepositorys>().To<StockRepositorys>();
            kernel.Bind<IStockCardRepositorys>().To<StockCardRepositorys>();
            kernel.Bind<ISalesDetailRepository>().To<SalesDetailRepository>();
            kernel.Bind<IPurchaseOrderRepositorys>().To<PurchaseOrderRepositorys>();
            kernel.Bind<ITransactionStatusRepositorys>().To<TransactionStatusRepositorys>();
            kernel.Bind<IStatesRepository>().To<StatesRepository>();
            kernel.Bind<IStaffRepositorys>().To<StaffRepositorys>();
            kernel.Bind<ISalesTypesRepository>().To<SalesTypesRepository>();
            kernel.Bind<IProductsRepository>().To<ProductsRepository>();
            kernel.Bind<IPaymentModesRepository>().To<PaymentModesRepository>();
            kernel.Bind<ICompanysRepository>().To<CompanysRepository>();
            kernel.Bind<IDamagesRepositorys>().To<DamagesRepositorys>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<IBranchRepository>().To<BranchRepository>();           
            kernel.Bind<IPaymentRepository>().To<PaymentRepository>();
            kernel.Bind<IBrandRepository>().To<BrandRepository>();
            kernel.Bind<IMeasurementRepository>().To<MeasurementRepository>();
            kernel.Bind<ICountryRepository>().To<CountryRepository>();
            kernel.Bind<IVendorPaymentRepository>().To<VendorPaymentRepository>();
            kernel.Bind<IVendorRepository>().To<VendorRepository>();
            kernel.Bind<ISectionRepository>().To<SectionRepository>();
            kernel.Bind<IReferenceManagerRepository>().To<ReferenceManagerRepository>();
            kernel.Bind<IBankRepository>().To<BankRepository>();
        }        
    }

    
}
