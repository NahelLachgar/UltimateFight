using System;
using System.Threading;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace pi
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();
            using (RenderWindow window = new RenderWindow(VideoMode.DesktopMode, "Test window"))
            {
                while (window.IsOpen)
                {
                    game.Update();



                }
            }
        }
    }
}