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

  
    }
}
