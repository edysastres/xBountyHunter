using System;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using xBountyHunter.CustomRenders;
using xBountyHunter.Droid.CustomRenders;

[assembly: ExportRenderer(typeof(EntryCustomRender), typeof(EntryCustomRenderDroid))]
namespace xBountyHunter.Droid.CustomRenders
{
    public class EntryCustomRenderDroid : EntryRenderer
    {   
        public EntryCustomRenderDroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.LightGray);
            }
        }

    }
}
