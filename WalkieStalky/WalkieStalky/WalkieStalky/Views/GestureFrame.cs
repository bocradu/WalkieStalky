using System;
using Xamarin.Forms;

namespace WalkieStalky.Views
{
    public class FrameEventArgs : EventArgs
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
	public class GestureFrame : Frame
	{
		public GestureFrame()
		{
			
		}

		public event EventHandler SwipeDown;
		public event EventHandler SwipeTop;
		public event EventHandler SwipeLeft;
		public event EventHandler SwipeRight;
        public event EventHandler Tap;

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

	    public void OnTap()
	    {
            if (Tap != null)
                Tap(this, null);
        }
	}
}