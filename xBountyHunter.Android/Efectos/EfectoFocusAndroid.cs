using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using xBountyHunter.Droid.Efectos;
using static Java.Util.ResourceBundle;

[assembly: ResolutionGroupName("xBountyHunter")]
[assembly: ExportEffect(typeof(EfectoFocusAndroid), "FocusEffect")]
namespace xBountyHunter.Droid.Efectos
{
    public class EfectoFocusAndroid : PlatformEffect
    {
        Android.Graphics.Color backgroundColor;

        protected override void OnAttached()
        {
            try
            {
                backgroundColor = Android.Graphics.Color.LightGreen;
                Control.SetBackgroundColor(backgroundColor);
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("Error: {0}", ex.Message));
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if(args.PropertyName == "IsFocused")
                {
                    if(((Android.Graphics.Drawables.ColorDrawable)Control.Background).Color == backgroundColor)
                    {
                        Control.SetBackgroundColor(Android.Graphics.Color.Aqua);
                    }
                    else
                    {
                        Control.SetBackgroundColor(backgroundColor);    
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("Error: {0}", ex.Message));
            }
        }

        public EfectoFocusAndroid()
        {
        }
    }
}
