///Author      : Sylvain Philipona
///Date        : 03.04.2023
///Description : Game utils

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal static class Utils
    {
        ///// CONSTANTS /////
        
        public const int MENU_WIDTH = 48;
        public const int MENU_HEIGHT = 45;
        public const int TITLE_HEIGHT = 5;


        public const int GAME_WIDTH = 200;
        public const int GAME_HEIGHT = 45;
        public const int NB_BULLETS = 250;
        public const int TIME_BETWEEN_BULLETS = 15; // Miliseconds
        public const int FPS = 60;



        public const ConsoleColor DEFAULT_COLOR = ConsoleColor.Gray;
        public const ConsoleColor SELECTION_COLOR = ConsoleColor.Green;


        public enum difficulties
        {
            Facile,
            Moyen,
            Difficile
        };

        public static Dictionary<difficulties, int> lifes = new Dictionary<difficulties, int>()
        {
            {difficulties.Facile, 5},
            {difficulties.Moyen, 3},
            {difficulties.Difficile, 1}
        };


        ///// METHODS /////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textToCenter"></param>
        /// <param name="consoleWidth"></param>
        /// <returns></returns>
        public static int GetCenterPositionX(string textToCenter, int consoleWidth)
        {
            //Formula to center text : (totalWidth / 2) - (textLength / 2)
            int txtLen = textToCenter.Length;
            int center = (consoleWidth / 2 - txtLen / 2);

            return center;
        }



        public static void SetWindowsSize(int width, int height)
        {
            //Console.WindowWidth = width;
            //Console.WindowHeight = height;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }

        public static void ClearLine(int YPos, int windowsWidth)
        {
            Console.SetCursorPosition(0, YPos);
            for (int i = 0; i < windowsWidth; i++)
            {
                Console.Write(" ");
            }
        }

        public static void SetDifficulty(int difficulty)
        {
            Configs.difficulty = (difficulties)difficulty;
        }

        public static void SetSound(bool sound)
        {
            Configs.sound = sound;
        }


    }
}
