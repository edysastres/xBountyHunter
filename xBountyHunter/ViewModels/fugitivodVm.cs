using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using xBountyHunter.Extras;

namespace xBountyHunter.ViewModels
{
    public class fugitivosVm : BaseViewModel
    {
        public fugitivosVm()
        {
            Device.StartTimer(new TimeSpan(0, 0, 5), () =>
            {
                try
                {
                    Task.Run( async () => {
                        webServiceConnection webService = new webServiceConnection(Application.Current.MainPage);
                        await webService.connectGET();
                    });
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                    return false;
                }
            });
        }
    }
}
