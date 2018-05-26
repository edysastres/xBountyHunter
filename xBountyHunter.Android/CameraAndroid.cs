using System;
using xBountyHunter.Droid;
using Xamarin.Forms;
using Java.IO;
using Android.Provider;
using System.Threading.Tasks;
using Android.Content;
using Android.App;

[assembly:Xamarin.Forms.Dependency(typeof(CameraAndroid))]
namespace xBountyHunter.Droid
{
    public class CameraAndroid : DependencyServices.ICamera
    {
        public static File file;
        public static File pictureDirectory;
        public static TaskCompletionSource<string> tcs;

        public CameraAndroid()
        {
            
        }

        Task<string> DependencyServices.ICamera.takePhoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            pictureDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "CameraAppDemo");

            if (!pictureDirectory.Exists())
            {
                pictureDirectory.Mkdirs();
            }

            file = new File(pictureDirectory, string.Format("fugitivo_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(file));
            var activity = (Activity)Forms.Context;
            activity.StartActivityForResult(intent, 0);
            tcs = new TaskCompletionSource<string>();
            return tcs.Task;
        }

        public static void OnResult(Result resultCode)
        {
            if(resultCode == Result.Canceled)
            {
                tcs.TrySetResult(null);
                return;
            }
            if(resultCode != Result.Ok)
            {
                tcs.TrySetException(new Exception("Unexpected error"));
                return;
            }
            string res = "";
            res = file.Path;
            tcs.TrySetResult(res);
        }
    }
}
