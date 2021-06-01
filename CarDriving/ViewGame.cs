using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CarDriving.MVC;

namespace CarDriving
{
    internal class ViewGame : View<Game>
    {

        private ViewCar viewCar;

        private List<ViewCheckpoint> viewCheckpoint;

        private List<ViewWall> viewWall = new List<ViewWall>();


        private readonly CarController controller = new CarController();

        private readonly Panel panelMap;


        public ViewGame(Panel panelMap)
        {
            this.panelMap = panelMap;
        }


        private event KeyEventHandler KeyPress;

        public virtual void OnKeyPress(Keys key)
        {
            KeyPress?.Invoke(viewCar.Model, new KeyEventArgs(key));
        }

        public void SubscribeKeyPress()
        {
            KeyPress += controller.OnKeyPress;
            controller.OnKeyPress(viewCar, new KeyEventArgs(Keys.Right));
        }

        public void UnsubscribeKeyPress()
        {
            KeyPress -= controller.OnKeyPress;
        }

        protected override void Update()
        {
            Refresh();
        }

        private void Refresh()
        {
            viewWall = new List<ViewWall>();
            viewCheckpoint = new List<ViewCheckpoint>();
            foreach (var checkpoint in Model.Checkpoint.Select(checkpoint => new ViewCheckpoint(panelMap) { Model = checkpoint }))
            {
                checkpoint.Model.MapSize = new Point(panelMap.Width, panelMap.Height);
                checkpoint.Subscribe();
                viewCheckpoint.Add(checkpoint);
            }

            viewCar = new ViewCar(panelMap) { Model = Model.Car };
            viewCar.Model.MapSize = new Point(panelMap.Width, panelMap.Height);
            viewCar.Subscribe();

            foreach (var viewWalltemp in Model.ArrWall.Select(wall => new ViewWall(panelMap) { Model = wall }))
            {
                viewWalltemp.Model.MapSize = new Point(panelMap.Width, panelMap.Height);
                viewWall.Add(viewWalltemp);
            }
            new Interface(panelMap);
        }
    }
}
