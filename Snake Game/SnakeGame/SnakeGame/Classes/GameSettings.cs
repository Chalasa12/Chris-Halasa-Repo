using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame.Classes
{

    public enum Directions { Up, Down, Left, Right }

    public class GameSettings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Directions Direction { get; set; }
        public static int HighScore { get; set; }

        public GameSettings()
        {
            Width = 15;
            Height = 15;
            Speed = 15;
            Score = 0;
            Points = 100;
            GameOver = false;
            Direction = Directions.Down;

        }

        public static void SetHighScore()
        {
            if (Score >=HighScore)
            {
                HighScore = Score;
                //if (MessageBox.Show("Would you like to record High Score in Leaderboard?", "Leaderboard?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{
                //    TextBox textBox = new TextBox();
                //}
            }
        }
    }
}
