using System.Diagnostics;
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
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SingleSplashApp.cs - Start SingleSplashApp Constructor before SlowPage created---------:  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();

#endif


            //var container = AppContainer.Container;
            var page1 = new SlowPage();
            //var dollarPage = container.Resolve<SlowPage>();
            RootNavigation = new NavigationPage(page1);
#if TRACE
            DualSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SingleSplashApp.cs - After SlowPage Created---------:  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif

            MainPage = RootNavigation;
#if TRACE
            DualSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SingleSplashApp.cs - After Set Navigation SlowPage---------:  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif

#if TRACE
            DualSplashApp.stopWatch.Stop();

            System.Diagnostics.Trace.WriteLine($"\n ---------------------------Reach End SingleSplashApp Constructor MainPage=mainNav...... {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();
#endif



        }

    }
}
