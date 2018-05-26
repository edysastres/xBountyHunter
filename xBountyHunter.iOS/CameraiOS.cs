using System;
using UIKit;
using Foundation;
using System.IO;
using System.Threading.Tasks;
using xBountyHunter.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(CameraiOS))]
namespace xBountyHunter.iOS
{
    public class CameraiOS : DependencyServices.ICamera
    {
        public CameraiOS()
        {
        }

        public Task<string> takePhoto()
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
            Camera.TakePicture(UIApplication.SharedApplication.KeyWindow.RootViewController,
                   (imagePickerResult) =>
                   {
                       if (imagePickerResult == null)
                       {
                           tcs.TrySetResult(null);
                           return;
                       }
                       var photo = imagePickerResult.ValueForKey(new NSString("UIImagePickerControllerOriginalImage")) as UIImage;
                       var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                       String jpgFilename = Path.Combine(documentsDirectory, string.Format("fugitivo_{0}.jpg", Guid.NewGuid()));
                       NSData imgData = photo.AsJPEG();
                       NSError err = null;

                       if (imgData.Save(jpgFilename, false, out err))
                       {
                           string result = "";
                           result = jpgFilename;
                           tcs.TrySetResult(result);
                       }
                       else
                       {
                           tcs.TrySetException(new Exception(err.LocalizedDescription));
                       }

                   });
            return tcs.Task;
        }


        #region Camera Helper

        public static class Camera
        {
            static UIImagePickerController picker;
            static Action<NSDictionary> _callback;

            public static void TakePicture(UIViewController parent, Action<NSDictionary> callback)
            {
                Init();
                picker.SourceType = UIImagePickerControllerSourceType.Camera;
                _callback = callback;
                parent.PresentViewController((UIViewController)picker, true, (Action)null);
            }

            static void Init()
            {
                if (picker != null)
                    return;

                picker = new UIImagePickerController();
                picker.Delegate = new CameraDelegate();
            }

            class CameraDelegate : UIImagePickerControllerDelegate
            {
                public override void FinishedPickingMedia(UIImagePickerController picker, NSDictionary info)
                {
                    var cb = _callback;
                    _callback = null;

                    picker.DismissViewController(true, (Action)null);
                    cb(info);
                }

                public override void Canceled(UIImagePickerController picker)
                {
                    var cb = _callback;
                    _callback = null;

                    picker.DismissViewController(true, (Action)null);
                    cb(null);
                }
            }
        }

        #endregion
    }
}