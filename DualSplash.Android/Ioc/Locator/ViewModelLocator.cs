using Acr.UserDialogs;
using Android.App;
using Autofac;
using DualSplash.Core.ViewModels;
using DualSplash.Core.Views;
using XLabs.Platform.Device;
using IContainer = Autofac.IContainer;
using Thread = System.Threading.Thread;


namespace DualSplash.Android.Ioc.Locator
{
    public static class ViewModelLocator
    {
        private static IContainer _container;


        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public static IContainer RegisterDependencies(bool useMockServices,Application application=null)
        {
            var builder = new ContainerBuilder();

            //moq
          /*  Mock<IUserDialogs> moqDialogs = new Mock<IUserDialogs>();
            Mock<XLabs.Platform.Device.IDevice> moqDevice =new Mock<IDevice>();
            Mock<XLabs.Platform.Device.IDisplay> moqDisplay =new Mock<IDisplay>();
            Mock<XLabs.Forms.Services.IFontManager> moqFontManager =new Mock<IFontManager>();*/



            


            // Register ViewModels
            builder.RegisterType<SlowPageViewModel>().SingleInstance();

            // Register Views
            builder.RegisterType<SlowPage>().SingleInstance();
            builder.RegisterType<FastPage>().SingleInstance();



            /*            
                                   builder.RegisterType<BasketViewModel>();
                                   builder.RegisterType<CatalogViewModel>();
                                   builder.RegisterType<CheckoutViewModel>();
                                   builder.RegisterType<LoginViewModel>();
                                   builder.RegisterType<MainViewModel>();
                                   builder.RegisterType<OrderDetailViewModel>();
                                   builder.RegisterType<ProfileViewModel>();
                                   builder.RegisterType<SettingsViewModel>();
                       */

            //Register Services
           /* builder.RegisterType<RequestProvider>()
                .As<IRequestProvider>()
                .SingleInstance();*/

            //await Task.Delay(500); // Slow init code
            Thread.Sleep(500);  //  2


            // Services
            ////////////////////////////////////////////////////////////////////////////////////////////
/*
            builder.RegisterType<FontSizeProvider>().As<IFontSizeProvider>()
                .SingleInstance();
*/

            // Register Base Services
            //////----------------------------------Navigation--------------------------

/*
            builder.RegisterType<NavigationService>()
                .As<INavigationService>()
                .SingleInstance();
*/


            ////////////////---------------------Ads -----------------------------------------
/*
            builder.RegisterType<MockInterStitialListener>()
                .As<IinterstitialAdListener>()
                .SingleInstance();
*/
            
            //////----------------------------------Aggregate Services--------------------------
/*
            builder.RegisterAggregateService<IBasicPageAggregateServices>();
*/





            /////////////////////// android services

            builder.Register(t => AndroidDevice.CurrentDevice)
                .As<XLabs.Platform.Device.IDevice>()
                .SingleInstance();

            builder.Register(t => AndroidDevice.CurrentDevice.Display)
                .As<XLabs.Platform.Device.IDisplay>()
                .SingleInstance();

            builder.RegisterType<XLabs.Forms.Services.FontManager>()
                .As<XLabs.Forms.Services.IFontManager>()
                .SingleInstance();


//            UserDialogs.Init(application);
            builder.RegisterInstance(UserDialogs.Instance)
                .As<Acr.UserDialogs.IUserDialogs>()
                .SingleInstance();



            /*
                        builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
                        builder.RegisterType<DialogService>().As<IDialogService>();
                        builder.RegisterType<OpenUrlService>().As<IOpenUrlService>();
                        builder.RegisterType<IdentityService>().As<IIdentityService>();
                        builder.RegisterType<RequestProvider>().As<IRequestProvider>();
                        builder.RegisterType<LocationService>().As<ILocationService>().SingleInstance();

            */
            if (useMockServices)
            {
             /* builder.RegisterInstance(new CatalogMockService()).As<ICatalogService>();
                builder.RegisterInstance(new BasketMockService()).As<IBasketService>();
                builder.RegisterInstance(new OrderMockService()).As<IOrderService>();
                builder.RegisterInstance(new UserMockService()).As<IUserService>();
*/
                //UseMockService = true;
            }
            else
            {
/*
                builder.RegisterType<CatalogService>().As<ICatalogService>().SingleInstance();
                builder.RegisterType<BasketService>().As<IBasketService>().SingleInstance();
                builder.RegisterType<OrderService>().As<IOrderService>().SingleInstance();
                builder.RegisterType<UserService>().As<IUserService>().SingleInstance();

                UseMockService = false;
*/
            }

            if (_container != null)
            {
                _container.Dispose();
            }
            _container = builder.Build();

            return _container;
        }
    }
}