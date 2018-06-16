using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using xBountyHunter.ViewModels;

namespace xBountyHunter.NativeViews
{
    public class NativeSwitchViewModel : BaseViewModel
    {
        bool _isSwitchOn;

        public bool IsSwitchOn
        {
            get
            {
                return _isSwitchOn;
            }
            set
            {
                if(_isSwitchOn != value)
                {
                    _isSwitchOn = value;
                    OnPropertyChanged(nameof(IsSwitchOn));
                }    
            }
        }

        public NativeSwitchViewModel()
        {
        }
    }
}
