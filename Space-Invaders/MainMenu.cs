///Author      : Sylvain Philipona
///Date        : 03.04.2023
///Description : Game menu
using System;

namespace Space_Invaders
{
    internal class MainMenu
    {
        private BetterMenu menu;
        private string[] title = new string[3]
        {
            "█   █ █▀▀ █   █▀▀ █▀▀█ █▀▄▀█ █▀▀",
            "█▄█▄█ █▀▀ █   █   █  █ █ ▀ █ █▀▀",
            " ▀ ▀  ▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀▀ ▀   ▀ ▀▀▀"
        };


        public MainMenu()
        {
            this.menu = new BetterMenu(title);
        }


        public void Display()
        {
            // Set the windows size
            Utils.SetWindowsSize(Utils.MENU_WIDTH, Utils.MENU_HEIGHT);
            
            // Add the options and actions
            int option1 = menu.AddOption("Jouer", (() => new Game().Start()));
            int option2 = menu.AddOption("Options", (() => new Options().Display()));
            int option3 = menu.AddOption("Highscore", (() => new Object()));
            int option4 = menu.AddOption("A propos", (() => new About().Display()));
            int option5 = menu.AddOption("Quitter", (() => Environment.Exit(0)));

            //// Add the suboptions
            //menu.AddSubOption(option1, "Dur");
            //menu.AddSubOption(option1, "Facile");
            //menu.AddSubOption(option1, "easy");

            //menu.AddSubOption(option3, "Un");
            //menu.AddSubOption(option3, "Deux");
            //menu.AddSubOption(option3, "Trois");
            //menu.AddSubOption(option3, "Quatre");


            // Infinite loop
            do
            {
                // Display the menu
                menu.Display();

                // Ask the user a keyboard input
                ConsoleKey input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.Enter:
                        menu.SelectCurrent();
                        break;

                    case ConsoleKey.UpArrow:
                        menu.SelectPrevious();
                        break;

                    case ConsoleKey.DownArrow:
                        menu.SelectNext();
                        break;

                    case ConsoleKey.Spacebar:
                        menu.SelectSub();
                        break;
                }
            }
            while (true);
        }
    }
}