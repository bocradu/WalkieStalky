using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WalkieStalky.Views
{
    public partial class MapPage : ContentPage
    {
        public bool Initialized { get; set; }
        public MapPage()
        {
            InitializeComponent();
            Initialized = false;
        }

        public void Initialize()
        {
            Initialized = true;
            GetCurrentLocation();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        void GetCurrentLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            locator.PositionChanged += Locator_PositionChanged;
            locator.StartListeningAsync(1, 2);
           
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var mapSpan = MapSpan.FromCenterAndRadius(
               new Position(e.Position.Latitude, e.Position.Longitude), Distance.FromMiles(0.3));

            MyMap.MoveToRegion(mapSpan);
        }
    }
}
