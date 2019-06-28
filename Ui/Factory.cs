using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;
using Model;


namespace UI
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
                    // SHADOW
                    _animationRect.Add("shadow", new IntRect(501, 101, 41, 9));
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
                    // SPECIAL
                    _animationRect.Add("special1", new IntRect(8, 612, 53, 94));
                    _animationRect.Add("special2", new IntRect(70, 612, 60, 94));
                    _animationRect.Add("special3", new IntRect(139, 612, 118, 94));
                    _animationRect.Add("special4", new IntRect(262, 612, 61, 94));
                    _animationRect.Add("special5", new IntRect(327, 612, 48, 94));
                    // PROJECTILE
                    _animationRect.Add("projectile1", new IntRect(5, 824, 47, 109));


                    Character character = CreateCharacter("Balrog", "balrog.png", _animationRect, new Vector2f(5, 5));
                    return character;
                case "sagat":
                    // SHADOW
                    _animationRect.Add("shadow", new IntRect(617, 676, 47, 9));
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
                    // SPECIAL
                    _animationRect.Add("special1", new IntRect(5, 824, 47, 109));
                    _animationRect.Add("special2", new IntRect(60, 846, 66, 87));
                    _animationRect.Add("special3", new IntRect(138, 846, 96, 87));
                    // PROJECTILE
                    _animationRect.Add("projectile1", new IntRect(554, 860, 22, 28));


                    character = CreateCharacter("Sagat", "sagat.png", _animationRect, new Vector2f(5, 5));
                    return character;
                case "bison":
                    // SHADOW
                    _animationRect.Add("shadow", new IntRect(567, 99, 54, 10));
                    // WAITING
                    _animationRect.Add("waiting1", new IntRect(3, 26, 65, 83));
                    _animationRect.Add("waiting2", new IntRect(73, 22, 64, 86));
                    _animationRect.Add("waiting3", new IntRect(143, 21, 64, 88));
                    _animationRect.Add("waiting4", new IntRect(73, 22, 64, 86));
                    // WALKING
                    _animationRect.Add("walking1", new IntRect(216, 22, 62, 87));
                    _animationRect.Add("walking2", new IntRect(285, 16, 62, 93));
                    _animationRect.Add("walking3", new IntRect(354, 18, 62, 91));
                    _animationRect.Add("walking4", new IntRect(425, 26, 65, 83));
                    // CROUCH
                    _animationRect.Add("crouch1", new IntRect(791, 33, 62, 76));
                    _animationRect.Add("crouch2", new IntRect(934, 52, 65, 57));
                    // JUMP
                    _animationRect.Add("jump1", new IntRect(626, 24, 40, 85));
                    _animationRect.Add("jump2", new IntRect(672, 24, 63, 85));
                    _animationRect.Add("jump3", new IntRect(672, 24, 63, 85));
                    // LIGHT PUNCH
                    _animationRect.Add("lightPunch1", new IntRect(77, 138, 64, 81));
                    _animationRect.Add("lightPunch2", new IntRect(229, 138, 71, 81));
                    // LIGHT KICK
                    _animationRect.Add("lightKick1", new IntRect(4, 244, 62, 90));
                    _animationRect.Add("lightKick2", new IntRect(76, 243, 65, 91));
                    _animationRect.Add("lightKick3", new IntRect(440, 244, 80, 90));
                    // JUMP LIGHT
                    _animationRect.Add("jumpLight", new IntRect(77, 468, 59, 75));
                    // CROUCH LIGHT
                    _animationRect.Add("crouchLight1", new IntRect(4, 667, 64, 64));
                    _animationRect.Add("crouchLight2", new IntRect(74, 670, 80, 60));
                    // FACE HIT
                    _animationRect.Add("faceHit1", new IntRect(252, 975, 63, 96));
                    _animationRect.Add("faceHit2", new IntRect(318, 976, 73, 95));
                    _animationRect.Add("faceHit3", new IntRect(397, 983, 88, 88));
                    // CROUCH HIT
                    _animationRect.Add("crouchHit", new IntRect(886, 999, 58, 72));
                    // KO
                    _animationRect.Add("ko1", new IntRect(152, 1131, 69, 50));
                    _animationRect.Add("ko2", new IntRect(227, 1127, 67, 55));
                    _animationRect.Add("ko3", new IntRect(379, 1152, 88, 30));
                    // SPECIAL
                    _animationRect.Add("special1", new IntRect(5, 824, 47, 109));
                    _animationRect.Add("special2", new IntRect(60, 846, 66, 87));
                    _animationRect.Add("special3", new IntRect(138, 846, 96, 87));
                    // PROJECTILE
                    _animationRect.Add("projectile1", new IntRect(554, 860, 22, 28));


                    character = CreateCharacter("Bison", "bison.png", _animationRect, new Vector2f(5, 5));
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