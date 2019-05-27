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

<<<<<<< HEAD
        public void Update(RenderWindow window)
        {
            Draw(window);
=======
            window.MouseLeft += (sender, e) =>
            {
                Game game = new Game(new Time(), Factory.NewCharacter("balrog"), Factory.NewCharacter("balrog"), Factory.NewStage("stage1"), window);
                drawer.Draw("Game", game);
            };
>>>>>>> c024e1faa1940fad830c75c797bfc6323258e1b0
        }
    }
}