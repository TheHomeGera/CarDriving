using System.Windows.Forms;
using CarDriving.Properties;

namespace CarDriving
{
    internal class ViewCheckpoint : ViewMapObject
    {
        public ViewCheckpoint(Control map) : base(map)
        {
            picBox.Image = Resources.Checkpoint;
            map.Controls.Add(picBox);
        }
    }
}
