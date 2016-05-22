using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WalkieStalky.Views
{
    public class CustomMap:Map
    {
       public List<CustomPin> CustomPins { get; set; }
       public CustomMap()
        {
            CustomPins=new List<CustomPin>();
            HasScrollEnabled = false;
            HasZoomEnabled = false;
            WidthRequest = 960;
            HeightRequest = 100;
            IsShowingUser = false;
            MapType = MapType.Street;
            VerticalOptions = LayoutOptions.FillAndExpand;
        }

        public event EventHandler SwipeDown;
        public event EventHandler SwipeTop;
        public event EventHandler SwipeLeft;
        public event EventHandler SwipeRight;

        public void OnSwipeDown()
        {
            if (SwipeDown != null)
                SwipeDown(this, null);
        }

        public void OnSwipeTop()
        {
            if (SwipeTop != null)
                SwipeTop(this, null);
        }

        public void OnSwipeLeft()
        {
            if (SwipeLeft != null)
                SwipeLeft(this, null);
        }

        public void OnSwipeRight()
        {
            if (SwipeRight != null)
                SwipeRight(this, null);
        }
    }
}
