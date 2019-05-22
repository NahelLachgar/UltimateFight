using Model;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using UI;

namespace UI
{
    public class Drawer
    {
        public string _page;
        RenderWindow _window;
        GamesList _gamesList;


        public Drawer(RenderWindow window, GamesList gamesList)
        {
            _window = window;
            _gamesList = gamesList;
        }

        public void Draw(string page, Game game = null)
        {
            _page = page;
            switch (page)
            {
                case "Game":
                     GameUI.Draw(_window, game, _gamesList);
                     break;
                case "CreateGameMenu":
                    CreateGameMenu.Draw(_window, this);
                    break;
                case "CreateOnlineGameMenu":
                    CreateOnlineGameMenu.Draw(_window, this);
                    break;
            }
        }
    }
}
