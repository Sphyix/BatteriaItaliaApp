using BatteriaItaliaApp.ViewModels;
using BatteriaItaliaApp.Views;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace BatteriaItaliaApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(SearchItemPage), typeof(SearchItemPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            GetTabBarDisabledColor

        }

        public string PreventivoVisibile { get => nomeVisible; set => SetProperty(ref nomeVisible, value); }
        private string nomeVisible = "false";

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

    }
}
