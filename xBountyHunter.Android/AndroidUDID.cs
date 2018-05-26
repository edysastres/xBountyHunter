using System;
using Xamarin.Forms;
using Android.Content;
using Android.Telephony;
using xBountyHunter.Droid;

[assembly:Xamarin.Forms.Dependency(typeof(AndroidUDID))]
namespace xBountyHunter.Droid
{
    public class AndroidUDID : DependencyServices.IUDID
    {
        public string getUIDID()
        {
            //Context cnt = Android.App.Application.Context;
            //TelephonyManager tm = (TelephonyManager)cnt.GetSystemService(Context.TelephonyService);
            //return tm.Imei;
            return string.Empty;
        }

        public AndroidUDID()
        {
			
        }
    }
}
