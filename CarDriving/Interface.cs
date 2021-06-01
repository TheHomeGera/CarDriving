using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CarDriving
{ 
    class Interface
    {
        private Label label;
        private Timer timer;
        private Label timerLabel;
        private Control map;

        public Interface(Control map)
        {
            this.map = map;
            CreateScore();
            CreateTimer();
            timer = new Timer
            {
                Interval = 200,
            };
            timer.Tick += Change;
            timer.Start();

        }

        protected void CreateScore()
        {
            label = new Label
            {
                Location = new Point(690, 20), 
                Font = new Font("Times New Roman", 15), 
                Size = new Size(500, 30)
            };
            map.Controls.Add(label);
        }

        protected void CreateTimer()
        {
            timerLabel = new Label
            {
                Location = new Point(690, 60),
                Font = new Font("Times New Roman", 15),
                Size = new Size(200, 30)
            };
            map.Controls.Add(timerLabel);
        }

        private double tickS = 0;
        public static string time;
        private void Change(object obj, EventArgs e)
        {
            tickS += 0.2;
            var span = TimeSpan.FromMinutes(tickS);
            time = span.ToString(@"hh\:mm");
            if (Game.ScoreCheckpoint < 15)
            {
                label.Text = @"Чекпоинты: " + Game.ScoreCheckpoint + @"/15";
                timerLabel.Text = time;
            }
            else
            {
                timer.Stop();
                label.Text = @"Чекпоинты: " + Game.ScoreCheckpoint + @"/15";
                _ = new Form2();
            }
        }

    }

    class Form2
    {
        public Form2()
        {
            var form2 = new Form {Text = "Поздравляем", Size = new Size(260, 150)};
            var scorelabel = new Label
            {
                Text = "Вы прошли " + Game.ScoreCheckpoint + " чекпоинтов",
                Location = new Point(0,0),
                Font = new Font("Times New Roman", 15),
                Size = new Size(2000, 30)
            };
            var timerlabel = new Label
            {
                Text = "Время: " + Interface.time ,
                Location = new Point(0, 40),
                Font = new Font("Times New Roman", 15),
                Size = new Size(2000, 30)
            };
            var button = new Button
            {
                Text = "Заново",
                Location = new Point(20, 70),
                Font = new Font("Times New Roman", 15),
                Size = new Size(200, 30)
            };
            form2.Controls.Add(scorelabel);
            form2.Controls.Add(timerlabel);
            form2.Controls.Add(button);
            button.Click += Restart;
            form2.FormClosing += GameForm_FormClosing;
            form2.ShowDialog();
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Restart(object obj, EventArgs e)
        {
            Application.Restart();
        }
    }
}
