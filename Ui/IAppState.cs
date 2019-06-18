using Model;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using UI;

namespace UI
{
    public interface IAppState
    {
        IAppState _nextState { get; set; }
        void Draw(RenderWindow window);
        IAppState Update(RenderWindow window);
    }
}