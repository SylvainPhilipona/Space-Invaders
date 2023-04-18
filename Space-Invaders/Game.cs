using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

namespace Space_Invaders
{
    internal class Game
    {

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int key);





        public Game() 
        {
        
        
        }


        public void Start()
        {
            Utils.SetWindowsSize(Utils.GAME_WIDTH, Utils.GAME_HEIGHT);
            Console.Clear();
            Configs.wallsCollisions = new List<(int x, int y)>();

            // Create the walls
            Wall[] walls = new Wall[3]{
                new Wall(10, 30),
                new Wall(50, 30),
                new Wall(80, 30)
            };

            // Display the walls
            foreach(Wall wall in walls)
            {
                wall.DisplayWall();
            }

            // Create the ship
            //Ship ship = new Ship(100, 40);
            //ship.DisplayShip();

            List<Ship> ships = new List<Ship>();
            for (int i = 1; i <= 30; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Ship ship = new Ship(i * 6, 40);
                    ships.Add(ship);
                    ship.DisplayShip();
                }
            }





            // Create the ennemies



            Stopwatch timer = new Stopwatch();
            DateTime lastTime;
            lastTime = DateTime.Now;

            int FPS = 0;
            do
            {
                // Restart the frame timer
                timer.Restart();


                /***********************************************************/
                /*                 Priority on user inputs                 */
                /***********************************************************/

                // Check if the user press right arrow
                if (CheckKeyPressed(ConsoleKey.RightArrow))
                {
                    foreach (Ship ship in ships)
                    {
                        ship.MoveRight();
                    }
                }

                // Check if the user press left arrow
                if (CheckKeyPressed(ConsoleKey.LeftArrow))
                {
                    foreach (Ship ship in ships)
                    {
                        ship.MoveLeft();
                    }
                }

                // Check if the user press spacebar
                if (CheckKeyPressed(ConsoleKey.Spacebar))
                {
                    foreach (Ship ship in ships)
                    {
                        ship.Shoot();
                    }
                }




                // Refresh the bullets and render the view
                foreach (Ship ship in ships)
                {
                    ship.RefreshBullets();
                }
                Render.RenderAll();



                // Display the current FPS every seconds
                FPS++;
                if ((DateTime.Now - lastTime).TotalSeconds >= 1)
                {
                    // one second has elapsed 
                    Console.SetCursorPosition(0, 0);
                    Console.Write($"{FPS} fps             ");

                    FPS = 0;
                    lastTime = DateTime.Now;
                }


                // Wait till the elapsed time is inferious to the frame rate
                while (timer.ElapsedMilliseconds < 1000 / Configs.FPS)
                {
                    Thread.Sleep(0);
                }
            } 
            while (true);
        }



        private bool CheckKeyPressed(ConsoleKey key)
        {
            // https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
            Dictionary<ConsoleKey, int> table = new Dictionary<ConsoleKey, int>()
            {
                {ConsoleKey.LeftArrow, 0x25 },
                {ConsoleKey.RightArrow, 0x27 },
                {ConsoleKey.Spacebar, 0x20 },
                {ConsoleKey.Enter, 0x0D }
            };

            int VK = table[key];

            if ((GetAsyncKeyState(VK) & 0x8000) != 0)
            {
                return true;
            }


            return false;
        }
    }
}
