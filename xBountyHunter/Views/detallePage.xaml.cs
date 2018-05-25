using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xBountyHunter.Views
{
    public partial class detallePage : ContentPage
    {
        Models.mFugitivos Fugitivo = new Models.mFugitivos();
        Extras.databaseManager DB = new Extras.databaseManager();

        public detallePage(Models.mFugitivos fugitivo)
        {
            InitializeComponent();
            Fugitivo = fugitivo;
            Title = Fugitivo.Name;
        }

        public async void beliminar_Clicked(object sender, EventArgs args)
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
