using System;
using System.Threading;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;

namespace pi
{
    public class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            SFML.GraphicsNative.Load();

            using ( RenderWindow window = new RenderWindow(new VideoMode(VideoMode.DesktopMode.Width, VideoMode.DesktopMode.Height), "Test window", Styles.Default))
            {
                Game game = new Game(new Time() , factory.NewCharacter("balrog"), factory.NewCharacter("balrog"), factory.NewStage("stage1", window) );
                GameInterface gameInterface = new GameInterface(window, game._clock);

                // PLAYERS'S POSITIONS
                game._fighter1._sprite.Position = new Vector2f(250, 450);
                game._fighter2._sprite.Position = new Vector2f(1500, 450);



                while ( window.IsOpen)
                {
                    //Update
                    game.Update();
                    gameInterface.Update(game._fighter1.Health, game._fighter2.Health);
                    

                    window.DispatchEvents();

                    window.Clear();
                    window.Draw(game._stage._sprite);
                    window.Draw(game._fighter1._sprite);
                    window.Draw(game._fighter2._sprite);


                    // Draw the game interface
                    foreach (RectangleShape value in gameInterface.GetGameInterface ) window.Draw(value);
                    window.Draw(gameInterface.FontTime1);
                    window.Draw(gameInterface.FontTime2);
                    window.Draw(gameInterface.KO);
                    window.Draw(gameInterface.BackEnergyBar1_1);
                    window.Draw(gameInterface.BackEnergyBar1_2);
                    window.Draw(gameInterface.BackEnergyBar2_1);
                    window.Draw(gameInterface.BackEnergyBar2_2);

                    window.Display();
                    
                    /***   Event for close the program.   ***/
                    window.KeyPressed += (sender, e) =>
                    {
                        if ( e.Code == Keyboard.Key.Escape ) window.Close();
                    };

                }
            }
        }
    }
}