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
            Factory factory = new Factory();
            //BALROG

            Game game = new Game(new Time() , factory.NewCharacter("balrog"), factory.NewCharacter("balrog"));
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