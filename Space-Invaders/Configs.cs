using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal static class Configs
    {
        public static Utils.difficulties difficulty = Utils.difficulties.Moyen;
        public static bool sound = true; //On
        public static int nbBullets = 250;
        public static int timeBetweenBullets = 15; // Miliseconds
        public static int FPS = 60;

        public static List<(int x, int y)> wallsCollisions = new List<(int x, int y)>();
    }
}
