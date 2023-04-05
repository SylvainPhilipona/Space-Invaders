using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


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

            // Create the ship
            Ship ship = new Ship(10, 10);
            ship.DisplayShip();


            do
            {

                /***********************************************************/
                /*                 Priority on user inputs                 */
                /***********************************************************/


                // Check if the user press right arrow
                if (CheckKeyPressed(ConsoleKey.RightArrow))
                {
                    ship.MoveRight();
                }

                // Check if the user press left arrow
                if (CheckKeyPressed(ConsoleKey.LeftArrow))
                {
                    ship.MoveLeft();
                }

                // Check if the user press spacebar
                if (CheckKeyPressed(ConsoleKey.Spacebar))
                {
                    ship.Shoot();
                    //ship.RefreshBullets();
                }
































                ship.RefreshBullets();
                Thread.Sleep(20);
            } 
            while (true);

            Console.ReadLine();
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
