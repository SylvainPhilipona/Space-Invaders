using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Ship
    {
        private int x;
        private int y;
        private int nbBullets;
        private List<Bullet> bullets;

        private string[] ship = new string[4]
        {
            " ▄■▄ ",
            " █▀█ ",
            "██▀██",
            "▓ ▓ ▓"
        };

        public Ship(int x, int y) 
        { 
            this.x = x;
            this.y = y;
            this.nbBullets = 0;
            this.bullets = new List<Bullet>();
        }

        public void DisplayShip()
        {
            int i = 0;
            foreach(string line in ship)
            {
                Render.AddRender(x, y + i, $" {line} ");
                i++;
            }
        }

        public void MoveLeft()
        {
            if (x - 1 >= 0)
            {
                x--;
                DisplayShip();
            }

        }

        public void MoveRight()
        {
            if (x + ship[0].Length + 3 <= Utils.GAME_WIDTH)
            {
                x++;
                DisplayShip();
            }
        }

        public void Shoot()
        {
            if(nbBullets < Utils.NB_BULLETS)
            {
                bullets.Add(new Bullet(x+3, y-1));
            }
            nbBullets = bullets.Where(b => b != null).Count();

        }

        public void RefreshBullets()
        {

            foreach (Bullet bullet in bullets.ToList())
            {
                if (bullet != null)
                {
                    bool reachedTop = bullet.MoveUp();

                    if (reachedTop)
                    {
                        bullets[bullets.IndexOf(bullet)] = null;
                    }
                }
            }


            nbBullets = bullets.Where(b => b != null).Count();
        }
    }
}
