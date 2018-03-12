using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Classes;

namespace SnakeGame.Classes
{
    public class Snake:Food
    {

        public Food SnakeHead { get; set; }
        public List<Food> SnakeBody { get; set; }


    }
}
