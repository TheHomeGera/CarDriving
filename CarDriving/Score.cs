using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDriving
{ 
    class Score
    {
        private readonly Label label;
        public static Thread LabelThread;

        public Score(Control map)
        {
            label = new Label {Location = new Point(690, 20)};
            map.Controls.Add(label);
            LabelThread = new Thread(Change);
            LabelThread.Start();
        }
        private void Change()
        {
            while (true)
            {
                if (Game.ScoreCheckpoint <= 15)
                    label.Invoke((new Action( () => label.Text = @"Чекпоинты: " + Game.ScoreCheckpoint + @"/15")));
                Thread.Sleep(100);
            }
        }
        
    }
}
