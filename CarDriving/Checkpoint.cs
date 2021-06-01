using System;
using System.Drawing;
using CarDriving.MVC;

namespace CarDriving
{
    public class Checkpoint : MapObject
    {

        public Checkpoint(Point position) : base(position)
        {
        }

        public Checkpoint()
        {
        }

        private void Replace()
        {
            OnReplaceNeeded();
        }

        public override void OnCheckPosition(object sender, EventArgs e)
        {
            if (!(e is PositionChangedEventArgs positionArgs))
                return;
            if (!CollidesWith(positionArgs.NewRectangle)) return;
            if (!(sender is Car)) return;
            Replace();
            Game.ScoreCheckpoint += 1;
        }
    }
}