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

            using (RenderWindow window = new RenderWindow(new VideoMode(1920, 1080), "Ultimate Fight",  Styles.Close))

            {
                IAppState _state;
                //MainMenu mainMenu = new MainMenu(window);
                bool _gameCreate = false;
                Menus menus = new Menus(window);
                //Game game = new Game(new Time(), Factory.NewCharacter("balrog"), Factory.NewCharacter("sagat"), Factory.NewStage("stage1"), window);
                Game game = null;
                //_state = new MenuUI(menus);
                _state = menus;

                while (window.IsOpen)
                {
                    //window.SetFramerateLimit(60);
                    window.DispatchEvents();
                    window.Clear();

                    
                    //if ( menus._startGame._characterMenu._chooseOptionMenu == 2 )
                    //{
                    //    if ( _gameCreate == false )
                    //    {
                    //        game = new Game(new Time(), Factory.NewCharacter(menus._startGame._characterMenu._avatars._characterPlayer1.ToLower()), Factory.NewCharacter(menus._startGame._characterMenu._avatars._characterPlayer2.ToLower()), Factory.NewStage("stage1"), window);
                    //        _gameCreate = true;

                    //    }

                    //    _state._nextState = new GameUI(game);
                    //}


                    //_state = new GameUI(game);

                    _state = _state.Update(window);
                    _state.Draw(window);
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

        private static void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}