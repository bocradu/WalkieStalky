using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkieStalky.ViewModels;
using System.Windows.Input;
using Xamarin.Forms;

namespace WalkieStalky.Views
{
    public partial class TopicsPage : ContentPage
    {
        public TopicsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
