using BatteriaItaliaApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace BatteriaItaliaApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Command LoginCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        string _username;
        string _password;

        

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        public string Username
        {
            get => _username;
            set
            {
                if (value == _username) return;
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private async void OnLoginClicked(object obj)
        {
            var user = Username.ToLowerInvariant();
            var psw = Password.ToLowerInvariant();
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(psw))
            {
                ShowError();
                return;
            }

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void ShowError()
        {
            await App.Current.MainPage.DisplayAlert("Autenticazione Fallita", "Username o password sono errati", "OK");
        }
    }
}
