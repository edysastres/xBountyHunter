using System;

using Xamarin.Forms;

namespace xBountyHunter.Views
{
    public class capturarPage : ContentPage
    {
        private Models.mFugitivos Fugitivo = new Models.mFugitivos();
        private Extras.databaseManager DB = new Extras.databaseManager();
        private Label fugitivoSuelto;
        private Button bcapturar;
        private Button beliminar;
        private StackLayout verticalStackLayout;

        public capturarPage(Models.mFugitivos fugitivo)
        {
            Fugitivo.Name = fugitivo.Name;
            Fugitivo.ID = fugitivo.ID;

            fugitivoSuelto = new Label { Text = "El fugitivo sigue suelto .....", FontSize = 20, HorizontalOptions = LayoutOptions.Center };

            bcapturar = new Button { Text = "CAPTURAR", WidthRequest = 200, BorderColor = Color.Black, BorderWidth = 1, HorizontalOptions = LayoutOptions.Center };
            beliminar = new Button { Text = "ELIMINAR", WidthRequest = 200, BorderColor = Color.Black, BorderWidth = 1, HorizontalOptions = LayoutOptions.Center };

            verticalStackLayout = new StackLayout { Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };

            bcapturar.Clicked += Bcapturar_Clicked;
            beliminar.Clicked += Beliminar_Clicked;
            Title = Fugitivo.Name;

            verticalStackLayout.Children.Add(fugitivoSuelto);
            verticalStackLayout.Children.Add(bcapturar);
            verticalStackLayout.Children.Add(beliminar);

            Content = verticalStackLayout;
        }

        private async void Bcapturar_Clicked(object sender, EventArgs e)
        {
            Fugitivo.Capturado = true;
            int result = DB.updateItem(Fugitivo);
            if (result == 1)
                await DisplayAlert("Capturado", "El fugitivo " + Fugitivo.Name + " ha sido capturado", "Aceptar");
            else
                await DisplayAlert("Error", "Error al capturar fugitivo", "Aceptar");
            DB.closeConnection();
            MessagingCenter.Send<Page>(this, "Update");
            await Navigation.PopAsync();
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
    }
}

