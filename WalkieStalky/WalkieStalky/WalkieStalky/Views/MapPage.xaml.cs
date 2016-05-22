using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Position = Xamarin.Forms.Maps.Position;

namespace WalkieStalky.Views
{
    public partial class MapPage : ContentPage
    {
        private double _currentLatitude;
        private double _currentLongitude;
        private IGeolocator _locator;
        public bool Initialized { get; set; }

        public MapPage()
        {
            InitializeComponent();
            Initialized = false;
            GestureFrame.SwipeDown += (s, e) =>
            {
                var initialBearingRadians = 0;
                MoveTo(initialBearingRadians);
            };

            GestureFrame.SwipeTop += (s, e) =>
            {
                MoveTo(180);
            };

            GestureFrame.SwipeLeft += (s, e) =>
            {
                MoveTo(90);
            };

            GestureFrame.SwipeRight += (s, e) =>
            {
                MoveTo(270);
            };

        }


        private void MoveTo(int initialBearingRadians)
        {
            var newLocation =
                FindPointAtDistanceFrom(
                    new GeoLocation {Latitude = _currentLatitude, Longitude = _currentLongitude},
                    initialBearingRadians, 1);
            var mapSpan = MapSpan.FromCenterAndRadius(
                new Position(newLocation.Latitude, newLocation.Longitude), Distance.FromKilometers(1));
            _currentLatitude = newLocation.Latitude;
            _currentLongitude = newLocation.Longitude;
            TopicsMap.MoveToRegion(mapSpan);
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
            _locator = CrossGeolocator.Current;
            _locator.DesiredAccuracy = 2;
            _locator.PositionChanged += Locator_PositionChanged;
            _locator.StartListeningAsync(1, 2);
           
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var mapSpan = MapSpan.FromCenterAndRadius(
               new Position(e.Position.Latitude, e.Position.Longitude), Distance.FromKilometers(1));
            _currentLatitude = e.Position.Latitude;
            _currentLongitude = e.Position.Longitude;
            TopicsMap.MoveToRegion(mapSpan);
            _locator.PositionChanged -= Locator_PositionChanged;
            _locator.StopListeningAsync();


        }

        public static GeoLocation FindPointAtDistanceFrom(GeoLocation startPoint, double initialBearingRadians, double distanceKilometres)
        {
            const double radiusEarthKilometres = 6371.01;
            var distRatio = distanceKilometres / radiusEarthKilometres;
            var distRatioSine = Math.Sin(distRatio);
            var distRatioCosine = Math.Cos(distRatio);

            var startLatRad = DegreesToRadians(startPoint.Latitude);
            var startLonRad = DegreesToRadians(startPoint.Longitude);

            var startLatCos = Math.Cos(startLatRad);
            var startLatSin = Math.Sin(startLatRad);

            var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)));

            var endLonRads = startLonRad
                + Math.Atan2(
                    Math.Sin(initialBearingRadians) * distRatioSine * startLatCos,
                    distRatioCosine - startLatSin * Math.Sin(endLatRads));

            return new GeoLocation
            {
                Latitude = RadiansToDegrees(endLatRads),
                Longitude = RadiansToDegrees(endLonRads)
            };
        }

        public static double DegreesToRadians(double degrees)
        {
            const double degToRadFactor = Math.PI / 180;
            return degrees * degToRadFactor;
        }

        public static double RadiansToDegrees(double radians)
        {
            const double radToDegFactor = 180 / Math.PI;
            return radians * radToDegFactor;
        }
    }

  

    public struct GeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

   
}
