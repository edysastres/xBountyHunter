using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using xBountyHunter.CustomRenders;
using xBountyHunter.iOS.CustomRenders;

[assembly: ExportRenderer(typeof(EntryCustomRender), typeof(EntryCustomRenderiOS))]
namespace xBountyHunter.iOS.CustomRenders
{
    public class EntryCustomRenderiOS : EntryRenderer
    {
        public EntryCustomRenderiOS()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BackgroundColor = UIColor.FromRGB(204, 153, 255);
                Control.BorderStyle = UITextBorderStyle.Line;
            }
        }
    }
}
