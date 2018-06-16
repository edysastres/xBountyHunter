using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xBountyHunter.NativeViews
{
    public partial class NativeSwitch : ContentPage
    {
        public NativeSwitch()
        {
            InitializeComponent();
            BindingContext = new NativeSwitchViewModel();
        }
    }
}
