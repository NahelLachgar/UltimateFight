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

            Game game = new Game(new Time() , factory.NewCharacter("balrog"), factory.NewCharacter("balrog"),factory.NewStage("stage1"));
            using (RenderWindow window = new RenderWindow(VideoMode.DesktopMode, "Test window", Styles.Default))
            {
                while (window.IsOpen)
                {
                    game.Update();


                    window.DispatchEvents();

                    window.Clear();
                    window.Draw(game._stage._sprite);
                    window.Draw(game._fighter1._sprite);
                    window.Draw(game._fighter2._sprite);
                    window.Display();

                    window.KeyPressed += (sender, e) =>
                    {
                        if ( e.Code == Keyboard.Key.Escape ) window.Close();
                    };

                }
            }
        }
    }
}