﻿using System;
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

            using ( RenderWindow window = new RenderWindow(new VideoMode(VideoMode.DesktopMode.Width, VideoMode.DesktopMode.Height), "Test window", Styles.Default))
            {
                Game game = new Game(new Time() , factory.NewCharacter("balrog"), factory.NewCharacter("balrog"), factory.NewStage("stage1", window) );
                GameInterface gameInterface = new GameInterface(window, game._clock);

                while ( window.IsOpen)
                {

                    game.Update();
                    gameInterface.Update(game._fighter1.GetHealth, game._fighter2.GetHealth);

                    window.DispatchEvents();

                    window.Clear();
                    window.Draw(game._stage._sprite);
                    window.Draw(game._fighter1._sprite);
                    window.Draw(game._fighter2._sprite);

                    // Draw the game interface
                    foreach(RectangleShape value in gameInterface.GetGameInterface ) window.Draw(value);
                    window.Draw(gameInterface.KO);

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