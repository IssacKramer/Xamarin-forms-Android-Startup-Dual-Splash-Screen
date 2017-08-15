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
	    private SlowPageViewModel vm;
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
            if(App.stopWatch==null) App.stopWatch=new Stopwatch();
            App.stopWatch.Stop();

            System.Diagnostics.Trace.WriteLine($"\n ---------------------------SlowPage  --Reach OnAppearing() !!! .... {App.stopWatch.Elapsed.TotalSeconds}") ;
            App.stopWatch.Start();

#endif

        }




	    public async void Switch_OnToggled(object sender, ToggledEventArgs e)
	    {

#if TRACE
            App.stopWatch.Stop();

	        System.Diagnostics.Trace.WriteLine($"\n ---------------------------SlowPage Reach After Page Load - Switch_OnToggled() !!! .... {App.stopWatch.Elapsed.TotalSeconds}");
	        App.stopWatch.Start();

#endif

	        await Task.Yield();

	    }
    }
}