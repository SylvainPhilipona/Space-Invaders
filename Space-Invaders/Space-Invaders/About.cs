///Author      : Sylvain Philipona
///Date        : 03.04.2023
///Description : Game about

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class About
    {
        public About() 
        {
        
        }

        public void Display()
        {
            Console.Clear();








            //Controls
            Console.ForegroundColor = Utils.DEFAULT_COLOR;
            Console.SetCursorPosition(0, 1);
            Console.WriteLine(CenterText("Commandes :"));
            Console.SetCursorPosition(0, 3);
            Console.WriteLine(CenterText("(fleche de droite) = déplacement vers la droite"));
            Console.SetCursorPosition(0, 5);
            Console.WriteLine(CenterText("(fleche de gauche) = déplacement vers la gauche"));
            Console.SetCursorPosition(0, 7);
            Console.WriteLine(CenterText("(barre espace) = tirer"));
            Console.ForegroundColor = Utils.DEFAULT_COLOR;

            //Pages
            Console.ForegroundColor = Utils.DEFAULT_COLOR;
            Console.SetCursorPosition(0, 10);
            Console.WriteLine(CenterText("Jouer: vous rentrez dans une page de selection"));
            Console.WriteLine(CenterText("de skin, puis après  ça vous commencer à jouer"));
            Console.SetCursorPosition(0, 14);
            Console.WriteLine(CenterText("Option: vous allez dans la page option où vous"));
            Console.WriteLine(CenterText("pouvez régler le son, la dificulté et la"));
            Console.WriteLine(CenterText("couleur du vaisseau"));
            Console.SetCursorPosition(0, 19);
            Console.WriteLine(CenterText("Highscore: vous voyez les meilleurs scores"));
            Console.WriteLine(CenterText("réalisés"));
            Console.SetCursorPosition(0, 23);
            Console.WriteLine(CenterText("Quitter: vous quittez l'application"));
            Console.ForegroundColor = Utils.DEFAULT_COLOR;

            //Credits
            Console.ForegroundColor = Utils.DEFAULT_COLOR;
            Console.SetCursorPosition(0, 28);
            Console.WriteLine(CenterText("Créé par:"));
            Console.SetCursorPosition(0, 30);
            Console.WriteLine(CenterText("Sylvain Philipona"));
            Console.ForegroundColor = Utils.DEFAULT_COLOR;

            //Return button
            Console.ForegroundColor = Utils.SELECTION_COLOR;
            Console.SetCursorPosition(0, 37);
            Console.Write(CenterText("Retour"));

            //Cursor
            Console.SetCursorPosition(18, 37);
            Console.Write("►");
            Console.ForegroundColor = Utils.DEFAULT_COLOR;



            //While enter touch not pressed
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {

            }

            Console.Clear();
        }

        /// <summary>
        /// Allows you to center a text
        /// </summary>
        /// <param name="textToCenter"></param>
        /// <returns></returns>
        private static string CenterText(string textToCenter)
        {
            return String.Format("{0," + ((Console.WindowWidth / 2) + (textToCenter.Length / 2)) + "}", textToCenter);
        }
    }
}
