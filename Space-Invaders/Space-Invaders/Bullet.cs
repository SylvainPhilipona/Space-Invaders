using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Bullet
    {
        int x;
        int y;

        public Bullet(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }

        public bool MoveUp()
        {
            // Check if the bullet is arrived at top
            if(y-1 < 0)
            {
                return true;
            }


            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            y = y - 1;
            Console.SetCursorPosition(x, y);
            Console.Write("|");


            return false;
        }


    }
}
