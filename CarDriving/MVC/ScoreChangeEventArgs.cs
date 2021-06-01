using System;

namespace CarDriving.MVC
{
    public class ScoreChangeEventArgs : EventArgs
    {
        public static int Score { get; set; }

        public ScoreChangeEventArgs(int score)
        {
            Score = score;
        }
    }
}
