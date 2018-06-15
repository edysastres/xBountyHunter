using System;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;
using xBountyHunter.CustomRenders;
using xBountyHunter.iOS.CustomRenders;
using ObjCRuntime;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapiOS))]
namespace xBountyHunter.iOS.CustomRenders
{
    public class CustomMapiOS : MapRenderer
    {
        MKCircleRenderer circleRenderer;

        public CustomMapiOS()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement != null)
            {
                var nativeMap = Control as MKMapView;
                if(nativeMap != null)
                {
                    nativeMap.RemoveOverlays(nativeMap.Overlays);
                    nativeMap.OverlayRenderer = null;
                    circleRenderer = null;
                }
            }
        }

        MKOverlayRenderer GetOverlayRenderer(MKMapView mapView, IMKOverlay overlayWrapper)
        {
            if(circleRenderer == null && !Equals(overlayWrapper, null))
            {
                var overlay = Runtime.GetNSObject(overlayWrapper.Handle) as IMKOverlay;
                circleRenderer = new MKCircleRenderer(overlay as MKCircle)
                {
                    FillColor = UIColor.Red,
                    Alpha = 0.4f
                };
            }
            return circleRenderer;
        }
    }
}
