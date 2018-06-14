using System;
using xBountyHunter.ViewModels;
using Xamarin.Forms;

namespace xBountyHunter.Views
{
    public class fugitivosPage : ContentPage
    {
        private ListView list = new ListView();
        fugitivosVm _vm;

        public fugitivosPage()
        {
            Title = "Fugitivos";
            Extras.listaFugitivos listaFugitivos = new Extras.listaFugitivos();
            MessagingCenter.Subscribe<Page>(this, "Update", messageCallback);

            _vm = new fugitivosVm();

            list.ItemsSource = listaFugitivos.selectNoCaptured();
            list.ItemTemplate = new DataTemplate(typeof(ListViewCell));
            list.ItemTapped += listItemTapped_Tapped;
            Content = list;

            //Avanzado timer y begininvokeonmainthread
            Device.StartTimer(new TimeSpan(0, 0, 5), () =>
            {
                try
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        list.ItemsSource = listaFugitivos.selectNoCaptured();
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
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

