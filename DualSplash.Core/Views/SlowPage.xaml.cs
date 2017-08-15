using System.Diagnostics;
using System.Threading.Tasks;
using DualSplash.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DualSplash.Core.Views
{

	
	public partial class SlowPage : ContentPage
	{
	    protected SlowPageViewModel vm;
		public SlowPage ()
		{
			InitializeComponent ();
            vm=new SlowPageViewModel();
		    BindingContext = vm;
		    vm.ToggglePageLoadSwitch = true;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

#if TRACE
            if(SingleSplashApp.stopWatch==null) SingleSplashApp.stopWatch=new Stopwatch();
            SingleSplashApp.stopWatch.Stop();

            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SlowPage  --Reach OnAppearing() !!! .... {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}") ;
            SingleSplashApp.stopWatch.Start();

#endif

        }




	    public virtual async void Switch_OnToggled(object sender, ToggledEventArgs e)
	    {

#if TRACE
            SingleSplashApp.stopWatch.Stop();

	        System.Diagnostics.Trace.WriteLine($"\n ---------------------------SlowPage Reach After Page Load - Switch_OnToggled() !!! .... {SingleSplashApp.stopWatch.Elapsed.TotalSeconds}");
	        SingleSplashApp.stopWatch.Start();

#endif

	        await Task.Yield();

	    }
    }
}