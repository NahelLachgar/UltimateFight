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
            CurrentState _cs = new CurrentState();

            using (RenderWindow window = new RenderWindow(new VideoMode(1920, 1080), "Ultimate Fight", Styles.Default | Styles.Close))

            {
                Game game = new Game(new Time(), Factory.NewCharacter("balrog"), Factory.NewCharacter("balrog"), Factory.NewStage("stage1"), window);

<<<<<<< HEAD
=======
                GamesList _gamesList = new GamesList();

                Drawer _drawer = new Drawer(window, _gamesList);
                _drawer.Draw("Game", game);


>>>>>>> c024e1faa1940fad830c75c797bfc6323258e1b0
                while (window.IsOpen)
                {
                    //window.SetFramerateLimit(60);
                    window.DispatchEvents();

<<<<<<< HEAD
                    if(game.EndGameMenu._replay == true )
                    game = new Game(new Time(), Factory.NewCharacter("balrog"), Factory.NewCharacter("balrog"), Factory.NewStage("stage1"), game._window);
                    _cs.State = new GameUI(game);
                    _cs.Update(window);
                    _cs.Draw(window);
=======
                    //while (_drawer._page == "Game")
                    _drawer.Draw("Game", game);

>>>>>>> c024e1faa1940fad830c75c797bfc6323258e1b0
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