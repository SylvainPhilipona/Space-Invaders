//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Space_Invaders
//{
//    internal class Options : Menu
//    {


//        private string[] title = new string[3]
//        {
//            "█▀▀█ █▀▀█ ▀▀█▀▀ █ █▀▀█ █▄  █ █▀▀",
//            "█  █ █▀▀▀   █   █ █  █ █ █ █ ▀▀█",
//            "▀▀▀▀ ▀      ▀   ▀ ▀▀▀▀ ▀  ▀▀ ▀▀▀"
//        };


//        public Options()
//        {


//        }

//        public void Display()
//        {
//            Console.Clear();

//            Title(1);








//            //While enter touch not pressed
//            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
//            {

//            }
//            Console.Clear();
//        }





//        private void Title(int selection)
//        {
//            //Display the Options message
//            for (int i = 0; i < title.Length; i++)
//            {
//                string line = title[i];
//                int XPos = Utils.GetCenterPositionX(line, Utils.MENU_WIDTH);
//                Console.SetCursorPosition(XPos, Utils.TITLE_HEIGHT + i);
//                Console.WriteLine(line);
//            }
//        }
//    }
//}
