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
            Factory factory = new Factory();
            SFML.GraphicsNative.Load();
      
            using ( RenderWindow window = new RenderWindow(new VideoMode(1920, 1080), "Test window", Styles.Default))
            {
                Game game = new Game(new Time() , factory.NewCharacter("balrog"), factory.NewCharacter("balrog"), factory.NewStage("stage1", window) );
                GameInterface gameInterface = new GameInterface(window, game._clock);

                



                while ( window.IsOpen)
                {
                   window.SetFramerateLimit(60);
                    window.DispatchEvents();

                    //Update
                    game.Update();
                    gameInterface.Update(game._fighter1.Health, game._fighter2.Health, game._fighter1.Energy, game._fighter2.Energy);
/*
                    Console.WriteLine(game._fighter1._sprite.Position.X);
                    Console.WriteLine(" width: {0} ", game._fighter1._sprite.Position.X + game._fighter1._sprite.TextureRect.Width);
                    Console.WriteLine(game._fighter2._sprite.Position.X);  */

                    window.Clear();
                    window.Draw(game._stage._sprite);
                    window.Draw(game._fighter1._sprite);
                    window.Draw(game._fighter2._sprite);


                    // Draw the game interface
                    foreach (RectangleShape value in gameInterface.GetGameInterface ) window.Draw(value);

                    window.Draw(gameInterface.FontTime1);
                    window.Draw(gameInterface.FontTime2);
                    window.Draw(gameInterface.KO);

                    window.Draw(gameInterface.BlueFame1);
                    window.Draw(gameInterface.BlueFlame2);





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