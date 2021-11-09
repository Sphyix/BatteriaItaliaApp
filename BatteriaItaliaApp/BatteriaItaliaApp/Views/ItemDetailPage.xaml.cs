using BatteriaItaliaApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BatteriaItaliaApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}