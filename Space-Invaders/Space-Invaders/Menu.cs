///Author      : Sylvain Philipona
///Date        : 03.04.2023
///Description : Game menu

namespace Space_Invaders
{
    internal class Menu
    {
        //Constants
        private const int WINDOW_WIDTH = 48;
        private const int WINDOW_HEIGHT = 45;
        private const int TITLE_HEIGHT = 5;
        private const int OPTIONS_HEIGHT = 12;
        private const int OPTIONS_HEIGHT_INCREMENT = 3;
        private const ConsoleColor DEFAULT_COLOR = ConsoleColor.Gray;
        private const ConsoleColor SELECTION_COLOR = ConsoleColor.Green;

        //Variables

        private string[] title = new string[3]
        {
            "█   █ █▀▀ █   █▀▀ █▀▀█ █▀▄▀█ █▀▀",
            "█▄█▄█ █▀▀ █   █   █  █ █ ▀ █ █▀▀",
            " ▀ ▀  ▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀▀ ▀   ▀ ▀▀▀"
        };

        private int selection = 0;
        private string[] options = new string[5]
        {
            "Jouer",
            "Options",
            "Highscore",
            "A propos",
            "Quitter"
        };

        private Dictionary<int, Action> test = new Dictionary<int, Action>()
        {
            { 0, () => new object()},
            { 1, () => new object()},
            { 2, () => new object()},
            { 3, () => new About().Display()},
            { 4, () => Environment.Exit(0)}
        };


        /// <summary>
        /// Class constructor
        /// </summary>
        public Menu()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public void Select()
        {
            // Loop while the exit key hasen't been pressed
            bool exit = false;
            do
            {
                // Ask the user a keyboard input
                ConsoleKey input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.Enter:

                        // Start the selected option
                        test[selection].Invoke();

                        break;

                    case ConsoleKey.UpArrow:

                        // If selection = last option => go to the first option
                        if (selection - 1 < 0)
                        {
                            selection = options.Length-1;
                        }
                        else
                        {
                            selection--;
                        }

                        break;

                    case ConsoleKey.DownArrow:

                        // If selection = last option => go to the first option
                        if (selection >= options.Length-1)
                        {
                            selection = 0;
                        }
                        else
                        {
                            selection++;
                        }

                        break;

                    case ConsoleKey.Escape: 
                        exit = true; 
                        break;
                }

                // Display the title with the current selection
                Title(selection);
            } 
            while (!exit);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void DisplayMenu()
        {
            //Set the windows width and height
            Utils.SetWindowsSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            //Display the title and the options
            Title(selection);
        }


        /// <summary>
        /// Display the title and the options
        /// </summary>
        /// <param name="selection"></param>
        private void Title(int selection)
        {
            Console.ForegroundColor = DEFAULT_COLOR;

            //Display the Welcome message
            for (int i = 0; i < title.Length; i++)
            {
                string line = title[i];
                int XPos = Utils.GetCenterPositionX(line, WINDOW_WIDTH);
                Console.SetCursorPosition(XPos, TITLE_HEIGHT+i);
                Console.WriteLine(line);
            }

            //Display all the options
            for (int i = 0; i < options.Length; i++)
            {
                string option = options[i];
                int XPos = Utils.GetCenterPositionX(option, WINDOW_WIDTH);
                int YPos = OPTIONS_HEIGHT + i * OPTIONS_HEIGHT_INCREMENT;

                // Display the selection
                if (i == selection)
                {
                    DisplaySelection(option, XPos, YPos);
                    continue;
                }

                // Clear the old selection cursor and display the option
                Console.SetCursorPosition(XPos - 2, YPos);
                Console.WriteLine(" ");
                Console.SetCursorPosition(XPos, YPos);
                Console.WriteLine(option);
            }
        }

        private void DisplaySelection(string selection, int XPos, int YPos)
        {
            // Display the selection cursor and display the option
            Console.ForegroundColor = SELECTION_COLOR;
            Console.SetCursorPosition(XPos - 2, YPos);
            Console.WriteLine("►");
            Console.SetCursorPosition(XPos, YPos);
            Console.WriteLine(selection);
            Console.ForegroundColor = DEFAULT_COLOR;

        }
    }
}