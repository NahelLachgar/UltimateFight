using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using UI;
namespace UI
{
    public class Menus
    {

        MainMenu _mainMenu;
        public StartGame _startGame = new StartGame();

        public Menus(RenderWindow window)
        {
            _mainMenu = new MainMenu(window);
        }


        public void Update(RenderWindow window)
        {
            _mainMenu.Update(window, this);

        }

        public void Draw(RenderWindow window)
        {
            _mainMenu.Draw(window);
            this.RedirectionMenu(window);

        }


        private void RedirectionMenu(RenderWindow window)
        {
            switch ( _mainMenu._chooseOptionMenu )
            {
                case 0:  // Option : "Start Game"
                    _startGame.Draw(window, _mainMenu);
                    break;

                case 1:  // Option : "Option"
                    break;

                case 2:  // Option : "Statistiques"
                    break;

                case 3:  // Option : "Coups spéciaux"
                    break;

                case 4:  // Option : "Crédit"
                    break;

                case 5:  // Option : "Exit"
                    window.Close();
                    break;

                default: // Main menu with all options
                    _mainMenu._chooseOptionMenu = -1;
                    break;
            }
        }
    }
}
