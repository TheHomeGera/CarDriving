using System.Windows.Forms;
using CarDriving.MVC;

namespace CarDriving
{
    internal class CarController : Controller<Car>
    {
        public void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (!(sender is Car car)) return;
            switch (e.KeyData)
            {
                case Keys.Up:
                {
                    car.IdentifyDirection(Direction.Up);
                    break;
                }
                case Keys.Down:
                {
                    car.IdentifyDirection(Direction.Down);
                    break;
                }
                case Keys.Left:
                {
                    car.IdentifyDirection(Direction.Left);
                    break;
                }
                case Keys.Right:
                {
                    car.IdentifyDirection(Direction.Right);
                    break;
                }
            }
        }
    }
}
