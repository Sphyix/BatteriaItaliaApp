using BatteriaItaliaApp.Models;
using BatteriaItaliaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BatteriaItaliaApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public WorkOrder Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }

        private void Step_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}