using System;

using Xamarin.Forms;

namespace xBountyHunter.Views
{
    public class fugitivosPage : ContentPage
    {
        private ListView list = new ListView();

        public fugitivosPage()
        {
            Title = "Fugitivos";
            Extras.listaFugitivos listaFugitivos = new Extras.listaFugitivos();
            MessagingCenter.Subscribe<Page>(this, "Update", messageCallback);
            list.ItemsSource = listaFugitivos.selectNoCaptured();
            list.ItemTemplate = new DataTemplate(typeof(ListViewCell));
            list.ItemTapped += listItemTapped_Tapped;
            Content = list;
        }

        private void messageCallback(Page obj)
        {
            Extras.listaFugitivos listaFugitivos = new Extras.listaFugitivos();
            list.ItemsSource = listaFugitivos.selectNoCaptured();
        }

        public void listItemTapped_Tapped(object sender, ItemTappedEventArgs args)
        {
            Models.mFugitivos fugitivo = (Models.mFugitivos)args.Item;
            Navigation.PushAsync(new Views.capturarPage(fugitivo));
        }
    }
}

