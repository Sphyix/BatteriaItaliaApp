using BatteriaItaliaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BatteriaItaliaApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {

        public string NomeVisible { get => nomeVisible; set => SetProperty(ref nomeVisible, value); }
        private string nomeVisible = "true";

        public string TelefonoVisible { get => nomeVisible; set => SetProperty(ref telefonoVisible, value); }
        private string telefonoVisible = "true";

        public string CognomeVisible { get => nomeVisible; set => SetProperty(ref cognomeVisible, value); }
        private string cognomeVisible = "true";

        public string SalvaBtnText { get => salvaBtnText; set => SetProperty(ref salvaBtnText, value); }
        private string salvaBtnText = "Avanti";

        public string TipoOggettoVisible { get => tipoOggettoVisible; set => SetProperty(ref tipoOggettoVisible, value); }
        private string tipoOggettoVisible = "false";

        public string DifficoltaVisible { get => difficoltaVisible; set => SetProperty(ref difficoltaVisible, value); }
        private string difficoltaVisible = "false";



        public string Nome { get => nome; set => SetProperty(ref nome, value); }
        private string nome;

        public string Cognome { get => cognome; set => SetProperty(ref cognome, value); }
        private string cognome;

        public string Telefono { get => telefono; set => SetProperty(ref telefono, value); }
        private string telefono;

        public string TipoOggetto { get => tipoOggetto; set => SetProperty(ref tipoOggetto, value); }
        private string tipoOggetto;

        public string Difficolta { get => difficolta; set => SetProperty(ref difficolta, value); }
        private string difficolta;

        public List<string> Difficoltas
        {
            get
            {
                return Enum.GetNames(typeof(Enums.Difficolta)).ToList();
            }
        }

        private int steps = 0;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private void ResetToUpdate()
        {
            NomeVisible = "false";
            CognomeVisible = "false";
            TelefonoVisible = "false";

            TipoOggettoVisible = "false";
            DifficoltaVisible = "false";


        }

        private void UpdateView()
        {
            ResetToUpdate();
            switch (steps)
            {
                case 0:
                    NomeVisible = "true";
                    CognomeVisible = "true";
                    TelefonoVisible = "true";
                    break;
                case 1:
                    TipoOggettoVisible = "true";
                    DifficoltaVisible = "true";
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }

        private bool ValidateStep()
        {
            switch (steps)
            {
                case 0:
                    if (String.IsNullOrWhiteSpace(nome)
                        || String.IsNullOrWhiteSpace(cognome)
                        || String.IsNullOrWhiteSpace(telefono))
                        return false;
                    return true;
                case 1:
                    if (String.IsNullOrWhiteSpace(tipoOggetto)
                        || String.IsNullOrWhiteSpace(difficolta))
                        return false;
                    return true;
                case 2:
                    return true;
                default:
                    return false;
            }
            
        }

        private async void OnSave()
        {
            if(steps == 3) //save step
            {
                WorkOrder newItem = new WorkOrder()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = Nome,
                    Cognome = Cognome,
                    Telefono = Telefono,
                    TipoOggetto = TipoOggetto,
                    Difficolta = (Enums.Difficolta) Enum.Parse(typeof(Enums.Difficolta), Difficolta),
                };

                await DataStore.AddItemAsync(newItem);

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                if (!ValidateStep())
                    return;
                else
                {
                    steps++;
                    UpdateView();
                }
            }

        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            if (steps == 0)
                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");
            else
            {
                steps--;
                UpdateView();
            }
        }
    }
}
