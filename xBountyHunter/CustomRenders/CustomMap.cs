using System;
using Xamarin.Forms.Maps;

namespace xBountyHunter.CustomRenders
{
    public class CustomMap : Map
    {
        public MapCircle circle { get; set; }

        public CustomMap(MapSpan span)
        {
            new Map(span);
        }
    }
}
