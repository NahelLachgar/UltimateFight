using System;
using System.Threading;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;

namespace UltimateFight
{
    public class Program
    {
        static void Main(string[] args)
        {
            SFML.GraphicsNative.Load();

            void OnClose(object sender, EventArgs e)
            {
                // Close the window when OnClose event is received
                RenderWindow window = (RenderWindow)sender;
                window.Close();
            }

            using ( RenderWindow window = new RenderWindow(new VideoMode(1920, 1080), "Test window", Styles.Default | Styles.Close ))
            {
                Game game = new Game(new Time() , Factory.NewCharacter("balrog"), Factory.NewCharacter("balrog"), Factory.NewStage("stage1", window) , window);
                //GameInterface gameInterface = new GameInterface(window, game._clock);
                //var w = new PlayerName(game);
                UserInterface userInterface = new UserInterface(window, game);


                while ( window.IsOpen)
                {
                   //window.SetFramerateLimit(60);
                   window.DispatchEvents();

                    window.Closed += new EventHandler(OnClose);

                    //Update
                    game.Update();

                    userInterface.Update(game);

                    window.Clear();
                    window.Draw(game._stage._sprite);
                    window.Draw(game._fighter1._shadow);
                    window.Draw(game._fighter1._sprite);
                    window.Draw(game._fighter2._shadow);
                    window.Draw(game._fighter2._sprite);

                    // Draw the game interface
                    userInterface.Draw(window);

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