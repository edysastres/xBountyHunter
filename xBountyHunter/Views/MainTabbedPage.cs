using System;

using Xamarin.Forms;

namespace xBountyHunter.Views
{
    public class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
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

        public void btnAgregar_onClick()
        {
            Navigation.PushAsync(new Views.agregarFugitivo());
        }
    }
}

