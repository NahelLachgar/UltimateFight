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

        RectangleShape rectangleShape = new RectangleShape();

        public void Draw(RenderWindow window)
        {
            window.Draw(rectangleShape);
        }

        public void Update(RenderWindow window)
        {
            Draw(window);
        }
    }
}