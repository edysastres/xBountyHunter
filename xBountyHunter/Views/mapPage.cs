using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using xBountyHunter.CustomRenders;

namespace xBountyHunter.Views
{
    public class mapPage : ContentPage
    {
        public mapPage(Models.mFugitivos fugitivo)
        {
            double lat = Convert.ToDouble(fugitivo.Lat);
            double lon = Convert.ToDouble(fugitivo.Lon);
            Position pos = new Position(lat, lon);
            MapSpan span = MapSpan.FromCenterAndRadius(pos, Distance.FromKilometers(1));
            //Map capturadoMap = new Map(span);
            CustomMap capturadoMap = new CustomMap(span);
            capturadoMap.MapType = MapType.Street;
            capturadoMap.IsShowingUser = false;
            Pin pin = new Pin();
            pin.Type = PinType.Place;
            pin.Position = pos;
            pin.Label = fugitivo.Name;
            capturadoMap.Pins.Add(pin);
            capturadoMap.circle = new MapCircle { Position = pos, Radius = 10000 };

            StackLayout verticalStackLayout = new StackLayout 
            { 
                Orientation = StackOrientation.Vertical, 
                VerticalOptions = LayoutOptions.FillAndExpand, 
                HorizontalOptions = LayoutOptions.FillAndExpand 
            };

            verticalStackLayout.Children.Add(capturadoMap);

            Content = verticalStackLayout;
        }
    }
}
