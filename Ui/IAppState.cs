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
        void Draw(RenderWindow window);
        void Update(RenderWindow window);
    }
}