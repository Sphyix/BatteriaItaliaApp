using BatteriaItaliaApp.Models;
using BatteriaItaliaApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BatteriaItaliaApp.ViewModels
{
    public class SearchItemViewModel : BaseViewModel
    {
        private WorkOrder _selectedItem;

        public Command SearchCommand { get; }

        public ObservableCollection<WorkOrder> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<WorkOrder> ItemTapped { get; }
        public SearchItemViewModel()
        {
            Title = "Cerca";
            Items = new ObservableCollection<WorkOrder>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemCommand("2"));//TODO id in input da utente

            ItemTapped = new Command<WorkOrder>(OnItemSelected);
            SearchCommand = new Command(OnSearchItem);

        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public WorkOrder SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnSearchItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async Task ExecuteLoadItemCommand(string id)
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var item = await DataStore.GetItemAsync(id);
                Items.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async void OnItemSelected(WorkOrder item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
