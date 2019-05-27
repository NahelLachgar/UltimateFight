using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using UI;
using Model;

namespace UI
{
    public class CreateOnlineGameMenu : IAppState
    {
        RectangleShape rectangleShape = new RectangleShape();

        void Draw(RenderWindow window)
        {
            window.Draw(rectangleShape);
        }

        void Update(RenderWindow window)
        {
            Draw(window);
        }
    }
}