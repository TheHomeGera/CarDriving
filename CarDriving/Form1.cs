using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarDriving
{
    public partial class Form1 : Form
    {
        public static Random Rand = new Random();

        private readonly ViewGame viewGame;

        public static int CountWall;

        public static int Maxx;
        public static int Maxy;

        public static string[] map = {
            "********************",
            "*....***.....*.....*",
            "*.**.....*********.*",
            "*.*..***....*......*",
            "*.*.****..*...***..*",
            "*.*......***.......*",
            "*.*.**.**....*..*.**",
            "*...*..*..*..*.**..*",
            "**..*..***..**..**.*",
            "**.**.*...****..*..*",
            "*..**...*...***.*.**",
            "*.*...***.*.....*..*",
            "*.*.*...*.*..*..**.*",
            "*.*.*****.*.*..**..*",
            "*......**.*..*****.*",
            "*.*..*.*..**...**..*",
            "*...*..*.**..*..*.**",
            "*.*.*.....*.***.*..*",
            "*..*..**.....*....**",
            "********************"
        };
        public Form1()
        {
            InitializeComponent();
            Size = new Size(p_Map.Width+23, p_Map.Height+45);
            Text = "CarDriving";
            Maxx = p_Map.Width-150;
            Maxy = p_Map.Height;
            foreach (var t in map)
                for (var j = 0; j < map[0].Length; j++)
                    CountWall += t[j] == '*' ? 1 : 0;
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
