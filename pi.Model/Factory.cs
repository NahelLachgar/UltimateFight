using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public static class Factory
    {
        static public Character CreateCharacter(string name, string img, IntRect rect, Vector2f scale)
        {
            Texture texture = new Texture("../../../../img/characters/" + img);
            texture.Smooth = true;
            Sprite sprite = new Sprite(texture);
            sprite.Scale = scale;
            sprite.TextureRect = new IntRect(rect.Left, rect.Top, rect.Width, rect.Height);
            Character character = new Character(name, sprite);
            return character;
        }

        static public Stage CreateStage(string name, string img, int groundHeight, RenderWindow window)
        {
            Texture texture = new Texture("../../../../img/stages/" + img);
            //Sprite sprite = new Sprite(texture);
            //sprite.Scale = scale;

            Stage stage = new Stage(name, /*sprite,*/ groundHeight, window, texture);
            return stage;
        }

        static public Character NewCharacter(string name)
        {
            switch (name)
            {
                case "balrog":
                    Character character = CreateCharacter("Balrog", "balrog.png", new IntRect(4, 17, 45, 93), new Vector2f(5, 5));
                    return character;
                default:
                    return null;
            }
        }

        static public Stage NewStage(string name, RenderWindow window)
        {
            switch (name)
            {
                case "stage1":
                    Stage stage = CreateStage("stage1", "stage1.jpg", 500, window);
                    return stage;
                default:
                    return null;
            }
        }

    }
}