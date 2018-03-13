using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SnakeGame;

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
        public IList<Image> BGImages { get; set; }

        public GameSettings()
        {
            Width = 15;
            Height = 15;
            Speed = 15;
            Score = 0;
            Points = 100;
            GameOver = false;
            Direction = Directions.Down;
            BGImages = new List<Image>();
            //Image Grass = Image.FromFile(@"~\Images\Grass2.png");
            //Image Sand = Image.FromFile(@"~\Images\snake_bg.png");

            //BGImages.Add(Grass);
            //BGImages.Add(Sand);
        }

        public static void SetHighScore()
        {
            if (Score >=HighScore)
            {
                HighScore = Score;
            }
        }
    }
}
