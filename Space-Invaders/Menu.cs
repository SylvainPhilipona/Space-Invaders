///Author      : Sylvain Philipona
///Date        : 03.04.2023
///Description : Dynamic menu

using System;
using System.Collections.Generic;

namespace Space_Invaders
{
    internal class Menu
    {
        //Constants
        private const int OPTIONS_HEIGHT = 12;
        private const int OPTIONS_HEIGHT_INCREMENT = 3;

        private bool hasSubOptions = false;
        private bool canReturn;
        private int selection = 0;
        private string[] title;
        private string[] options;
        private Dictionary<int, Action> optionsActions;
        private Dictionary<int, string[]> subOptions;
        private Dictionary<int, int> subSelections;

        public Menu(string[] title, string[] options, Dictionary<int, Action> optionsActions, bool canReturn)
        {
            this.title = title;
            this.options = options;
            this.optionsActions = optionsActions;
            this.canReturn = canReturn;
        }

        public Menu(string[] title, string[] options, Dictionary<int, Action> optionsActions, Dictionary<int, string[]> subOptions, bool canReturn)
        {
            this.title = title;
            this.options = options;
            this.optionsActions = optionsActions;

            this.subOptions = subOptions;
            this.hasSubOptions = true;

            this.subSelections = new Dictionary<int, int>();
            foreach(var subOption in subOptions)
            {
                this.subSelections.Add(subOption.Key, 1);
            }

            this.canReturn = canReturn;
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

        public int[] SelectNextSub()
        {
            if(subSelections[selection] >= subOptions[selection].Length - 1)
            {
                subSelections[selection] = 0;
            }
            else
            {
                subSelections[selection]++;
            }

            

            DisplayMenu();

            return new int[2] { selection, subSelections[selection] };
        }

        public int[] SelectPreviousSub()
        {
            if(subSelections[selection] - 1 < 0)
            {
                subSelections[selection] = subOptions[selection].Length - 1;
            }
            else
            {
                subSelections[selection]--;
            }

            DisplayMenu();

            return new int[2] { selection, subSelections[selection] };
        }

        public void SelectCurrent()
        {
            // Start the selected option
            optionsActions[selection].Invoke();
        }

        public void DisplayMenu()
        {
            //Console.Clear();

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

                if (hasSubOptions)
                {
                    string option = options[i];
                    string subOption = "";
                    string result = option;

                    if (subOptions[i].Length > 0)
                    {
                        subOption = subOptions[i][subSelections[i]];
                        result = $"{option}:{subOption}";
                    }

                    int XPos = Utils.GetCenterPositionX(result, Utils.MENU_WIDTH);
                    int YPos = OPTIONS_HEIGHT + i * OPTIONS_HEIGHT_INCREMENT;
                    Utils.ClearLine(YPos, Utils.MENU_WIDTH);

                    // Display the selection
                    if (i == selection)
                    {
                        DisplaySelection(result, XPos, YPos);
                        continue;
                    }

                    Console.SetCursorPosition(XPos - 2, YPos);
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(XPos, YPos);
                    Console.WriteLine(result);
                }
                else
                {
                    string option = options[i];
                    int XPos = Utils.GetCenterPositionX(option, Utils.MENU_WIDTH);
                    int YPos = OPTIONS_HEIGHT + i * OPTIONS_HEIGHT_INCREMENT;
                    Utils.ClearLine(YPos, Utils.MENU_WIDTH);

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

            if (canReturn)
            {
                //DisplayReturn(OPTIONS_HEIGHT + options.Length * OPTIONS_HEIGHT_INCREMENT);

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

        private void DisplayReturn(int YPos)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Utils.GetCenterPositionX("Retour", Utils.MENU_WIDTH), YPos);
            Console.WriteLine("Retour");
            Console.ForegroundColor = Utils.DEFAULT_COLOR;
        }






    }
}
