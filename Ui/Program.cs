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

namespace UI
{
    public class Program
    {   
        static void Main(string[] args)
        {
            using (RenderWindow window = new RenderWindow(new VideoMode(1920, 1080), "Ultimate Fight", Styles.Default | Styles.Close))

            {
                Game game = new Game(new Time(), Factory.NewCharacter("balrog"), Factory.NewCharacter("balrog"), Factory.NewStage("stage1"), window);

                GamesList _gamesList = new GamesList();

                Drawer _drawer = new Drawer(window, _gamesList);
                _drawer.Draw("Game", game);


                while (window.IsOpen)
                {
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
                    _drawer.Draw("Game", game);

                    window.Display();

                    //Event for close the program

                    window.Closed += new EventHandler(OnClose);
                    void OnClose(object sender, EventArgs e)
                    {
                        // Close the window when OnClose event is received
                        window.Close();
                    }
                }
            }
        }  
    }
}