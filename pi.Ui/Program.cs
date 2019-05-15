using System;
using System.Threading;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using Model;
using UI;

namespace Ui
{
    public class Program
    {   
        static void Main(string[] args)
        {
            using (RenderWindow window = new RenderWindow(new VideoMode(1920, 1080), "Ultimate Fight", Styles.Default | Styles.Close))

            {
<<<<<<< HEAD
                Game game = new Game(new Time(), Factory.NewCharacter("balrog"), Factory.NewCharacter("balrog"), Factory.NewStage("stage1", window), window);

                GamesList _gamesList = new GamesList();

                Drawer _drawer = new Drawer(window, _gamesList);
                _drawer.Draw("Game", _drawer, game);
=======
                Game game = new Game(new Time() , Factory.NewCharacter("balrog"), Factory.NewCharacter("balrog"), Factory.NewStage("stage1") , window);
>>>>>>> 6986839d3fa4f6126d4c81a6d77b58930eb656ec


                while (window.IsOpen)
                {
<<<<<<< HEAD
                    //window.SetFramerateLimit(60);
                    window.DispatchEvents();

                    //Update
                    /* foreach (Game g in _gamesList._games)
                      {
                          g.Update(window);
                          g._userInterface.Update(g);
                          g._userInterface.Draw(window);
                      }*/
                    //while (_drawer._page == "Game")
                        _drawer.Draw("Game", _drawer, game);
=======
                   //window.SetFramerateLimit(60);
                    window.DispatchEvents();

                    //Update
                    game.Update(window);

                    //userInterface.Update(game);

                    window.Clear();
                    window.Draw(game._stage._sprite);
                    window.Draw(game._fighter2._shadow);
                    window.Draw(game._fighter2._sprite);
                    window.Draw(game._fighter1._shadow);
                    window.Draw(game._fighter1._sprite);

                    // Draw the game interface
                    //userInterface.Draw(window);
                    game.userInterface.Draw(window);
                    game.menuEndGame.Draw(window);
>>>>>>> 6986839d3fa4f6126d4c81a6d77b58930eb656ec

                    window.Display();

                    //Event for close the program

                    window.Closed += new EventHandler(OnClose);
                    void OnClose(object sender, EventArgs e)
                    {
<<<<<<< HEAD
                        // Close the window when OnClose event is received
                        window.Close();
                    }
=======
                        //if ( e.Code == Keyboard.Key.Escape ) window.Close();
                    };

>>>>>>> 6986839d3fa4f6126d4c81a6d77b58930eb656ec
                }
            }
        }  
    }
}