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

        private string[] options = new string[2]
        {
            "Son",
            "Difficulté"
        };

        private Dictionary<int, Action> optionsActions = new Dictionary<int, Action>()
        {
            { 0, () => new object()},
            { 1, () => new object()}
        };

        private Dictionary<int, string[]> subOptions = new Dictionary<int, string[]>()
        {
            {0, new string[] {"Off", "On"} },
            {1, new string[] {"Facile", "Moyen", "Difficile"} }
        };


        public Options()
        {
            menu = new Menu(title, options, optionsActions, subOptions, true);

            Configs.sound = true; //On
            Configs.difficulty = Utils.difficulties.Moyen; 
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
                int[] newConfig = null;
                switch (input)
                {
                    //case ConsoleKey.Enter:
                    //    menu.SelectCurrent();
                    //    menu.DisplayMenu();
                    //    break;

                    case ConsoleKey.UpArrow:
                        menu.SelectPrevious();
                        break;

                    case ConsoleKey.DownArrow:
                        menu.SelectNext();
                        break;

                    case ConsoleKey.RightArrow or ConsoleKey.Enter:
                        newConfig = menu.SelectNextSub();
                        break;

                    case ConsoleKey.LeftArrow:
                        newConfig = menu.SelectPreviousSub();
                        break;

                    case ConsoleKey.Escape:
                        stop = true;
                        break;

                    case ConsoleKey.Tab:

                        Console.SetCursorPosition(0, 20);
                        Console.Write($"Sound : {Configs.sound}");
                        Console.SetCursorPosition(0, 21);
                        Console.Write($"Difficulty : {Configs.difficulty}");


                        break;

                }

                if(newConfig != null)
                {
                    switch (newConfig[0])
                    {
                        //Sound
                        case 0:
                            Utils.SetSound(Convert.ToBoolean(newConfig[1]));
                            break;

                        //Difficulty
                        case 1:
                            Utils.SetDifficulty(newConfig[1]);
                            break;
                    }
                }
                
            }
            while (!stop);
        }

    }
}
