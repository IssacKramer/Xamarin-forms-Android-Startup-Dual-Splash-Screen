using System.Diagnostics;
using Autofac;
using DualSplash.Core.Ioc;
using DualSplash.Core.ViewModels;
using DualSplash.Core.Views;
using Xamarin.Forms;

namespace DualSplash.Core
{

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class DualSplashApp : Application
    {
        public static NavigationPage RootNavigation;
        public static Stopwatch stopWatch;

        public DualSplashApp()
        {


          



#if TRACE

            DualSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------DualSplashApp.cs - Start DualSplashApp Constructor before SlowPage created---------:  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();

#endif


            //var container = AppContainer.Container;
            FastPage fastPage = null;
            if (AppContainer.Container != null)
            {

                using (var scope = AppContainer.Container.BeginLifetimeScope())
                {
                    fastPage = scope.Resolve<FastPage>();
                }
            }
            //var dollarPage = container.Resolve<SlowPage>();
            RootNavigation = new NavigationPage(fastPage);
#if TRACE
            DualSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------DualSplashApp.cs - After SlowPage Created---------:  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif

            MainPage = RootNavigation;
#if TRACE
            DualSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------DualSplashApp.cs - After Set Navigation SlowPage---------:  {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif

#if TRACE
            DualSplashApp.stopWatch.Stop();

            System.Diagnostics.Trace.WriteLine($"\n ---------------------------Reach End DualSplashApp Constructor MainPage=mainNav...... {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif



        }

    }
}
