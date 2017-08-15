using System.Diagnostics;
using DualSplash.Core.Views;
using Xamarin.Forms;

namespace DualSplash.Core
{

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class SingleSplashApp : Application
    {
        public static NavigationPage RootNavigation;
        public static Stopwatch stopWatch;

        public SingleSplashApp()
        {


          



#if TRACE

            SingleSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SingleSplashApp.cs - Start SingleSplashApp Constructor before SlowPage created---------:  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
            SingleSplashApp.stopWatch.Start();

#endif


            //var container = AppContainer.Container;
            var page1 = new SlowPage();
            //var dollarPage = container.Resolve<SlowPage>();
            RootNavigation = new NavigationPage(page1);
#if TRACE
            SingleSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SingleSplashApp.cs - After SlowPage Created---------:  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
            SingleSplashApp.stopWatch.Start();
#endif

            MainPage = RootNavigation;
#if TRACE
            SingleSplashApp.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SingleSplashApp.cs - After Set Navigation SlowPage---------:  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
            SingleSplashApp.stopWatch.Start();
#endif

#if TRACE
            SingleSplashApp.stopWatch.Stop();

            System.Diagnostics.Trace.WriteLine($"\n ---------------------------Reach End SingleSplashApp Constructor MainPage=mainNav...... {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
            SingleSplashApp.stopWatch.Start();
#endif



        }

        protected override void OnStart()
        {
            base.OnStart();

/*
#if DEBUG

            // AtrizA.Common.Utils.Utils.globalStopWatch = new Stopwatch();
            SingleSplashApp.stopWatch = new Stopwatch();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------Starting SingleSplashApp.OnStart :  {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
            SingleSplashApp.stopWatch.Start();
            //AtrizA.Common.Utils.Utils.globalStopWatch.Start();

#endif
*/


        }
    }
}
