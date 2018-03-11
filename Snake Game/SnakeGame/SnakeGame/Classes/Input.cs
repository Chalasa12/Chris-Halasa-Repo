using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace SnakeGame.Classes
{
    public class Input
    {
        //list of keyboard buttons
        private static Hashtable keyTable = new Hashtable();

        //check to see if specific key was pressed
        public static bool IsKeyPressed(Keys key)
        {
            if (keyTable[key]==null)
            {
                return false;
            }

            return (bool)keyTable[key];
        }

        //detect if a button was pressed
        public static void ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}
