using System;
using System.Drawing;
using System.Threading;
using CarDriving.MVC;

namespace CarDriving
{
    public class DynamicMapObject : MapObject
    {
        private int dy;
        private int dx;
        private bool flag;
        protected int delta;

        public Direction DirectionNow { get; private set; }

        public DynamicMapObject()
        {
        }

        public DynamicMapObject(Point position) : base(position)
        {
            delta = 0;
            dy = 0;
            dx = delta;
            Turn();
        }

        public virtual void Move()
        {
            if (position.X + dx >= 0 && position.X + Width + dx < MapSize.X)
                position.X += dx;
            else
                Deviate();
            if (position.Y + dy >= 0 && position.Y + Height + dy < MapSize.Y)
                position.Y += dy;
            else
                Deviate();
            flag = true;
            OnPositionChanged();
            Thread.Sleep(10);
        }


        public void Deviate()
        {
            if (flag != true) return;
            dx = -dx;
            dy = -dy;
            switch (DirectionNow)
            {
                case Direction.Left:
                    {
                        DirectionNow = Direction.Right;
                        break;
                    }
                case (int)Direction.Right:
                    {
                        DirectionNow = Direction.Left;
                        break;
                    }
                case Direction.Up:
                    {
                        DirectionNow = Direction.Down;
                        break;
                    }
                case Direction.Down:
                    {
                        DirectionNow = Direction.Up;
                        break;
                    }
            }
            flag = false;
        }

        public void Turn()
        {
            dy = 0;
            dx = -delta;
            DirectionNow = Direction.Left;
        }

        public void IdentifyDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    {
                        dy = delta;
                        dx = 0;
                        DirectionNow = Direction.Down;
                        break;
                    }
                case Direction.Left:
                    {
                        dy = 0;
                        dx = -delta;
                        DirectionNow = Direction.Left;
                        break;
                    }
                case Direction.Right:
                    {
                        dy = 0;
                        dx = delta;
                        DirectionNow = Direction.Right;
                        break;
                    }
                case Direction.Up:
                    {
                        dy = -delta;
                        dx = 0;
                        DirectionNow = Direction.Up;
                        break;
                    }
            }
        }

        public virtual void Run()
        {
            while (true)
            {
                OnCheck();
                Move();
            }
        }

        public event EventHandler CheckPosition;


        protected virtual void OnCheck()
        {
            CheckPosition?.Invoke(this, new PositionChangedEventArgs(new Rectangle(position.X + dx, position.Y + dy, Width, Height)));
        }

        public override void OnCheckPosition(object sender, EventArgs e)
        {
            if (!(e is PositionChangedEventArgs positionArgs))
                return;
            if (!CollidesWith(positionArgs.NewRectangle)) return;
        }
    }
}
