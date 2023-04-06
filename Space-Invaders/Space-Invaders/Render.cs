using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Render
    {
        private static List<(int x, int y, string text)> renders = new List<(int x, int y, string text)>();

        public static void AddRender(int x, int y, string text)
        {
            renders.Add((x, y, text));
        }

        public static void RenderAll()
        {
            foreach((int x, int y, string text) render in renders)
            {
                Console.SetCursorPosition(render.x, render.y);
                Console.Write(render.text);
            }

            renders.Clear();
        }
    }
}
