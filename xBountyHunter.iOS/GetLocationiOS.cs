using System;
using System.Collections.Generic;
using CoreLocation;
using UIKit;
using xBountyHunter.DependencyServices;
using xBountyHunter.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(GetLocationiOS))]
namespace xBountyHunter.iOS
{
    public class GetLocationiOS : IGetLocation
    {
        private CLLocationManager locMgr;
        private Dictionary<string, string> loc;

        public GetLocationiOS()
        {
        }

        public Dictionary<string, string> getLocation()
        {
            return loc;
        }

        public void activarGPS()
        {
            try
            {
                this.locMgr = new CLLocationManager();
                this.locMgr.PausesLocationUpdatesAutomatically = false;
                if(UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
                {
                    locMgr.RequestAlwaysAuthorization();
                }
                if(UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
                {
                    locMgr.AllowsBackgroundLocationUpdates = true;
                }
                if(CLLocationManager.LocationServicesEnabled)
                {
                    locMgr.DesiredAccuracy = 1;
                    locMgr.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
                    {
                        loc = new Dictionary<string, string>();
                        loc.Add("Lat", e.Locations[e.Locations.Length - 1].Coordinate.Latitude.ToString());
                        loc.Add("Lon", e.Locations[e.Locations.Length - 1].Coordinate.Longitude.ToString());
                        System.Diagnostics.Debug.WriteLine("Detectando(Lat : " + loc["Lat"] + ", Lon : " + loc["Lon"] + ")");
                    };
                    locMgr.StartUpdatingLocation();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public void apagarGPS()
        {
            locMgr.StopUpdatingLocation();
        }
    }
}
