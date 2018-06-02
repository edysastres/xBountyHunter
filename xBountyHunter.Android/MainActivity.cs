using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using FFImageLoading.Forms.Droid;

namespace xBountyHunter.Droid
{
    [Activity(Label = "xBountyHunter", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

            base.OnCreate(bundle);

            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new xBountyApp());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Canceled)
            {
                CameraAndroid.tcs.TrySetResult(null);
                return;
            }
            if (resultCode != Result.Ok)
            {
                CameraAndroid.tcs.TrySetException(new Exception("Error"));
                return;
            }

            string res = "";
            res = CameraAndroid.file.Path;
            CameraAndroid.tcs.SetResult(res);

            base.OnActivityResult(requestCode, resultCode, data);
            //CameraAndroid.OnResult(resultCode);
        }
    }
}

