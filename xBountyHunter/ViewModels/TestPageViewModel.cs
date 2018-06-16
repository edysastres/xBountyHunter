using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using xBountyHunter.ViewModels;

namespace xBountyHunter.ViewModels
{
    public class TestPageViewModel : BaseViewModel
    {
        ContentPage PageReference { get; set; }
        public Command LoginCommand { get; set; }
        public Command TextchangedCommand { get; set; }

        string _userName;
        string _password;
        bool _loadingButtonIsEnable;

        public string UserName
        {
            get 
            {
                return _userName;    
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public bool LoginButtonIsEnable
        {
            get
            {
                return _loadingButtonIsEnable;
            }
            set 
            {
                _loadingButtonIsEnable = value;
                OnPropertyChanged(nameof(LoginButtonIsEnable));
            }
        }

        public TestPageViewModel(ContentPage pageReference)
        {
            PageReference = pageReference;
            LoginCommand = new Command(async () => await ExecuteLoginCommand(), () => LoginButtonIsEnable);
            TextchangedCommand = new Command(ExecuteTextchangedCommand);
        }

        private void ExecuteTextchangedCommand(object obj)
        {
            LoginButtonIsEnable = (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password));
        }

        async Task ExecuteLoginCommand()
        {
            if (string.IsNullOrEmpty(_userName) || string.IsNullOrEmpty(_password))
            {
                await PageReference.DisplayAlert("Alerta", "Se necesita capturar las credenciales", "OK");
            }
            else
            {
                if (await LoginUser(_userName, _password))
                {
                    await PageReference.DisplayAlert("Alerta", "Bienvenido", "OK");
                }
                else
                {
                    await PageReference.DisplayAlert("Alerta", "Error, usuio o contraseña invalidos", "OK");
                }
            }
        }

        async Task<bool> LoginUser(string user, string pass)
        {
            IsBusy = true;
            await Task.Delay(3000);
            IsBusy = false;

            return true;
        }
    }
}

