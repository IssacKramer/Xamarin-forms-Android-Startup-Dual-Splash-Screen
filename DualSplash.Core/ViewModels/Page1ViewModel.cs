namespace DualSplash.Core.ViewModels
{
    public class Page1ViewModel :MvvmHelpers.BaseViewModel
    {
        private bool _toggglePageLoadSwitch;

        public Page1ViewModel()
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
            App.stopWatch.Stop();

            System.Diagnostics.Debug.WriteLine("\n ---------------------------Reach After Page Load - Switch_OnToggled() !!! .... {0} ", App.stopWatch.Elapsed.TotalSeconds);
            App.stopWatch.Start();

#endif

            await Task.Yield();

        }*/
    }
}
