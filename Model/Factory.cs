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
                    _animationRect.Add("waiting1", new IntRect(4, 17, 45, 93));
                    _animationRect.Add("waiting2", new IntRect(57, 17, 45, 93));
                    _animationRect.Add("waiting3", new IntRect(112, 17, 45, 93));
                    _animationRect.Add("waiting4", new IntRect(168, 17, 45, 93));
                    // WALKING
                    _animationRect.Add("walking1", new IntRect(227, 17, 45, 93));
                    _animationRect.Add("walking2", new IntRect(281, 17, 45, 93));
                    _animationRect.Add("walking3", new IntRect(337, 17, 45, 93));
                    _animationRect.Add("walking4", new IntRect(394, 17, 45, 93));
                    // CROUCH
                    _animationRect.Add("crouch1", new IntRect(786, 17, 45, 93));
                    _animationRect.Add("crouch2", new IntRect(837, 17, 43, 93));
                    // JUMP
                    _animationRect.Add("jump1", new IntRect(733, 17, 43, 93));
                    _animationRect.Add("jump2", new IntRect(594, 17, 38, 93));
                    _animationRect.Add("jump3", new IntRect(641, 17, 39, 93));
                    // LIGHT PUNCH
                    _animationRect.Add("lightPunch1", new IntRect(5, 137, 55, 93));
                    _animationRect.Add("lightPunch2", new IntRect(64, 137, 74, 93));
                    // LIGHT KICK
                    _animationRect.Add("lightKick1", new IntRect(5, 248, 68, 94));
                    _animationRect.Add("lightKick2", new IntRect(81, 248, 74, 94));



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