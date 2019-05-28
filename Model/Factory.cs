using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public static class Factory
    {
        static public Character CreateCharacter(string name, string img, Dictionary<string, IntRect> animationSprite, Vector2f scale)
        {
            Texture texture = new Texture("../../../../img/characters/" + img);
            texture.Smooth = true;
            Sprite sprite = new Sprite(texture);
            sprite.Scale = scale;
        //    sprite.TextureRect = new IntRect(rect.Left, rect.Top, rect.Width, rect.Height);
            Character character = new Character(name, sprite, animationSprite);
            return character;
        }

        static public Stage CreateStage(string name, string img, int groundHeight)
        {
            Texture texture = new Texture("../../../../img/stages/" + img);
            //Sprite sprite = new Sprite(texture);
            //sprite.Scale = scale;

            Stage stage = new Stage(name, /*sprite,*/ groundHeight, texture);
            return stage;
        }

        static public Character NewCharacter(string name)
        {
            switch (name)
            {
                case "balrog":
                    Dictionary<string, IntRect> _animationRect = new Dictionary<string, IntRect>();
                    // WAITING
                    _animationRect.Add("Waiting1", new IntRect(4, 17, 45, 93));
                    _animationRect.Add("Waiting2", new IntRect(57, 17, 45, 93));
                    _animationRect.Add("Waiting3", new IntRect(112, 17, 45, 93));
                    _animationRect.Add("Waiting4", new IntRect(168, 17, 45, 93));

                    Character character = CreateCharacter("Balrog", "balrog.png", _animationRect, new Vector2f(5, 5));
                    return character;
                default:
                    return null;
            }
        }

        static public Stage NewStage(string name)
        {
            switch (name)
            {
                case "stage1":
                    Stage stage = CreateStage("stage1", "stage1.jpg", 580);
                    return stage;
                default:
                    return null;
            }
        }

    }
}