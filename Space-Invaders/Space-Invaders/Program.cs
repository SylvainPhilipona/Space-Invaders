using System.Text;

namespace Space_Invaders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console encoding
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;

            //Call the menu class
            Menu menu = new Menu();
            menu.DisplayMenu();
            menu.Select();





            //Console.Read();
        }
    }
}