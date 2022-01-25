using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BatteriaItaliaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestHomePage : TabbedPage
    {
        public TestHomePage()
        {
            InitializeComponent();
            //this.Children.RemoveAt(0);
        }
    }
}