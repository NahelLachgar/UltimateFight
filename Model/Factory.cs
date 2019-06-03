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
            Dictionary<string, IntRect> _animationRect = new Dictionary<string, IntRect>();
            switch (name)
            {
                case "balrog":
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
                    _animationRect.Add("lightKick1", new IntRect(4, 17, 45, 93));
                    _animationRect.Add("lightKick2", new IntRect(5, 248, 68, 94));
                    _animationRect.Add("lightKick3", new IntRect(81, 248, 74, 94));
                    // JUMP LIGHT
                    _animationRect.Add("jumpLight", new IntRect(22, 498, 55, 84));
                    // CROUCH LIGHT
                    _animationRect.Add("crouchLight1", new IntRect(5, 377, 47, 93));
                    _animationRect.Add("crouchLight2", new IntRect(63, 377, 67, 93));
                    // FACE HIT
                    _animationRect.Add("faceHit1", new IntRect(196, 851, 44, 100));
                    _animationRect.Add("faceHit2", new IntRect(252, 851, 46, 100));
                    _animationRect.Add("faceHit3", new IntRect(301, 851, 49, 100));
                    // CROUCH HIT
                    _animationRect.Add("crouchHit", new IntRect(358, 855, 49, 93));
                    // KO
                    _animationRect.Add("ko1", new IntRect(7, 986, 42, 93));
                    _animationRect.Add("ko2", new IntRect(61, 986, 62, 93));
                    _animationRect.Add("ko3", new IntRect(132, 986, 70, 98));

                    Character character = CreateCharacter("Balrog", "balrog.png", _animationRect, new Vector2f(5, 5));
                    return character;
                case "sagat":
                    // WAITING
                    _animationRect.Add("waiting1", new IntRect(6, 24, 52, 106));
                    _animationRect.Add("waiting2", new IntRect(65, 24, 52, 106));
                    _animationRect.Add("waiting3", new IntRect(124, 24, 52, 106));
                    _animationRect.Add("waiting4", new IntRect(183, 24, 52, 106));
                    // WALKING
                    _animationRect.Add("walking1", new IntRect(310, 24, 52, 106));
                    _animationRect.Add("walking2", new IntRect(372, 22, 52, 106));
                    _animationRect.Add("walking3", new IntRect(431, 21, 52, 106));
                    _animationRect.Add("walking4", new IntRect(490, 22, 52, 106));
                    // CROUCH
                    _animationRect.Add("crouch1", new IntRect(834, 45, 51, 85));
                    _animationRect.Add("crouch2", new IntRect(892, 72, 55, 58));
                    // JUMP
                    _animationRect.Add("jump1", new IntRect(682, 15, 37, 115));
                    _animationRect.Add("jump2", new IntRect(732, 15, 39, 115));
                    _animationRect.Add("jump3", new IntRect(732, 15, 39, 115));
                    // LIGHT PUNCH
                    _animationRect.Add("lightPunch1", new IntRect(4, 156, 66, 99));
                    _animationRect.Add("lightPunch2", new IntRect(79, 156, 82, 99));
                    // LIGHT KICK
                    _animationRect.Add("lightKick1", new IntRect(83, 404, 63, 112));
                    _animationRect.Add("lightKick2", new IntRect(154, 404, 58, 112));
                    _animationRect.Add("lightKick3", new IntRect(224, 404, 97, 112));
                    // JUMP LIGHT
                    _animationRect.Add("jumpLight", new IntRect(64, 726, 69, 88));
                    // CROUCH LIGHT
                    _animationRect.Add("crouchLight1", new IntRect(72, 537, 57, 59));
                    _animationRect.Add("crouchLight2", new IntRect(136, 537, 77, 59));
                    // FACE HIT
                    _animationRect.Add("faceHit1", new IntRect(219, 1109, 50, 108));
                    _animationRect.Add("faceHit2", new IntRect(280, 1109, 57, 108));
                    _animationRect.Add("faceHit3", new IntRect(346, 1109, 58, 108));
                    // CROUCH HIT
                    _animationRect.Add("crouchHit", new IntRect(666, 619, 55, 64));
                    // KO
                    _animationRect.Add("ko1", new IntRect(182, 1257, 64, 101));
                    _animationRect.Add("ko2", new IntRect(254, 1257, 71, 101));
                    _animationRect.Add("ko3", new IntRect(460, 1313, 88, 44));

                    character = CreateCharacter("Sagat", "sagat.png", _animationRect, new Vector2f(5, 5));
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
                    Stage stage = CreateStage("stage1", "stage1.jpg", 1060);
                    return stage;
                default:
                    return null;
            }
        }

    }
}