namespace DualSplash.Core.ViewModels
{
    public class SlowPageViewModel :MvvmHelpers.BaseViewModel
    {
        private bool _toggglePageLoadSwitch;

        public SlowPageViewModel()
        {

        }

        public bool ToggglePageLoadSwitch
        {
            get { return _toggglePageLoadSwitch; }
            set => SetProperty(ref _toggglePageLoadSwitch, value);
        }

   /*     public async void Switch_OnToggled(object sender, ToggledEventArgs e)
        {

#if DEBUG
            SingleSplashApp.stopWatch.Stop();

            System.Diagnostics.Debug.WriteLine("\n ---------------------------Reach After Page Load - Switch_OnToggled() !!! .... {0} ", SingleSplashApp.stopWatch.Elapsed.TotalSeconds);
            SingleSplashApp.stopWatch.Start();

#endif

            await Task.Yield();

        }*/
    }
}
