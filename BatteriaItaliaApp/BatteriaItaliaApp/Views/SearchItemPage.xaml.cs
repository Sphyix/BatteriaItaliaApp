using BatteriaItaliaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BatteriaItaliaApp.Views
{
    
    public partial class SearchItemPage : ContentPage
    {
        SearchItemViewModel _searchViewModel;
        public SearchItemPage()
        {
            InitializeComponent();
            BindingContext = _searchViewModel = new SearchItemViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _searchViewModel.OnAppearing();
        }
    }
}