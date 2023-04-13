using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Wall
    {
        private string[] wall = new string[5]
        {
            "  ▄▄▄▄▄▄▄  ",
            " █████████ ",
            "███████████",
            "███████████",
            "███     ███"
        };

        int x;
        int y;

        public Wall(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }

        public void DisplayWall()
        {
            int i = 0;
            foreach(string line in wall)
            {
                Render.AddRender(x, y + i, line);

                int j = 0;
                foreach(char c in line)
                {
                    // If the char isn't a space
                    if(c!=' ')
                    {
                        Configs.wallsCollisions.Add((x+j, y + i));
                    }

                    j++;
                }

                i++;
            }


        }


    }
}
