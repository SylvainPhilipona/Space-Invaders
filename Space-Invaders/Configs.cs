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
        public static int nbBullets = 50;

        public static readonly object obj = new object();

        public static List<(int x, int y)> wallsCollisions = new List<(int x, int y)>();


    }
}
