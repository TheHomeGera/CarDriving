using System;
using System.Drawing;
using CarDriving.MVC;

namespace CarDriving
{
    public class Car : DynamicMapObject
    {
        public override void Run()
        {
            while (Game.ScoreCheckpoint < 10)
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
    }
}