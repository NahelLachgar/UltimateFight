using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using UI;

namespace UI
{
    public class GameUI
    {
        /*Game _game;
        public GameUI(Game game)
        {
            _game = game;
        }*/

       static public void Draw(RenderWindow window, Game game, Drawer drawer, GamesList gamesList)
        {
            gamesList._games.Add(game);

            window.Clear();
            window.Draw(game._stage._sprite);
            window.Draw(game._fighter2._shadow);
            window.Draw(game._fighter2._sprite);
            window.Draw(game._fighter1._shadow);
            window.Draw(game._fighter1._sprite);
            game.EndGameMenu.Draw(window);
            game._userInterface.Draw(window);
            game.Update(window);
        }
    }
}
