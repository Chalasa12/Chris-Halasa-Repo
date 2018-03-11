using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Food
    {
        public int YPosition { get; set; }
        public int XPosition { get; set; }

        public Food()
        {
            YPosition = 0;
            XPosition = 0;
        }
    }
}
