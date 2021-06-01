using System.Windows.Forms;
using CarDriving.Properties;

namespace CarDriving
{
    internal class ViewWall : ViewMapObject
    {
        public ViewWall(Control map) : base(map)
        {
            picBox.Image = Resources.Wall3;
        }
    }
}
