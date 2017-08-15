using System.Diagnostics;
using DualSplash.Core.Views;
using Xamarin.Forms;

namespace DualSplash.Core
{

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class App : Application
    {
        public static NavigationPage RootNavigation;
        public static Stopwatch stopWatch;

        public App()
        {


            //            LocalizationService.SetLocale();


            //            var netLanguage = DependencyService.Get<ILocale>().GetCurrent();


            /* if (Device.OS != TargetPlatform.Windows)
             {
                 AppResources.Culture = new CultureInfo(netLanguage);
             }*/



#if TRACE

            App.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------App.cs - Start App Constructor before SlowPage created---------:  {App.stopWatch.Elapsed.TotalSeconds}");
            App.stopWatch.Start();

#endif


            //var container = AppContainer.Container;
            var page1 = new SlowPage();
            //var dollarPage = container.Resolve<SlowPage>();
            RootNavigation = new NavigationPage(page1);
#if TRACE
            App.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------App.cs - After SlowPage Created---------:  {App.stopWatch.Elapsed.TotalSeconds}");
            App.stopWatch.Start();
#endif

            MainPage = RootNavigation;
#if TRACE
            App.stopWatch.Stop();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------App.cs - After Set Navigation SlowPage---------:  {App.stopWatch.Elapsed.TotalSeconds}");
            App.stopWatch.Start();
#endif

#if TRACE
            App.stopWatch.Stop();

            System.Diagnostics.Trace.WriteLine($"\n ---------------------------Reach End App Constructor MainPage=mainNav...... {App.stopWatch.Elapsed.TotalSeconds}");
            App.stopWatch.Start();
#endif



        }

        protected override void OnStart()
        {
            base.OnStart();

/*
#if DEBUG

            // AtrizA.Common.Utils.Utils.globalStopWatch = new Stopwatch();
            App.stopWatch = new Stopwatch();
            System.Diagnostics.Trace.WriteLine($"\n ---------------------------Starting App.OnStart :  {App.stopWatch.Elapsed.TotalSeconds}");
            App.stopWatch.Start();
            //AtrizA.Common.Utils.Utils.globalStopWatch.Start();

#endif
*/


        }
    }
}
