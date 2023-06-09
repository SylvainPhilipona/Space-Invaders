﻿using System;
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
                Render.AddRender(x, y, " ");
                return true;
            }

            Render.AddRender(x, y--, " ");
            Render.AddRender(x, y, "║");

            // Check if the bullet ran into a wall
            (int x, int y) collision = Configs.wallsCollisions.Find(obj => (obj.x == x && obj.y == y));
            if (collision.x != 0 && collision.y != 0)
            {
                Render.AddRender(x, y, " ");
                Configs.wallsCollisions.Remove(collision);
                return true;
            }



            return false;
        }


    }
}
