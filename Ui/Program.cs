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

            using (RenderWindow window = new RenderWindow(new VideoMode(1920, 1080), "Ultimate Fight", Styles.Fullscreen | Styles.Close))

            {
                //MainMenu mainMenu = new MainMenu(window);
                bool _gameCreate = false;
                Menus menus = new Menus(window);
                Game game = new Game(new Time(), Factory.NewCharacter("balrog"), Factory.NewCharacter("chun-li"), Factory.NewStage("stage6"), window);
                //Game game = null;

                while (window.IsOpen)
                {
                    //window.SetFramerateLimit(60);
                    window.DispatchEvents();

                /*    _cs.State = new MenuUI(menus);
                    if ( menus._startGame._characterMenu._chooseOptionMenu == 2 )
                    {
                        if ( _gameCreate == false )
                        {
                            game = new Game(new Time(), Factory.NewCharacter(menus._startGame._characterMenu._avatars._characterPlayer1.ToLower()), Factory.NewCharacter(menus._startGame._characterMenu._avatars._characterPlayer2.ToLower()), Factory.NewStage("stage1"), window);
                            _gameCreate = true;

                        }

                        _cs.State = new GameUI(game);
                    }*/


                    _cs.State = new GameUI(game);

                    _cs.Update(window);
                    _cs.Draw(window);
                    window.Display();

                    //Event for close the program


                    if (Keyboard.IsKeyPressed(Keyboard.Key.F4)) window.Close();


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