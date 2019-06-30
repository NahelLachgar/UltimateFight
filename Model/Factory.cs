using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public static class Factory
    {
        static public Character CreateCharacter(string name, string img, Dictionary<string, IntRect> animationSprite, Vector2f scale, Projectile projectile = null)
        {
            Texture texture = new Texture("../../../../img/characters/" + img);
            texture.Smooth = true;
            Sprite sprite = new Sprite(texture);
            sprite.Scale = scale;
            Character character = new Character(name, sprite, animationSprite, projectile);
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

                    Projectile projectile = new Projectile("balrog.png", _animationRect["projectile1"], new Vector2f(0.3f, 0f), new Vector2f(5, 5));

                    Character character = CreateCharacter("Balrog", "balrog.png", _animationRect, new Vector2f(5.5f, 5.5f), projectile);
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
                    _animationRect.Add("projectile1", new IntRect(492, 866, 20, 16));
                    _animationRect.Add("projectile2", new IntRect(526, 861, 15, 26));
                    _animationRect.Add("projectile3", new IntRect(554, 860, 22, 28));

                    projectile = new Projectile("sagat.png", _animationRect["projectile1"], new Vector2f(0.3f, 0f), new Vector2f(5, 5));

                    character = CreateCharacter("Sagat", "sagat.png", _animationRect, new Vector2f(5f, 5f), projectile);
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
                    _animationRect.Add("special1", new IntRect(5, 767, 62, 83));
                    _animationRect.Add("special2", new IntRect(73, 774, 62, 76));
                    // PROJECTILE
                    _animationRect.Add("projectile1", new IntRect(144, 781, 87, 59));
                    _animationRect.Add("projectile2", new IntRect(239, 783, 96, 41));
                    _animationRect.Add("projectile3", new IntRect(342, 789, 98, 32));
                    _animationRect.Add("projectile4", new IntRect(447, 792, 96, 41));
                    _animationRect.Add("projectile5", new IntRect(549, 792, 96, 31));


                    projectile = new Projectile("bison.png", _animationRect["projectile1"], new Vector2f(0.3f, 0f), new Vector2f(5, 5));

                    character = CreateCharacter("Bison", "bison.png", _animationRect, new Vector2f(5, 5), projectile);
                    return character;
                case "ryu":
                    // SHADOW
                    _animationRect.Add("shadow", new IntRect(997, 605, 41, 9));
                    // WAITING
                    _animationRect.Add("waiting1", new IntRect(6, 18, 43, 81));
                    _animationRect.Add("waiting2", new IntRect(55, 19, 43, 80));
                    _animationRect.Add("waiting3", new IntRect(105, 18, 43, 81));
                    _animationRect.Add("waiting4", new IntRect(154, 17, 43, 82));
                    // WALKING
                    _animationRect.Add("walking1", new IntRect(205, 24, 43, 75));
                    _animationRect.Add("walking2", new IntRect(252, 19, 43, 80));
                    _animationRect.Add("walking3", new IntRect(301, 18, 43, 81));
                    _animationRect.Add("walking4", new IntRect(351, 19, 43, 80));
                    // CROUCH
                    _animationRect.Add("crouch1", new IntRect(1113, 24, 43, 75));
                    _animationRect.Add("crouch2", new IntRect(1160, 44, 43, 55));
                    // JUMP
                    _animationRect.Add("jump1", new IntRect(503, 9, 33, 90));
                    _animationRect.Add("jump2", new IntRect(545, 17, 29, 78));
                    _animationRect.Add("jump3", new IntRect(582, 19, 31, 67));
                    // LIGHT PUNCH
                    _animationRect.Add("lightPunch1", new IntRect(3, 134, 43, 81));
                    _animationRect.Add("lightPunch2", new IntRect(52, 134, 57, 81));
                    // LIGHT KICK
                    _animationRect.Add("lightKick1", new IntRect(6, 18, 43, 81));
                    _animationRect.Add("lightKick2", new IntRect(6, 261, 49, 85));
                    _animationRect.Add("lightKick3", new IntRect(64, 259, 65, 87));
                    // JUMP LIGHT
                    _animationRect.Add("jumpLight", new IntRect(52, 552, 51, 55));
                    // CROUCH LIGHT
                    _animationRect.Add("crouchLight1", new IntRect(9, 419, 47, 55));
                    _animationRect.Add("crouchLight2", new IntRect(61, 419, 62, 55));
                    // FACE HIT
                    _animationRect.Add("faceHit1", new IntRect(163, 754, 43, 82));
                    _animationRect.Add("faceHit2", new IntRect(217, 757, 48, 79));
                    _animationRect.Add("faceHit3", new IntRect(271, 757, 52, 79));
                    // CROUCH HIT
                    _animationRect.Add("crouchHit", new IntRect(451, 774, 45, 62));
                    // KO
                    _animationRect.Add("ko1", new IntRect(1165, 781, 45, 62));
                    _animationRect.Add("ko2", new IntRect(1218, 789, 72, 50));
                    _animationRect.Add("ko3", new IntRect(1295, 806, 74, 30));
                    // SPECIAL
                    _animationRect.Add("special1", new IntRect(951, 523, 40, 91));
                    _animationRect.Add("special2", new IntRect(1284, 501, 42, 113));

                    // PROJECTILE
                    _animationRect.Add("projectile1", new IntRect(997, 494, 41, 120));
                    _animationRect.Add("projectile2", new IntRect(1044, 491, 65, 123));
                    _animationRect.Add("projectile3", new IntRect(1116, 495, 41, 119));
                    _animationRect.Add("projectile4", new IntRect(1163, 497, 67, 117));
                    _animationRect.Add("projectile5", new IntRect(1235, 497, 41, 117));


                    projectile = new Projectile("ryu.png", _animationRect["projectile1"], new Vector2f(0.3f, 0f), new Vector2f(5.5f, 5.5f));

                    character = CreateCharacter("Ryu", "ryu.png", _animationRect, new Vector2f(5.5f, 5.5f), projectile);
                    return character;
                case "subzero":
                    // SHADOW
                    _animationRect.Add("shadow", new IntRect(880, 332, 39, 7));
                    // WAITING
                    _animationRect.Add("waiting1", new IntRect(149, 21, 40, 100));
                    _animationRect.Add("waiting2", new IntRect(201, 21, 40, 100));
                    _animationRect.Add("waiting3", new IntRect(252, 21, 40, 100));
                    _animationRect.Add("waiting4", new IntRect(302, 21, 41, 100));
                    // WALKING
                    _animationRect.Add("walking1", new IntRect(179, 153, 41, 98));
                    _animationRect.Add("walking2", new IntRect(129, 153, 40, 98));
                    _animationRect.Add("walking3", new IntRect(78, 152, 40, 99));
                    _animationRect.Add("walking4", new IntRect(20, 152, 48, 99));
                    // CROUCH
                    _animationRect.Add("crouch1", new IntRect(1217, 56, 45, 65));
                    _animationRect.Add("crouch2", new IntRect(1272, 72, 44, 49));
                    // JUMP
                    _animationRect.Add("jump1", new IntRect(583, 144, 45, 107));
                    _animationRect.Add("jump2", new IntRect(640, 161, 41, 90));
                    _animationRect.Add("jump3", new IntRect(530, 178, 43, 73));
                    // LIGHT PUNCH
                    _animationRect.Add("lightPunch1", new IntRect(20, 377, 47, 100));
                    _animationRect.Add("lightPunch2", new IntRect(77, 377, 70, 100));
                    // LIGHT KICK
                    _animationRect.Add("lightKick1", new IntRect(20, 609, 46, 98));
                    _animationRect.Add("lightKick2", new IntRect(77, 615, 51, 92));
                    _animationRect.Add("lightKick3", new IntRect(139, 615, 77, 92));
                    // JUMP LIGHT
                    _animationRect.Add("jumpLight", new IntRect(1111, 767, 82, 74));
                    // CROUCH LIGHT
                    _animationRect.Add("crouchLight1", new IntRect(664, 652, 44, 55));
                    _animationRect.Add("crouchLight2", new IntRect(720, 659, 76, 48));
                    // FACE HIT
                    _animationRect.Add("faceHit1", new IntRect(20, 858, 46, 102));
                    _animationRect.Add("faceHit2", new IntRect(76, 861, 49, 99));
                    _animationRect.Add("faceHit3", new IntRect(135, 864, 54, 96));
                    // CROUCH HIT
                    _animationRect.Add("crouchHit", new IntRect(897, 900, 45, 60));
                    // KO
                    _animationRect.Add("ko1", new IntRect(97, 994, 73, 74));
                    _animationRect.Add("ko2", new IntRect(297, 1006, 67, 62));
                    _animationRect.Add("ko3", new IntRect(376, 1041, 89, 27));
                    // SPECIAL
                    _animationRect.Add("special1", new IntRect(5, 824, 47, 109));
                    _animationRect.Add("special2", new IntRect(60, 846, 66, 87));
                    _animationRect.Add("special3", new IntRect(138, 846, 96, 87));
                    // PROJECTILE
                    _animationRect.Add("projectile1", new IntRect(554, 860, 22, 28));

                    character = CreateCharacter("SubZero", "subzero.png", _animationRect, new Vector2f(5, 5));
                    return character;
                case "16":
                    // SHADOW
                    _animationRect.Add("shadow", new IntRect(0, 0, 1, 1));
                    // WAITING
                    _animationRect.Add("waiting1", new IntRect(336, 17, 62, 91));
                    _animationRect.Add("waiting2", new IntRect(399, 17, 62, 91));
                    _animationRect.Add("waiting3", new IntRect(462, 19, 62, 89));
                    _animationRect.Add("waiting4", new IntRect(525, 19, 62, 89));
                    // WALKING
                    _animationRect.Add("walking1", new IntRect(181, 126, 43, 95));
                    _animationRect.Add("walking2", new IntRect(225, 124, 53, 97));
                    _animationRect.Add("walking3", new IntRect(279, 127, 61, 94));
                    _animationRect.Add("walking4", new IntRect(341, 122, 58, 99));
                    // CROUCH
                    _animationRect.Add("crouch1", new IntRect(653, 22, 60, 86));
                    _animationRect.Add("crouch2", new IntRect(714, 33, 59, 75));
                    // JUMP
                    _animationRect.Add("jump1", new IntRect(73, 235, 64, 108));
                    _animationRect.Add("jump2", new IntRect(138, 240, 61, 103));
                    _animationRect.Add("jump3", new IntRect(200, 251, 65, 92));
                    // LIGHT PUNCH
                    _animationRect.Add("lightPunch1", new IntRect(1, 366, 68, 91));
                    _animationRect.Add("lightPunch2", new IntRect(69, 366, 86, 91));
                    // LIGHT KICK
                    _animationRect.Add("lightKick1", new IntRect(264, 623, 51, 95));
                    _animationRect.Add("lightKick2", new IntRect(116, 625, 41, 93));
                    _animationRect.Add("lightKick3", new IntRect(158, 613, 105, 105));
                    // JUMP LIGHT
                    _animationRect.Add("jumpLight", new IntRect(596, 741, 112, 81));
                    // CROUCH LIGHT
                    _animationRect.Add("crouchLight1", new IntRect(630, 643, 70, 75));
                    _animationRect.Add("crouchLight2", new IntRect(547, 642, 82, 76));
                    // FACE HIT
                    _animationRect.Add("faceHit1", new IntRect(887, 1191, 66, 91));
                    _animationRect.Add("faceHit2", new IntRect(761, 1192, 62, 90));
                    _animationRect.Add("faceHit3", new IntRect(824, 1195, 62, 87));
                    // CROUCH HIT
                    _animationRect.Add("crouchHit", new IntRect(1198, 1212, 64, 70));
                    // KO
                    _animationRect.Add("ko1", new IntRect(712, 1314, 75, 81));
                    _animationRect.Add("ko2", new IntRect(788, 1348, 84, 47));
                    _animationRect.Add("ko3", new IntRect(1165, 1357, 104, 38));
                    // SPECIAL
                    _animationRect.Add("special1", new IntRect(1, 1078, 62, 95));
                    _animationRect.Add("special2", new IntRect(64, 1084, 75, 89));
                    _animationRect.Add("special3", new IntRect(140, 1091, 84, 82));
                    _animationRect.Add("special4", new IntRect(225, 1093, 62, 80));
                    _animationRect.Add("special5", new IntRect(288, 1091, 65, 82));
                    _animationRect.Add("special6", new IntRect(354, 1090, 86, 83));
                    _animationRect.Add("special7", new IntRect(441, 1080, 73, 93));
                    _animationRect.Add("special8", new IntRect(515, 1076, 64, 97));
                    // PROJECTILE
                    _animationRect.Add("projectile1", new IntRect(615, 1141, 59, 25));

                    projectile = new Projectile("16.png", _animationRect["projectile1"], new Vector2f(0.3f, 0f), new Vector2f(4, 4));

                    character = CreateCharacter("Android", "16.png", _animationRect, new Vector2f(5, 5), projectile);
                    return character;
                case "goku":
                    // SHADOW
                    _animationRect.Add("shadow", new IntRect(0, 0, 1, 1));
                    // WAITING
                    _animationRect.Add("waiting1", new IntRect(14, 24, 89, 103));
                    _animationRect.Add("waiting2", new IntRect(111, 24, 88, 103));
                    _animationRect.Add("waiting3", new IntRect(208, 25, 88, 102));
                    _animationRect.Add("waiting4", new IntRect(304, 24, 89, 103));
                    // WALKING
                    _animationRect.Add("walking1", new IntRect(14, 289, 76, 112));
                    _animationRect.Add("walking2", new IntRect(104, 291, 86, 110));
                    _animationRect.Add("walking3", new IntRect(204, 291, 94, 110));
                    _animationRect.Add("walking4", new IntRect(313, 291, 86, 110));
                    // CROUCH
                    _animationRect.Add("crouch1", new IntRect(14, 956, 85, 94));
                    _animationRect.Add("crouch2", new IntRect(112, 963, 81, 87));
                    // JUMP
                    _animationRect.Add("jump1", new IntRect(104, 2275, 75, 126));
                    _animationRect.Add("jump2", new IntRect(190, 2273, 66, 128));
                    _animationRect.Add("jump3", new IntRect(14, 2304, 76, 97));
                    // LIGHT PUNCH
                    _animationRect.Add("lightPunch1", new IntRect(14, 475, 89, 101));
                    _animationRect.Add("lightPunch2", new IntRect(111, 476, 131, 101));
                    // LIGHT KICK
                    _animationRect.Add("lightKick1", new IntRect(14, 624, 91, 125));
                    _animationRect.Add("lightKick2", new IntRect(117, 624, 80, 125));
                    _animationRect.Add("lightKick3", new IntRect(211, 624, 143, 125));
                    // JUMP LIGHT
                    _animationRect.Add("jumpLight", new IntRect(104, 2721, 102, 134));
                    // CROUCH LIGHT
                    _animationRect.Add("crouchLight1", new IntRect(14, 1084, 90, 89));
                    _animationRect.Add("crouchLight2", new IntRect(114, 1082, 131, 91));
                    // FACE HIT
                    _animationRect.Add("faceHit1", new IntRect(212, 4433, 80, 121));
                    _animationRect.Add("faceHit2", new IntRect(104, 4445, 96, 109));
                    _animationRect.Add("faceHit3", new IntRect(14, 4435, 82, 119));
                    // CROUCH HIT
                    _animationRect.Add("crouchHit", new IntRect(426, 4613, 83, 104));
                    // KO
                    _animationRect.Add("ko1", new IntRect(14, 4752, 124, 110));
                    _animationRect.Add("ko2", new IntRect(149, 4782, 153, 80));
                    _animationRect.Add("ko3", new IntRect(597, 4824, 154, 38));
                    // SPECIAL
                    _animationRect.Add("special1", new IntRect(14, 3980, 82, 97));
                    _animationRect.Add("special2", new IntRect(107, 3983, 82, 94));
                    _animationRect.Add("special3", new IntRect(201, 3987, 82, 90));
                    _animationRect.Add("special4", new IntRect(292, 3961, 108, 116));
                    _animationRect.Add("special5", new IntRect(508, 3946, 116, 131));
                    _animationRect.Add("special6", new IntRect(1177, 3390, 116, 131));
                    _animationRect.Add("special7", new IntRect(1397, 3406, 108, 116));
                    _animationRect.Add("special8", new IntRect(1308, 3419, 78, 102));
                    _animationRect.Add("special9", new IntRect(582, 2668, 87, 107));
                    _animationRect.Add("special10", new IntRect(684, 2668, 87, 107));
                    _animationRect.Add("special11", new IntRect(785, 2670, 96, 105));
                    _animationRect.Add("special12", new IntRect(896, 2670, 96, 105));
                    _animationRect.Add("special13", new IntRect(1166, 2667, 132, 108));
                    _animationRect.Add("special14", new IntRect(1009, 2667, 145, 108));
                    _animationRect.Add("special15", new IntRect(825, 1920, 665, 160));
                    _animationRect.Add("special16", new IntRect(714, 3687, 111, 101));
                    // PROJECTILE
                    _animationRect.Add("projectile1", new IntRect(680, 2395, 540, 210));

                    projectile = new Projectile("goku.png", _animationRect["projectile1"], new Vector2f(0f, 0f), new Vector2f(4f, 4f));

                    character = CreateCharacter("Goku", "goku.png", _animationRect, new Vector2f(4, 4), projectile);
                    return character;
                case "chun-li":
                    // SHADOW
                    _animationRect.Add("shadow", new IntRect(518, 822, 41, 9));
                    // WAITING
                    _animationRect.Add("waiting1", new IntRect(4, 35, 46, 77));
                    _animationRect.Add("waiting2", new IntRect(57, 34, 46, 78));
                    _animationRect.Add("waiting3", new IntRect(109, 33, 46, 79));
                    _animationRect.Add("waiting4", new IntRect(162, 34, 46, 78));
                    // WALKING
                    _animationRect.Add("walking1", new IntRect(220, 36, 48, 76));
                    _animationRect.Add("walking2", new IntRect(337, 32, 50, 80));
                    _animationRect.Add("walking3", new IntRect(452, 34, 51, 78));
                    _animationRect.Add("walking4", new IntRect(565, 32, 50, 80));
                    // CROUCH
                    _animationRect.Add("crouch1", new IntRect(1310, 46, 46, 66));
                    _animationRect.Add("crouch2", new IntRect(1362, 52, 46, 60));
                    // JUMP
                    _animationRect.Add("jump1", new IntRect(738, 17, 29, 95));
                    _animationRect.Add("jump2", new IntRect(773, 18, 35, 58));
                    _animationRect.Add("jump3", new IntRect(773, 18, 35, 58));
                    // LIGHT PUNCH
                    _animationRect.Add("lightPunch1", new IntRect(200, 148, 66, 76));
                    _animationRect.Add("lightPunch2", new IntRect(270, 152, 86, 72));
                    // LIGHT KICK
                    _animationRect.Add("lightKick1", new IntRect(2, 261, 48, 80));
                    _animationRect.Add("lightKick2", new IntRect(55, 257, 54, 84));
                    _animationRect.Add("lightKick3", new IntRect(205, 256, 69, 85));
                    // JUMP LIGHT
                    _animationRect.Add("jumpLight", new IntRect(1103, 377, 51, 68));
                    // CROUCH LIGHT
                    _animationRect.Add("crouchLight1", new IntRect(5, 385, 56, 60));
                    _animationRect.Add("crouchLight2", new IntRect(66, 385, 83, 60));
                    // FACE HIT
                    _animationRect.Add("faceHit1", new IntRect(137, 852, 46, 83));
                    _animationRect.Add("faceHit2", new IntRect(187, 860, 59, 75));
                    _animationRect.Add("faceHit3", new IntRect(187, 860, 59, 75));

                //    _animationRect.Add("faceHit3", new IntRect(137, 852, 46, 83));
                    // CROUCH HIT
                    _animationRect.Add("crouchHit", new IntRect(254, 880, 53, 55));
                    // KO
                    _animationRect.Add("ko1", new IntRect(948, 869, 71, 63));
                    _animationRect.Add("ko2", new IntRect(886, 869, 58, 63));
                    _animationRect.Add("ko3", new IntRect(1024, 906, 80, 33));
                    // SPECIAL
                    _animationRect.Add("special1", new IntRect(1, 1078, 62, 95));
                    _animationRect.Add("special2", new IntRect(64, 1084, 75, 89));
                    _animationRect.Add("special3", new IntRect(140, 1091, 84, 82));
                    _animationRect.Add("special4", new IntRect(225, 1093, 62, 80));
                    _animationRect.Add("special5", new IntRect(288, 1091, 65, 82));
                    _animationRect.Add("special6", new IntRect(354, 1090, 86, 83));
                    _animationRect.Add("special7", new IntRect(441, 1080, 73, 93));
                    _animationRect.Add("special8", new IntRect(515, 1076, 64, 97));
                    // PROJECTILE
                    _animationRect.Add("projectile1", new IntRect(615, 1141, 59, 25));

                    projectile = new Projectile("chun-li.png", _animationRect["projectile1"], new Vector2f(0.3f, 0f), new Vector2f(4, 4));

                    character = CreateCharacter("Chun-Li", "chun-li.png", _animationRect, new Vector2f(5.5f, 5.5f), projectile);
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
                case "stage2":
                    stage = CreateStage("stage2", "stage2.jpg", 950);
                    return stage;
                case "stage3":
                    stage = CreateStage("stage3", "stage3.png", 970);
                    return stage;
                case "stage4":
                    stage = CreateStage("stage4", "stage4.png", 1030);
                    return stage;
                case "stage5":
                    stage = CreateStage("stage5", "stage5.png", 970);
                    return stage;
                case "stage6":
                    stage = CreateStage("stage6", "stage6.jpg", 970);
                    return stage;
                default:
                    return null;
            }
        }

    }
}