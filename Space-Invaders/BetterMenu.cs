using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class BetterMenu
    {
        // Constants
        private const int OPTIONS_HEIGHT = 12;
        private const int OPTIONS_HEIGHT_INCREMENT = 3;

        // Variables
        private string[] title;
        private List<string> options;
        private Dictionary<int, Action> actions;
        private Dictionary<int, List<string>> subOptions;
        private Dictionary<int, int> subSelections;
        private int selection;
        private int subSelection;

        public BetterMenu(string[] title) 
        { 
            this.title = title;
            options= new List<string>();
            actions= new Dictionary<int, Action>();
            subOptions = new Dictionary<int, List<string>>();
            subSelections = new Dictionary<int, int>();
            selection= 0;
            subSelection = 0;
        }

        /*********************************/
        /*          DECLARATION          */
        /*********************************/

        public int AddOption(string option, Action action)
        {
            options.Add(option);
            int index = options.IndexOf(option);
            actions.Add(index, action);
            subOptions.Add(index, new List<string>());
            return index;
        }

        public void AddSubOption(int option, string subOption)
        {
            subOptions[option].Add(subOption);
            subSelections[option] = 0;
        }

        public void RemoveOption(string option)
        {
            options.Remove(option);
        }

        public void RemoveSubOption(int option, string subOption)
        {

        }

        /*********************************/
        /*           SELECTION           */
        /*********************************/

        public void SelectNext()
        {
            // Check if the last options is already selected
            if(selection >= options.Count - 1)
            {
                // Select the first option
                selection = 0;
            }
            else
            {
                // Select the next option
                selection++;
            }

            subSelection = 0;
        }

        public void SelectPrevious()
        {
            // Check if the last options is already selected
            if (selection <= 0)
            {
                // Select the last option
                selection = options.Count - 1;
            }
            else
            {
                // Select the previous option
                selection--;
            }

            subSelection = 0;
        }

        public void SelectSub()
        {
            if(subSelections.ContainsKey(selection))
            {
                if (subSelections[selection] + 1 >= subOptions[selection].Count)
                {
                    subSelections[selection] = 0;
                }
                else
                {
                    subSelections[selection]++;

                }
            }
            

        }

        public void SelectCurrent()
        {
            // Invoke the action of the selection
            actions[selection].Invoke();
        }

        /*********************************/
        /*            DISPLAY            */
        /*********************************/

        public void Display()
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
            for (int i = 0; i < options.Count; i++)
            {
                // Get the option
                string option = options[i];
                var index = options.IndexOf(option);

                // Check for suboptions
                if (subOptions[index].Count != 0 && selection == i)
                {
                    option += $" : {subOptions[selection][subSelections[index]]}";
                }

                // Calculate the option position
                int XPos = Utils.GetCenterPositionX(option, Utils.MENU_WIDTH);
                int YPos = OPTIONS_HEIGHT + i * OPTIONS_HEIGHT_INCREMENT;
                Utils.ClearLine(YPos, Utils.MENU_WIDTH);


                // If the options is the current selected
                if(i == selection)
                {
                    // Display the options with a selection cursor
                    DisplaySelection(option, XPos, YPos);
                }
                else
                {
                    // Clear the old selection cursor and display the option
                    Console.SetCursorPosition(XPos - 2, YPos);
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(XPos, YPos);
                    Console.WriteLine(option);
                }
               

                

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
