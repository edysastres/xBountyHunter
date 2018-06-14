using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xBountyHunter.Views
{
    public class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            //Avanzado Timers
            //updateBD();

            ToolbarItem btnAgregar = new ToolbarItem("AGREGAR", "", btnAgregar_onClick);
            ToolbarItems.Add(btnAgregar);
            Title = "X Bountry Hunter";
            if (Device.RuntimePlatform == Device.iOS)
            {
                Padding = new Thickness(0, 20, 0, 0);    
            }
            Children.Add(new fugitivosPage());
            Children.Add(new capturadosPage());
            Children.Add(new acercaDePage());
        }

        public async void btnAgregar_onClick()
        {
           await Navigation.PushAsync(new agregarFugitivo());
        }

        private async Task updateBDAsync()
        {
            Extras.webServiceConnection ws = new Extras.webServiceConnection(this);
            await ws.connectGET();
        }
    }
}

