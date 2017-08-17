using Acr.UserDialogs;

namespace DualSplash.Core.ViewModels
{
    public class SlowPageViewModel :MvvmHelpers.BaseViewModel
    {
        private bool _toggglePageLoadSwitch;
        public IUserDialogs _userDialogs;
        public SlowPageViewModel(IUserDialogs userDialogs)
        {
            _userDialogs = userDialogs;
        }

        public bool ToggglePageLoadSwitch
        {
            get { return _toggglePageLoadSwitch; }
            set => SetProperty(ref _toggglePageLoadSwitch, value);
        }

  
    }
}
