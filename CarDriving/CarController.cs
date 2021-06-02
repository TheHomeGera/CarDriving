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
                case Keys.W:
                {
                    car.IdentifyDirection(Direction.Up);
                    break;
                }
                case Keys.S:
                {
                    car.IdentifyDirection(Direction.Down);
                    break;
                }
                case Keys.A:
                {
                    car.IdentifyDirection(Direction.Left);
                    break;
                }
                case Keys.D:
                {
                    car.IdentifyDirection(Direction.Right);
                    break;
                }
            }
        }
    }
}
