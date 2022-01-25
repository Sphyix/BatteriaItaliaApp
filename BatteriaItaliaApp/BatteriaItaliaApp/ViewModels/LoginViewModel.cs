using BatteriaItaliaApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using static BatteriaItaliaApp.Models.Enums;

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
            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password))
            {
                ShowError(Errors.EmptyBoth);
                return;
            }
            else if (string.IsNullOrEmpty(Username))
            {
                ShowError(Errors.EmptyUser);
                return;
            } 
            else if (string.IsNullOrEmpty(Password)){
                ShowError(Errors.EmptyPsw);
                return;
            }
            else
            {
                var user = Username.ToLowerInvariant();
                var psw = Password.ToLowerInvariant();
                //Do Login
                if (true) //Login true 
                {
                    await Shell.Current.GoToAsync($"//{nameof(TestHomePage)}");
                }
            }


            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void ShowError(Errors error)
        {
            switch (error)
            {
                case Errors.EmptyUser:
                    await App.Current.MainPage.DisplayAlert("Autenticazione Fallita", "Inserire un username valido", "OK");
                    break;
                case Errors.EmptyPsw:
                    await App.Current.MainPage.DisplayAlert("Autenticazione Fallita", "Inserire una password valida", "OK");
                    break;
                case Errors.EmptyBoth:
                    await App.Current.MainPage.DisplayAlert("Autenticazione Fallita", "Inserire username e password", "OK");
                    break;
                case Errors.WrongLogin:
                    await App.Current.MainPage.DisplayAlert("Autenticazione Fallita", "Username o password sono errati", "OK");
                    break;
                default:
                    await App.Current.MainPage.DisplayAlert("Autenticazione Fallita", "Errore durante il login, riprovare piu tardi", "OK");
                    break;
            }
                
        }
    }
}
