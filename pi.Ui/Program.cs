using System;
using System.Threading;
using SFML.Graphics;
using SFML.Window;
using SFML.System;


namespace pi
{
    public class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory();

            using (RenderWindow window = new RenderWindow(new VideoMode(VideoMode.DesktopMode.Width, VideoMode.DesktopMode.Height), "Test window", Styles.Default))
            {
                Game game = new Game(new Time() , factory.NewCharacter("balrog"), factory.NewCharacter("balrog"), factory.NewStage("stage1", window) );
                GameInterface gameInterface = new GameInterface(window);

                while ( window.IsOpen)
                {
                    game.Update();

                    window.DispatchEvents();

                    window.Clear();
                    window.Draw(game._stage._sprite);
                    window.Draw(game._fighter1._sprite);
                    window.Draw(game._fighter2._sprite);

                    // Draw the game interface
                    foreach(RectangleShape value in gameInterface._inteface ) window.Draw(value);
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