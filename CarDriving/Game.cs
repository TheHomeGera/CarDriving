using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace CarDriving
{
    internal class Game
    {
        public List<Wall> ArrWall { get; } = new List<Wall>();
        public Car Car { get; }
        private readonly Thread carThread;
        public static int ScoreCheckpoint = 0;
        public List<Checkpoint> Checkpoint = new List<Checkpoint>();

        public Game()
        {
            for (var i = 0; i < Form1.countWall; i++)
            {
                var rect = new Rectangle();
                ArrWall.Add(new Wall(rect.Location));
            }
            PlaceWalls();

            Rectangle checkpoint;
            do checkpoint = new Rectangle(Form1.rand.Next(0, Form1.MAXX), Form1.rand.Next(0, Form1.MAXY), (new Checkpoint()).Width, (new Checkpoint()).Height);
            while (Collides(checkpoint));
            Checkpoint.Add(new Checkpoint(checkpoint.Location));

            Rectangle rect2;
            do
                rect2 = new Rectangle(Form1.rand.Next(0, Form1.MAXX), Form1.rand.Next(0, Form1.MAXY), (new Car()).Width, (new Car()).Height);
            while
                (Collides(rect2));

            Car = new Car(rect2.Location);
            carThread = new Thread(Car.Run);
            SubscribePos();
        }

        public void Start()
        {
            carThread.Start();
        }

        private void PlaceWalls()
        {
            var cur = 0;
            for (var i = 0; i < Form1.map[0].Length; i++)
                for (var j = 0; j < Form1.map[1].Length; j++)
                    if (Form1.map[i][j] == '*')
                    {
                        ArrWall[cur].Position = new Point((int)(i * ArrWall[cur].Width*1.4), (int)(j * ArrWall[cur].Height*1.4));
                        cur++;
                    }
        }

        private bool Collides(Rectangle rect)
        {
            if (rect.Left < 0 || rect.Right >= Form1.MAXX || rect.Top < 0 || rect.Bottom >= Form1.MAXY)
                return true;
            if (ArrWall.Any(t => t.CollidesWith(rect)))
                return true;
            if (Checkpoint.Any(t => t.CollidesWith(rect)))
                return true;
            return Car != null && Car.CollidesWith(rect);
        }

        public void Dispose()
        {
            carThread.Abort();
        }

        public void SubscribePos()
        {
            foreach (var wall in ArrWall)
                Car.CheckPosition += wall.OnCheckPosition;
            foreach (var checkpoint in Checkpoint)
            {
                Car.CheckPosition += checkpoint.OnCheckPosition;
            }
            foreach (var checkpoint in Checkpoint)
            {
                checkpoint.ReplaceNeeded += CheckpointReplaceNeeded;
            }
        }

        private void CheckpointReplaceNeeded(object sender, EventArgs e)
        {
            Rectangle rect2;
            do
                rect2 = new Rectangle(Form1.rand.Next(0, Form1.MAXX - ((MapObject)sender).Width - 2), Form1.rand.Next(Form1.MAXY - ((MapObject)sender).Height - 2), (new Checkpoint()).Width, (new Checkpoint()).Height);
            while
                (Collides(rect2));
            if (sender != null) ((Checkpoint)sender).Position = rect2.Location;
        }
    }
}
