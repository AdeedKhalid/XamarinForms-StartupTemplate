using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFStructure.Views
{
    public class CircularFrame : Frame
    {
        public float Elevation { get; set; }

        public CircularFrame()
        {
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
            Padding = 0;
        }
    }
}
