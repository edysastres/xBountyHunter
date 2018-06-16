using System;
using System.Collections.Generic;
using FFImageLoading.Forms;
using Xamarin.Forms;
using xBountyHunter.DependencyServices;

namespace xBountyHunter.Views
{
    public class capturarPage : ContentPage
    {
        private Models.mFugitivos Fugitivo = new Models.mFugitivos();
        private Extras.databaseManager DB = new Extras.databaseManager();
        private Image img;
        private CachedImage cImg;
        private Label fugitivoSuelto;
        private Button bcapturar;
        private Button beliminar;
        private StackLayout imageContainer1;
        private StackLayout imageContainer2;
        private Button bfoto;
        private StackLayout verticalStackLayout;

        private string imagePath;

        public capturarPage(Models.mFugitivos fugitivo)
        {
            Fugitivo.Name = fugitivo.Name;
            Fugitivo.ID = fugitivo.ID;

            fugitivoSuelto = new Label { Text = "El fugitivo sigue suelto .....", FontSize = 20, HorizontalOptions = LayoutOptions.Center };

            bcapturar = new Button { Text = "CAPTURAR", WidthRequest = 200, BorderColor = Color.Black, BorderWidth = 1, HorizontalOptions = LayoutOptions.Center, IsEnabled = false };
            beliminar = new Button { Text = "ELIMINAR", WidthRequest = 200, BorderColor = Color.Black, BorderWidth = 1, HorizontalOptions = LayoutOptions.Center };

            imageContainer1 = new StackLayout { Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.Center, WidthRequest = 100, HeightRequest = 100, BackgroundColor = Color.Gray };
            imageContainer2 = new StackLayout { Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.Center, WidthRequest = 100, HeightRequest = 100, BackgroundColor = Color.White };
            img = new Image { 
                Aspect = Aspect.Fill, 
                WidthRequest = 100, 
                HeightRequest = 100,
                //Source = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
            };
            cImg = new CachedImage() { 
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 300,
                HeightRequest = 300,
                CacheDuration = TimeSpan.FromDays(30),
                DownsampleToViewSize = true,
                Source = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
            };
            bfoto = new Button { Text = "Tomar Foto", HorizontalOptions = LayoutOptions.Center, WidthRequest = 200 };

            verticalStackLayout = new StackLayout { Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };

            bcapturar.Clicked += Bcapturar_Clicked;
            beliminar.Clicked += Beliminar_Clicked;
            bfoto.Clicked += Bfoto_Clicked;
            Title = Fugitivo.Name;

            imageContainer1.Children.Add(img);
            imageContainer2.Children.Add(cImg);

            verticalStackLayout.Children.Add(fugitivoSuelto);
            verticalStackLayout.Children.Add(imageContainer1);
            //verticalStackLayout.Children.Add(imageContainer2);
            verticalStackLayout.Children.Add(bfoto);
            verticalStackLayout.Children.Add(bcapturar);
            verticalStackLayout.Children.Add(beliminar);

            Content = verticalStackLayout;
        }

        private async void Bcapturar_Clicked(object sender, EventArgs e)
        {
            Extras.webServiceConnection ws = new Extras.webServiceConnection(this);

            string udid = DependencyService.Get<IUDID>().getUIDID();
            Dictionary<string, string> location = DependencyService.Get<IGetLocation>().getLocation();
            Fugitivo.Capturado = true;
            Fugitivo.Photo = imagePath;
            Fugitivo.Lat = location["Lat"];
            Fugitivo.Lon = location["Lon"];
            int result = DB.updateItem(Fugitivo);
            string message = await ws.connectPOST(udid);
            if (result == 1)
                await DisplayAlert("Capturado", "El fugitivo " + Fugitivo.Name + " ha sido capturado\n"+message, "Aceptar");
            else
                await DisplayAlert("Error", "Error al capturar fugitivo", "Aceptar");
            DB.closeConnection();
            MessagingCenter.Send<Page>(this, "Update");
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IGetLocation>().activarGPS();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DependencyService.Get<IGetLocation>().apagarGPS();
        }

        private async void Beliminar_Clicked(object sender, EventArgs e)
        {
            int result = DB.deleteItem(Fugitivo.ID);
            if (result == 1)
                await DisplayAlert("Eliminado", "El fugitivo " + Fugitivo.Name + " ha sido eliminado", "Aceptar");
            else
                await DisplayAlert("Error", "Error al borrar fugitivo", "Aceptar");
            DB.closeConnection();
            MessagingCenter.Send<Page>(this, "Update");
            await Navigation.PopAsync();
        }

        private async void Bfoto_Clicked(object sender, EventArgs e)
        {
            imagePath = await DependencyService.Get<DependencyServices.ICamera>().takePhoto();
            if (imagePath == "" || imagePath == "Cancel" || imagePath == null)
            {
                bcapturar.IsEnabled = true;
            }
            else
            {
                img.Source = ImageSource.FromFile(imagePath);
                cImg.Source = ImageSource.FromFile(imagePath);
                bcapturar.IsEnabled = true;
            }
        }

    }
}

