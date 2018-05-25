using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xBountyHunter.Views
{
    public partial class capturadosPage : ContentPage
    {
        public capturadosPage()
        {
            InitializeComponent();
            Extras.listaFugitivos listaFugitivos = new Extras.listaFugitivos();
            List<Models.mFugitivos> capturados = listaFugitivos.ocFugitivos;
            MessagingCenter.Subscribe<Page>(this, "Update", messageCallback);
            list.ItemsSource = listaFugitivos.selectCaptured();
        }

        private void messageCallback(Page obj)
        {
            Extras.listaFugitivos listaFugitivos = new Extras.listaFugitivos();
            list.ItemsSource = listaFugitivos.selectCaptured();
        }

        public void listItemTapped_Tapped(object sender, ItemTappedEventArgs args)
        {
            Models.mFugitivos fugitivo = (Models.mFugitivos)args.Item;
            Navigation.PushAsync(new Views.detallePage(fugitivo));
        }
    }
}
