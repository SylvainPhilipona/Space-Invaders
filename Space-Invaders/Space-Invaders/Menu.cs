using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Menu
    {
        //Constants
        private const int OPTIONS_HEIGHT = 12;
        private const int OPTIONS_HEIGHT_INCREMENT = 3;


        private int selection = 0;
        private string[] title = new string[3];
        private string[] options = new string[5];
        private Dictionary<int, Action> optionsActions = new Dictionary<int, Action>();

        public Menu(string[] title, string[] options, Dictionary<int, Action> optionsActions)
        {
            this.title = title;
            this.options = options;
            this.optionsActions = optionsActions;
        }

        public Menu(string[] title, string[] options, Dictionary<int, Action> optionsActions, bool subOptions)
        {
            this.title = title;
            this.options = options;
            this.optionsActions = optionsActions;
        }

        public void SelectNext()
        {
            // If selection = last option => go to the first option
            if (selection >= options.Length - 1)
            {
                selection = 0;
            }
            else
            {
                selection++;
            }

            DisplayMenu();
        }

        public void SelectPrevious()
        {
            //If selection = last option => go to the first option
            if (selection - 1 < 0)
            {
                selection = options.Length - 1;
            }
            else
            {
                selection--;
            }

            DisplayMenu();
        }

        public void SelectCurrent()
        {
            // Start the selected option
            optionsActions[selection].Invoke();
        }

        public void DisplayMenu()
        {
            // Display the title message
            for (int i = 0; i < title.Length; i++)
            {
                string line = title[i];
                int XPos = Utils.GetCenterPositionX(line, Utils.MENU_WIDTH);
                Console.SetCursorPosition(XPos, Utils.TITLE_HEIGHT + i);
                Console.WriteLine(line);
            }

            //Display all the options
            for (int i = 0; i < options.Length; i++)
            {
                string option = options[i];
                int XPos = Utils.GetCenterPositionX(option, Utils.MENU_WIDTH);
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
            Console.ForegroundColor = Utils.SELECTION_COLOR;
            Console.SetCursorPosition(XPos - 2, YPos);
            Console.WriteLine("►");
            Console.SetCursorPosition(XPos, YPos);
            Console.WriteLine(selection);
            Console.ForegroundColor = Utils.DEFAULT_COLOR;

        }






    }
}
