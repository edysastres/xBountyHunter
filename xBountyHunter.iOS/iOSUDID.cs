using System;
using UIKit;
using xBountyHunter.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(iOSUDID))]
namespace xBountyHunter.iOS
{
    public class iOSUDID : DependencyServices.IUDID
    {
        public iOSUDID()
        {
        }

        public string getUIDID()
        {
            return UIDevice.CurrentDevice.IdentifierForVendor.AsString();
        }
    }
}
