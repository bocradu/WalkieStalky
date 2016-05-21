using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace WalkieStalky.Views
{
    public partial class MatchPage : ContentPage
    {
        public MatchPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Services.Services.GetInstance().VibrateService.Alert();
        }
    }
}
