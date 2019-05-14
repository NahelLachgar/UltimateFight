using Model;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using Ui;

namespace UI
{
    public class Drawer
    {
        RenderWindow _window;
        GamesList _gamesList;


        public Drawer(RenderWindow window, GamesList gamesList)
        {
            _window = window;
            _gamesList = gamesList;

        }

        public void Draw(string page, Drawer drawer, Game game = null)
        {
            switch (page)
            {
                case "Game":
                     GameUI.Draw(_window, game, drawer, _gamesList);
                     break;
                case "CreateGameMenu":
                    CreateGameMenu.Draw(_window, drawer);
                    break;
            }
        }
    }
}
