using System;
using System.Windows.Forms;
using CarDriving.Properties;

namespace CarDriving
{
    internal class ViewCar : ViewDynamicMapObject
    {
        public ViewCar(Control map) : base(map)
        {
            picBox.Image = Resources.car;
        }

        protected override void ChangePicture()
        {
            switch (Model.DirectionNow)
            {
                case Direction.Up:
                {
                    picBox.Image = Resources.car5;
                    break;
                }
                case (Direction.Down):
                {
                    picBox.Image = Resources.car2;
                    break;
                }
                case Direction.Right:
                {
                    picBox.Image = Resources.car4;
                    break;
                }
                case Direction.Left:
                {
                    picBox.Image = Resources.car3;
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}