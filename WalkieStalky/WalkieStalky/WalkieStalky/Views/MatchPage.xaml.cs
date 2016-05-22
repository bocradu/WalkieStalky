using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageCircle.Forms.Plugin.Abstractions;
using WalkieStalky.Model;
using WalkieStalky.ViewModels;
using Xamarin.Forms;

namespace WalkieStalky.Views
{
    public partial class MatchPage : ContentPage
    {
        public MatchPage(PersonRecord match, string matchedTopicName)
        {
            InitializeComponent();
            BindingContext=new MatchViewModel(match, matchedTopicName);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Services.Services.GetInstance().VibrateService.Alert();
        }
    }
}
