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
    public class CreateGameMenu : IAppState
    {
         IAppState nextState { get; set; }

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