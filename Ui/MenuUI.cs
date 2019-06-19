﻿using SFML.Graphics;
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
        }

        public void Draw(RenderWindow window)
        {
            _menus.Draw(window);
        }

        public void Update(RenderWindow window)
        {
            _menus.Update(window);
        }
    }
}