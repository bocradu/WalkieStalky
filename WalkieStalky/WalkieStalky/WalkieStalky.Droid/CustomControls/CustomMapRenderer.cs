//using System.Collections.Generic;
//using Android.Gms.Maps;
//using Xamarin.Forms.Maps.Android;
//using Xamarin.Forms;
//using Android.Gms.Maps.Model;
//using WalkieStalky.Droid.CustomControls;
//using WalkieStalky.Views;
//using View = Android.Views.View;
//using System;
//using Android.Content;
//using Android.Widget;
//using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]

//namespace WalkieStalky.Droid.CustomControls
//{
//    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter, IOnMapReadyCallback
//    {
//        GoogleMap map;
//        List<CustomPin> customPins;
//        private bool _isDrawnDone;

   

//        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
//        {
//            base.OnElementChanged(e);

//            if (e.OldElement != null)
//            {
//                map.InfoWindowClick -= OnInfoWindowClick;
//            }

//            if (e.NewElement != null)
//            {
//                var formsMap = (CustomMap)e.NewElement;
//                customPins = formsMap.CustomPins;
//                ((MapView)Control).GetMapAsync(this);
//            }
//        }

//        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
//        {
//            base.OnElementPropertyChanged(sender, e);

//            if (e.PropertyName.Equals("VisibleRegion") && !_isDrawnDone)
//            {
//                map.Clear();

//                foreach (var pin in customPins)
//                {
//                    var marker = new MarkerOptions();
//                    marker.SetPosition(new LatLng(pin.Pin.Position.Latitude, pin.Pin.Position.Longitude));
//                    marker.SetTitle(pin.Pin.Label);
//                    marker.SetSnippet(pin.Pin.Address);
//                    marker.SetIcon(BitmapDescriptorFactory.FromPath("tomato.png"));

//                    map.AddMarker(marker);
//                }
//                _isDrawnDone = true;
//            }


//        }
//        public void OnMapReady(GoogleMap googleMap)
//        {
//            map = googleMap;
//            map.InfoWindowClick += OnInfoWindowClick;
//            map.SetInfoWindowAdapter(this);
//        }

//        private void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
//        {
//            var customPin = GetCustomPin(e.Marker);
//            if (customPin == null)
//            {
//                throw new Exception("Custom pin not found");
//            }

//            if (!string.IsNullOrWhiteSpace(customPin.Url))
//            {
//                var url = Android.Net.Uri.Parse(customPin.Url);
//                var intent = new Intent(Intent.ActionView, url);
//                intent.AddFlags(ActivityFlags.NewTask);
//                Android.App.Application.Context.StartActivity(intent);
//            }
//        }

//        private GoogleMap.IOnInfoWindowClickListener OnInfoWindowClickListener()
//        {
//            // Requird to stop an exception been generated when info window is touched, known issue
//            return null;
//        }

//        void HandleMarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
//        {

//            // This code should work but it's a confirmed bug in Googlemaps
//            // https://code.google.com/p/gmaps-api-issues/issues/detail?id=5408

//            e.Handled = true;

//            var marker = e.Marker;

//            if (marker.IsInfoWindowShown) // Always returns false, check
//                marker.HideInfoWindow();
//            else
//                marker.ShowInfoWindow();

//        }

//        protected override void OnLayout(bool changed, int l, int t, int r, int b)
//        {
//            base.OnLayout(changed, l, t, r, b);

//            //NOTIFY CHANGE
//            if (changed)
//            {
//                _isDrawnDone = false;
//            }
//        }

//        public Android.Views.View GetInfoContents(Marker marker)
//        {
//            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
//            if (inflater != null)
//            {
//                Android.Views.View view;

//                var customPin = GetCustomPin(marker);
//                if (customPin == null)
//                {
//                    throw new Exception("Custom pin not found");
//                }

//                if (customPin.Id == "Xamarin")
//                {
//                    view = inflater.Inflate(Resource.Layout.XamarinMapInfoWindow, null);
//                }
//                else
//                {
//                    view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
//                }

//                var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
//                var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);

//                if (infoTitle != null)
//                {
//                    infoTitle.Text = marker.Title;
//                }
//                if (infoSubtitle != null)
//                {
//                    infoSubtitle.Text = marker.Snippet;
//                }

//                return view;
//            }
//            return null;
//        }

//        public View GetInfoWindow(Marker marker)
//        {
           
//        }
//    }
//}