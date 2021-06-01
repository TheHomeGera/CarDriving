using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarDriving
{
    public partial class Form1 : Form
    {
        public static Random rand = new Random();

        private ViewGame viewGame;

        public static int countWall;

        public static int MAXX;
        public static int MAXY;

        public static string[] map = {
            "********************",
            "*....***...........*",
            "*.**.....*********.*",
            "*.*..**.....*......*",
            "*.*.****..*...***..*",
            "*.*......***.......*",
            "*.*.*..*.....*..*.**",
            "*.*.*..*..*..*.**..*",
            "*.*.*..*******..**.*",
            "*.*.*.....****..*..*",
            "*.*.*.......***.*.**",
            "*.*.*.***.*.....*..*",
            "*.*.*...*.*..**.**.*",
            "*.*.*****.*.*****..*",
            "*......*..*..***.*.*",
            "*....*.*..**...**..*",
            "*...*...*.*..*..*.**",
            "*.*.*.....*..*..*..*",
            "*..*...*..*..*....**",
            "********************"
        };
        public Form1()
        {
            InitializeComponent();
            Size = new Size(p_Map.Width+23, p_Map.Height+45);
            Text = "CarDriving";
            MAXX = p_Map.Width-150;
            MAXY = p_Map.Height;
            foreach (var t in map)
                for (var j = 0; j < map[0].Length; j++)
                    countWall += t[j] == '*' ? 1 : 0;
            var game = new Game();
            viewGame = new ViewGame(p_Map);
            viewGame.SubscribeKeyPress();
            viewGame.Model = game;
            viewGame.Model.Start();
        }

        private void p_Map_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            viewGame.OnKeyPress(e.KeyCode);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            viewGame.Model.Dispose();
        }
    }
}
