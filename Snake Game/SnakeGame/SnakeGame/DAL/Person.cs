using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.DAL
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public string Display { get { return $"{Name}: {Score}  on {Date} "; }




            //public int GetHighScore(int highScore)
            //{
            //    if (highScore >= Score)
            //    {
            //        Score = highScore;
            //    }
            //}



        }

    }
}
