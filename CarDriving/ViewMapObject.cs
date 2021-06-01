using System;
using System.Drawing;
using System.Windows.Forms;
using CarDriving.MVC;

namespace CarDriving
{
    internal class ViewMapObject : View<MapObject>
    {
        protected PictureBox picBox = new PictureBox();

        public ViewMapObject(Control map)
        {
            map.Controls.Add(picBox);
            picBox.Height = Model.Height;
            picBox.Width = Model.Width;
        }


        public void Subscribe()
        {
            Model.PositionChanged += OnPositionChanged;
            OnPositionChanged(this, new EventArgs());
        }

        private void OnPositionChanged(object sender, EventArgs e)
        {
            Show();
        }

        private void Show()
        {
            SetImage(Model.Position);
        }

        private delegate void SetImageCallback(Point p);

        private void SetImage(Point p)
        {
            if (picBox.InvokeRequired)
            {
                SetImageCallback d = SetImage;
                picBox.Invoke(d, Model.Position);
            }
            else
            {
                ChangePicture();
                picBox.Location = p;
            }
        }


        protected virtual void ChangePicture() { }

        protected override void Update()
        {
            Show();
        }
    }
}
