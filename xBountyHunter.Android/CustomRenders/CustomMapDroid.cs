using System;
using System.ComponentModel;
using Android.Content;
using Android.Gms.Maps.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;
using xBountyHunter.CustomRenders;
using xBountyHunter.Droid.CustomRenders;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapDroid))]
namespace xBountyHunter.Droid.CustomRenders
{
    public class CustomMapDroid : MapRenderer
    {
        public CustomMapDroid(Context context) : base(context)
        {
        }

        MapCircle circle;
        bool isDrawn;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement != null)
            {
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                circle = formsMap.circle;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
            {
                var circleOptions = new CircleOptions();
                circleOptions.InvokeCenter(new LatLng(circle.Position.Latitude, circle.Position.Longitude));
                circleOptions.InvokeRadius(circle.Radius);
                circleOptions.InvokeFillColor(0X66FF0000);
                circleOptions.InvokeStrokeColor(0X66FF0000);
                circleOptions.InvokeStrokeWidth(0);

                NativeMap.AddCircle(circleOptions);
                isDrawn = true;
            }
        }
    }
}
