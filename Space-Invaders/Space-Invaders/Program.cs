using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console encoding
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;

            //Call the menu class
            Menu menu = new Menu();
            menu.DisplayMenu();
            menu.Select();





            //Console.Read();
        }
    }
}
