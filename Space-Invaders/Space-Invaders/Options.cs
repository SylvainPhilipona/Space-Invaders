using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Options
    {
        private Menu menu;

        private string[] title = new string[3]
        {
            "█▀▀█ █▀▀█ ▀▀█▀▀ █ █▀▀█ █▄  █ █▀▀",
            "█  █ █▀▀▀   █   █ █  █ █ █ █ ▀▀█",
            "▀▀▀▀ ▀      ▀   ▀ ▀▀▀▀ ▀  ▀▀ ▀▀▀"
        };

        private string[] options = new string[3]
        {
            "Son",
            "Difficulté",
            "Couleurs"
        };

        private Dictionary<int, Action> optionsActions = new Dictionary<int, Action>()
        {
            { 0, () => new object()},
            { 1, () => new object()},
            { 2, () => new object()}
        };

        private Dictionary<int, string[]> subOptions = new Dictionary<int, string[]>()
        {
            {0, new string[] {"On", "Off"} },
            {1, new string[] {"Facile", "Moyen", "Difficile"} },
            {2, new string[] {"Vert", "Rouge", "Bleu"} }
        };


        public Options()
        {
            menu = new Menu(title, options, optionsActions, subOptions, true);

        }

        public void Display()
        {
            Utils.SetWindowsSize(Utils.MENU_WIDTH, Utils.MENU_HEIGHT);

            Console.Clear();
            menu.DisplayMenu();


            //Infinite loop
            bool stop = false;
            do
            {
                // Ask the user a keyboard input
                ConsoleKey input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.Enter:
                        menu.SelectCurrent();
                        menu.DisplayMenu();
                        break;

                    case ConsoleKey.UpArrow:
                        menu.SelectPrevious();
                        break;

                    case ConsoleKey.DownArrow:
                        menu.SelectNext();
                        break;

                    case ConsoleKey.RightArrow:
                        menu.SelectNextSub();
                        break;

                    case ConsoleKey.LeftArrow:
                        menu.SelectPreviousSub();
                        break;

                    case ConsoleKey.Escape:
                        stop = true;
                        break;

                }
            }
            while (!stop);
        }

    }
}
