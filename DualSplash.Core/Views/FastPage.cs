using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DualSplash.Core.Views
{
    public class FastPage : SlowPage
    {
        public FastPage():base()
        {
            
        }

        protected override void OnAppearing()
        {

#if TRACE
            if (DualSplashApp.stopWatch == null) DualSplashApp.stopWatch = new Stopwatch();
            DualSplashApp.stopWatch.Stop();

            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SlowPage  --Reach OnAppearing() !!! .... {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();

#endif
        }

        public override async void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
#if TRACE
            DualSplashApp.stopWatch.Stop();

            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SlowPage Reach After Page Load - Switch_OnToggled() !!! .... {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();

#endif

            await Task.Yield();
        }
    }
}