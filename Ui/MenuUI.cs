using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using UI;

namespace UI
{
    public class MenuUI : IAppState
    {
        Menus _menus;

        public MenuUI(Menus menus)
        {
            _menus = menus;
            _nextState = this;

        }

        public IAppState _nextState { get; set; }


        public void Draw(RenderWindow window)
        {
            _menus.Draw(window);
        }

        public IAppState Update(RenderWindow window)
        {
            _menus.Update(window);
            return _nextState;
        }
    }
}
