using System;
using System.Drawing;
using CarDriving.MVC;

namespace CarDriving
{
    public class Car : DynamicMapObject
    {
        public override void Run()
        {
            while (Game.ScoreCheckpoint < 15)
            {
                OnCheck();
                Move();
            }
        }

        public Car()
        {
            delta = 4;
        }
        public Car(Point position) : base(position)
        {
            delta = 4;
        }


        public override void OnCheckPosition(object sender, EventArgs e)
        {
            if (!(e is PositionChangedEventArgs positionArgs))
                return;
            if (!CollidesWith(positionArgs.NewRectangle)) return;
        }
    }
}