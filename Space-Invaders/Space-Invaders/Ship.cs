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
        private Bullet[] bullets;

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
            this.bullets = new Bullet[Configs.nbBullets];
        }

        public void DisplayShip()
        {
            int i = 0;
            foreach(string line in ship)
            {
                Console.SetCursorPosition(x,y+i);
                Console.Write($" {line} ");


                i++;
            }
        }

        public void MoveLeft()
        {
            x--;
            DisplayShip();
        }

        public void MoveRight()
        {
            x++;
            DisplayShip();
        }

        public void Shoot()
        {
            if(nbBullets < Configs.nbBullets)
            {
                bullets[nbBullets] = new Bullet(x+3, y-1);
            }
            nbBullets = bullets.Where(b => b != null).Count();
        }

        public void RefreshBullets()
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                if(bullets[i] != null)
                {
                    bool reachedTop = bullets[i].MoveUp();

                    if (reachedTop)
                    {
                        bullets[i] = null;
                    }

                }
            }

            nbBullets = bullets.Where(b => b != null).Count();



            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Bullets : {nbBullets}");

            foreach(Bullet bullet in bullets)
            {
                Console.WriteLine($"{bullet != null}");
            }
        }
    }
}
