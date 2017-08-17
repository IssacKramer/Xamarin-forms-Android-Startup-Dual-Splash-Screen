using System.Diagnostics;
using System.Threading.Tasks;
using ExDollar.Mobile.Core.Services.Utils;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

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

            System.Diagnostics.Trace.WriteLine($"\n ---------------------------FastPage  --Reach OnAppearing() !!! .... {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();

#endif
        }




        public override async void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
#if TRACE
            DualSplashApp.stopWatch.Stop();

            System.Diagnostics.Trace.WriteLine($"\n ---------------------------FastPage Reach After Page Load - Switch_OnToggled() !!! .... {DualSplashApp.stopWatch.Elapsed.TotalSeconds}");
            DualSplashApp.stopWatch.Start();

#endif

            await Task.Yield();

            this.BackgroundColor = Color.FromHex(Constants.WindowBackgroundColorDefault);
            vm._userDialogs.HideLoading();

        }
    }
}