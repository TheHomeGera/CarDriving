using System;
using System.Drawing;

namespace CarDriving.MVC
{
    public class PositionChangedEventArgs : EventArgs
    {
        public Rectangle NewRectangle { get; set; }

        public PositionChangedEventArgs( Rectangle newRectangle)
        {
            NewRectangle = newRectangle;
        }
    }
}
