using System.Threading.Tasks;
using ExDollar.Test.Vanilla.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ExDollar.Test.Vanilla.Core.Views
{
	
	public partial class Page1 : ContentPage
	{
	    private Page1ViewModel vm;
		public Page1 ()
		{
			InitializeComponent ();
            vm=new Page1ViewModel();
		    BindingContext = vm;
		    vm.ToggglePageLoadSwitch = true;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

#if TRACE
            App.stopWatch.Stop();

            System.Diagnostics.Trace.WriteLine($"\n ---------------------------Page1  --Reach OnAppearing() !!! .... {App.stopWatch.Elapsed.TotalSeconds}") ;
            App.stopWatch.Start();

#endif

        }




	    public async void Switch_OnToggled(object sender, ToggledEventArgs e)
	    {

#if TRACE
            App.stopWatch.Stop();

	        System.Diagnostics.Trace.WriteLine($"\n ---------------------------Page1 Reach After Page Load - Switch_OnToggled() !!! .... {App.stopWatch.Elapsed.TotalSeconds}");
	        App.stopWatch.Start();

#endif

	        await Task.Yield();

	    }
    }
}