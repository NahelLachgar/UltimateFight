using System;
using System.Collections.Generic;
using System.Text;
using Model;
using SFML.Graphics;
using SFML.System;

namespace Model
{
    internal class SelectCharacter
    {
        string CharacterPlayer1 = "Balrog";
        string CharacterPlayer2 = "Ryu";
        AvatarCharacter _img = new AvatarCharacter();
        List<CircleShape> _avatars = new List<CircleShape>();
        public RectangleShape test = new RectangleShape();
        public ConvexShape ttt = new ConvexShape();
        public ConvexShape aaa = new ConvexShape();

        internal SelectCharacter()
        {
            _avatars = CreateAvatars();



            ttt.SetPointCount(9);
            ttt.SetPoint(0, new Vector2f(125f, 15f));
            ttt.SetPoint(1, new Vector2f(575f, 15f));
            ttt.SetPoint(2, new Vector2f(370f, 760f));

            ttt.SetPoint(3, new Vector2f(345f, 760f));
            ttt.SetPoint(4, new Vector2f(325f, 800f));
            ttt.SetPoint(5, new Vector2f(329f, 760f));

            ttt.SetPoint(6, new Vector2f(267f, 760f));
            ttt.SetPoint(7, new Vector2f(298f, 898f));
            ttt.SetPoint(8, new Vector2f(-155f, 898f));

            //ttt.FillColor = Color.Cyan;
            ttt.Position = new Vector2f(900f, 0f);
            ttt.Texture = _img.Character[CharacterPlayer1];
            ttt.TextureRect = new IntRect(0, 0, Convert.ToInt32(_img.Character[CharacterPlayer1].Size.X), Convert.ToInt32(_img.Character[CharacterPlayer1].Size.Y));



            aaa.SetPointCount(7);
            aaa.SetPoint(0, new Vector2f(130f, 15f));
            aaa.SetPoint(1, new Vector2f(490f, 15f));
            aaa.SetPoint(2, new Vector2f(490f, 330f));

            aaa.SetPoint(3, new Vector2f(345f, 898f));
            aaa.SetPoint(4, new Vector2f(-50f, 898f));
            aaa.SetPoint(5, new Vector2f(-50f, 758f));
            aaa.SetPoint(6, new Vector2f(-95f, 758f));

            //aaa.FillColor = Color.Cyan;
            aaa.Position = new Vector2f(1428f, 0f);
            aaa.Texture = _img.Character[CharacterPlayer2];
            aaa.TextureRect = new IntRect(0, 0, Convert.ToInt32(_img.Character[CharacterPlayer2].Size.X), Convert.ToInt32(_img.Character[CharacterPlayer2].Size.Y));
        }

        private List<CircleShape> CreateAvatars()
        {
            List<CircleShape> circleShape = new List<CircleShape>();

            // Ligne pair
            CircleShape shape = ShapeHelpers.RedCircleShape(68f, 6, new Vector2f(28f, 179f), Color.Transparent, Color.White);
            shape.Texture = _img.Avatar["Balrog"];
            shape.TextureRect = new IntRect(0, 0, Convert.ToInt32(_img.Avatar["Balrog"].Size.X), Convert.ToInt32(_img.Avatar["Balrog"].Size.Y));
            circleShape.Add(shape);


            shape = (ShapeHelpers.RedCircleShape(68f, 6, new Vector2f(174f, 179f), Color.Transparent, Color.White));
            shape.Texture = _img.Avatar["Chunli"];
            shape.TextureRect = new IntRect(0, 0, Convert.ToInt32(_img.Avatar["Chunli"].Size.X), Convert.ToInt32(_img.Avatar["Chunli"].Size.Y));
            circleShape.Add(shape);

            shape =(ShapeHelpers.RedCircleShape(68f, 6, new Vector2f(322f, 179f), Color.Transparent, Color.White));
            shape.Texture = _img.Avatar["Ryu"];
            shape.TextureRect = new IntRect(0, 0, Convert.ToInt32(_img.Avatar["Ryu"].Size.X), Convert.ToInt32(_img.Avatar["Ryu"].Size.Y));
            circleShape.Add(shape);

            // Ligne impair
            circleShape.Add(ShapeHelpers.RedCircleShape(68f, 6, new Vector2f(102f, 304f), Color.Transparent));

            return circleShape;
        }

        internal List<CircleShape> SelectCharacterByPlayer(int Player)
        {
            List<CircleShape> shape = new List<CircleShape>();



            return shape;
        }


        internal List<CircleShape> Avatars => _avatars;






    }
}
