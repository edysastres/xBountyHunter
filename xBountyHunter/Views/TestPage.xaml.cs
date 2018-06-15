using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using xBountyHunter.ViewModels;

namespace xBountyHunter.Views
{
    public partial class TestPage : ContentPage
    {
        TestPageViewModel _vm;

        public TestPage()
        {
            InitializeComponent();
            _vm = new TestPageViewModel(this);
            BindingContext = _vm;
        }

        async public void Handle_Clicked(object sender, EventArgs e)
        {
            var user = txtUser.Text;
            var pass = txtPassword.Text;

            if(string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                await DisplayAlert("Alerta", "Se necesita capturar las credenciales", "OK");
            } 
            else
            {
                if (await LoginUser(user, pass))
                {
                    await DisplayAlert("Alerta", "Bienvenido", "OK");
                }
                else
                {
                    await DisplayAlert("Alerta", "Error, usuio o contraseña invalidos", "OK");
                }
            }
        }

        async Task<bool> LoginUser(string user, string pass)
        {
            Loading.IsVisible = true;
            Loading.IsRunning = true;

            await Task.Delay(3000);

            Loading.IsVisible = false;
            Loading.IsRunning = false;

            return true;
        }

        public void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            _vm.TextchangedCommand.Execute(null);
        }
    }
}
