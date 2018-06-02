using System;
using System.Collections.Generic;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Content;
using xBountyHunter.DependencyServices;
using xBountyHunter.Droid;

[assembly:Xamarin.Forms.Dependency(typeof(GetLocationAndroid))]
namespace xBountyHunter.Droid
{
    public class GetLocationAndroid : Java.Lang.Object, IGetLocation, ILocationListener
    {
        private LocationManager locationManager;
        private Dictionary<string, string> loc;

        public GetLocationAndroid()
        {
			
        }

        public Dictionary<string, string> getLocation()
        {
            return loc;
        }

        public void OnLocationChanged(Location location)
        {
            newLocation(location);
        }

        private void newLocation(Location location)
        {
            loc = new Dictionary<string, string>();
            loc.Add("Lat", location.Latitude.ToString());
            loc.Add("Lon", location.Longitude.ToString());
            System.Diagnostics.Debug.WriteLine("Detectando(Lat : " + loc["Lat"] + ", Lon : " + loc["Lon"] + ")");
        }

        public void activarGPS()
        {
            try
            {
                Context cnt = Android.App.Application.Context;
                locationManager = cnt.GetSystemService(Context.LocationService) as LocationManager;
                locationManager.RequestLocationUpdates(LocationManager.GpsProvider, 0, 0, this);
                System.Diagnostics.Debug.WriteLine("Activando GPS");

                Criteria criteria = new Criteria();
                criteria.Accuracy = Accuracy.Fine;
                string provider = locationManager.GetBestProvider(criteria, true);
                Location location = locationManager.GetLastKnownLocation(provider);
                if (location != null)
                {
                    newLocation(location);
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public void apagarGPS()
        {

            if(locationManager != null)
            {
                try
                {
                    locationManager.RemoveUpdates(this);
                    System.Diagnostics.Debug.WriteLine("Desactivando GPS.......");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

        }

        public void OnProviderDisabled(string provider)
        {
            return;
        }

        public void OnProviderEnabled(string provider)
        {
            return;
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            return;
        }
    }
}
