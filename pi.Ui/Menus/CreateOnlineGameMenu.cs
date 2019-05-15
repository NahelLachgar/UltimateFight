using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using Ui;
using Model;

namespace UI
{
    public static class CreateOnlineGameMenu
    {
        public static void Draw(RenderWindow window, Drawer drawer)
        {
            window.Clear();
            RectangleShape rectangle = new RectangleShape(new Vector2f(550, 200));
            window.Draw(rectangle);

            window.MouseLeft += (sender, e) =>
            {
                Game game = new Game(new Time(), Factory.NewCharacter("balrog"), Factory.NewCharacter("balrog"), Factory.NewStage("stage1", window), window);
                drawer.Draw("Game", drawer, game);
            };
        }
    }
}