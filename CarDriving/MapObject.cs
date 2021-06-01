using System;
using System.Drawing;
using CarDriving.MVC;

namespace CarDriving
{
    public class MapObject
    {
        protected Point position;
        public Point Position
        {
            get => position;
            set
            {
                position = value;
                OnPositionChanged();
            }
        }

        private const int width = 25;
        private const int height = 25;
        public int Width => width;
        public int Height => height;


        public Point MapSize { get; set; }

        public MapObject()
        {
            position = new Point(5,5);
        }

        public MapObject(Point position)
        {
            this.position = position;
        }

        public event EventHandler ReplaceNeeded;

        public void OnReplaceNeeded()
        {
            ReplaceNeeded?.Invoke(this, new EventArgs());
        }

        protected bool CheckCrossing(Point p)
        {
            if (Position.X + Width < p.X || Position.X > p.X) return false;
            return Position.Y + Height >= p.Y && Position.Y <= p.Y;
        }

        public bool CollidesWith(Rectangle rect)
        {
            return CheckCrossing(new Point(rect.Left, rect.Top)) ||
                   CheckCrossing(new Point(rect.Right, rect.Top)) ||
                   CheckCrossing(new Point(rect.Right, rect.Bottom)) ||
                   CheckCrossing(new Point(rect.Left, rect.Bottom));
        }

        public virtual void OnCheckPosition(object sender, EventArgs e)
        {
            if (!(e is PositionChangedEventArgs positionArgs))
                return;
            if (CollidesWith(positionArgs.NewRectangle))
                ((DynamicMapObject)sender).Deviate();
        }

        public event EventHandler PositionChanged;

        protected virtual void OnPositionChanged()
        {
            PositionChanged?.Invoke(this, new EventArgs());
        }
    }
}
