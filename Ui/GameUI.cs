using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using UI;

namespace UI
{
    public class GameUI : IAppState
    {
        Game _game;

        public GameUI(Game game)
        {
            _game = game;
        }

        public IAppState _nextState { get; set; }

        public void Draw(RenderWindow window)
        {
            //window.Clear();
            window.Draw(_game._stage._sprite);
            window.Draw(_game._fighter2._shadow);
            window.Draw(_game._fighter2._sprite);
            window.Draw(_game._fighter1._shadow);
            window.Draw(_game._fighter1._sprite);
            window.Draw(_game._fighter1._projectile.Sprite);
            _game._gameEndMenu.Draw(window);
            _game._userInterface.Draw(window);
        }


        public IAppState Update(RenderWindow window)
        {
            _game.Update(window);
            _nextState = this;
            return _nextState;
        }
    }
}