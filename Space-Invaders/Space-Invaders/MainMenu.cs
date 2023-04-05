///Author      : Sylvain Philipona
///Date        : 03.04.2023
///Description : Game menu

namespace Space_Invaders
{
    internal class MainMenu
    {
        private Menu menu;


        private string[] title = new string[3]
        {
            "█   █ █▀▀ █   █▀▀ █▀▀█ █▀▄▀█ █▀▀",
            "█▄█▄█ █▀▀ █   █   █  █ █ ▀ █ █▀▀",
            " ▀ ▀  ▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀▀ ▀   ▀ ▀▀▀"
        };

        private string[] options = new string[5]
        {
            "Jouer",
            "Options",
            "Highscore",
            "A propos",
            "Quitter"
        };

        private Dictionary<int, Action> optionsActions = new Dictionary<int, Action>()
        {
            { 0, () => new Game().Start()},
            { 1, () => new Options().Display()},
            { 2, () => new object()},
            { 3, () => new About().Display()},
            { 4, () => Environment.Exit(0)}
        };

        public MainMenu()
        {
            // Init the menu
            menu = new Menu(title, options, optionsActions, false);
        }

        public void Display()
        {
            Utils.SetWindowsSize(Utils.MENU_WIDTH, Utils.MENU_HEIGHT);

            menu.DisplayMenu();


            //Infinite loop
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
                }
            }
            while (true);
        }







        ////Constants
        //private const int OPTIONS_HEIGHT = 12;
        //private const int OPTIONS_HEIGHT_INCREMENT = 3;

        ////Variables

        //private string[] title = new string[3]
        //{
        //    "█   █ █▀▀ █   █▀▀ █▀▀█ █▀▄▀█ █▀▀",
        //    "█▄█▄█ █▀▀ █   █   █  █ █ ▀ █ █▀▀",
        //    " ▀ ▀  ▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀▀ ▀   ▀ ▀▀▀"
        //};



        //private int selection = 0;
        //private string[] options = new string[5]
        //{
        //    "Jouer",
        //    "Options",
        //    "Highscore",
        //    "A propos",
        //    "Quitter"
        //};

        //private Dictionary<int, Action> optionsActions = new Dictionary<int, Action>()
        //{
        //    { 0, () => new object()},
        //    { 1, () => new Options().Display()},
        //    { 2, () => new object()},
        //    { 3, () => new About().Display()},
        //    { 4, () => Environment.Exit(0)}
        //};


        ///// <summary>
        ///// Class constructor
        ///// </summary>
        //public MainMenu()
        //{

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //public void Select()
        //{
        //    // Infinite loop
        //    do
        //    {
        //        // Ask the user a keyboard input
        //        ConsoleKey input = Console.ReadKey(true).Key;

        //        switch (input)
        //        {
        //            case ConsoleKey.Enter:

        //                // Start the selected option
        //                optionsActions[selection].Invoke();

        //                break;

        //            case ConsoleKey.UpArrow:

        //                // If selection = last option => go to the first option
        //                if (selection - 1 < 0)
        //                {
        //                    selection = options.Length-1;
        //                }
        //                else
        //                {
        //                    selection--;
        //                }

        //                break;

        //            case ConsoleKey.DownArrow:

        //                // If selection = last option => go to the first option
        //                if (selection >= options.Length-1)
        //                {
        //                    selection = 0;
        //                }
        //                else
        //                {
        //                    selection++;
        //                }

        //                break;
        //        }

        //        // Display the title with the current selection
        //        Title(selection);
        //    } 
        //    while (true);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //public void DisplayMenu()
        //{
        //    //Set the windows width and height
        //    Utils.SetWindowsSize(Utils.MENU_WIDTH, Utils.MENU_HEIGHT);

        //    //Display the title and the options
        //    Title(selection);
        //}


        ///// <summary>
        ///// Display the title and the options
        ///// </summary>
        ///// <param name="selection"></param>
        //private void Title(int selection)
        //{
        //    Console.ForegroundColor = Utils.DEFAULT_COLOR;

        //    //Display the Welcome message
        //    for (int i = 0; i < title.Length; i++)
        //    {
        //        string line = title[i];
        //        int XPos = Utils.GetCenterPositionX(line, Utils.MENU_WIDTH);
        //        Console.SetCursorPosition(XPos, Utils.TITLE_HEIGHT+i);
        //        Console.WriteLine(line);
        //    }

        //    //Display all the options
        //    for (int i = 0; i < options.Length; i++)
        //    {
        //        string option = options[i];
        //        int XPos = Utils.GetCenterPositionX(option, Utils.MENU_WIDTH);
        //        int YPos = OPTIONS_HEIGHT + i * OPTIONS_HEIGHT_INCREMENT;

        //        // Display the selection
        //        if (i == selection)
        //        {
        //            DisplaySelection(option, XPos, YPos);
        //            continue;
        //        }

        //        // Clear the old selection cursor and display the option
        //        Console.SetCursorPosition(XPos - 2, YPos);
        //        Console.WriteLine(" ");
        //        Console.SetCursorPosition(XPos, YPos);
        //        Console.WriteLine(option);
        //    }
        //}

        //private void DisplaySelection(string selection, int XPos, int YPos)
        //{
        //    // Display the selection cursor and display the option
        //    Console.ForegroundColor = Utils.SELECTION_COLOR;
        //    Console.SetCursorPosition(XPos - 2, YPos);
        //    Console.WriteLine("►");
        //    Console.SetCursorPosition(XPos, YPos);
        //    Console.WriteLine(selection);
        //    Console.ForegroundColor = Utils.DEFAULT_COLOR;

        //}
    }
}