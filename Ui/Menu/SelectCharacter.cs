using System;
using System.Collections.Generic;
using System.Text;
using Model;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Model
{
    public class SelectCharacter
    {
        public string _characterPlayer1 = string.Empty;
        public string _characterPlayer2 = string.Empty;
        AvatarCharacter _img = new AvatarCharacter();
        List<CircleShape> _avatars = new List<CircleShape>();
        public List<string> _nameAvatars = new List<string>();

        private ConvexShape _imgPlayer1 = new ConvexShape();
        private ConvexShape _imgPlayer2 = new ConvexShape();

        internal SelectCharacter()
        {
            _avatars = CreateAvatars();
            _nameAvatars = CreateNameAvatars();
        }


        internal void Update(RenderWindow window)
        {
            ImgChararctersConstruction();
            Vector2i mousePosition = Mouse.GetPosition(window);

            for ( byte i = 0; i <= _avatars.Count-2 ; i++ )
            {
                if ( _avatars[i].GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y) )
                {
                    if ( Mouse.IsButtonPressed(Mouse.Button.Left) )
                    {

                        if ( _characterPlayer1 == string.Empty )
                        { _characterPlayer1 = _nameAvatars[i]; window.WaitAndDispatchEvents(); window.WaitAndDispatchEvents(); }

                        else if ( _characterPlayer1 != string.Empty ) _characterPlayer2 = _nameAvatars[i];
                        
                    }
                }
            }

        }

        private void ImgChararctersConstruction()
        {
            if ( _characterPlayer1 != string.Empty )
            {
                _imgPlayer1.SetPointCount(9);
                _imgPlayer1.SetPoint(0, new Vector2f(125f, 15f));
                _imgPlayer1.SetPoint(1, new Vector2f(575f, 15f));
                _imgPlayer1.SetPoint(2, new Vector2f(370f, 760f));
                _imgPlayer1.SetPoint(3, new Vector2f(345f, 760f));
                _imgPlayer1.SetPoint(4, new Vector2f(325f, 800f));
                _imgPlayer1.SetPoint(5, new Vector2f(329f, 760f));
                _imgPlayer1.SetPoint(6, new Vector2f(267f, 760f));
                _imgPlayer1.SetPoint(7, new Vector2f(298f, 898f));
                _imgPlayer1.SetPoint(8, new Vector2f(-155f, 898f));

                _imgPlayer1.Position = new Vector2f(900f, 0f);
                _imgPlayer1.Texture = _img.Character[_characterPlayer1];
                _imgPlayer1.TextureRect = new IntRect(0, 0, Convert.ToInt32(_img.Character[_characterPlayer1].Size.X), Convert.ToInt32(_img.Character[_characterPlayer1].Size.Y));
            }

            if ( _characterPlayer2 != string.Empty )
            {
                _imgPlayer2.SetPointCount(7);
                _imgPlayer2.SetPoint(0, new Vector2f(130f, 15f));
                _imgPlayer2.SetPoint(1, new Vector2f(490f, 15f));
                _imgPlayer2.SetPoint(2, new Vector2f(490f, 330f));
                _imgPlayer2.SetPoint(3, new Vector2f(345f, 898f));
                _imgPlayer2.SetPoint(4, new Vector2f(-50f, 898f));
                _imgPlayer2.SetPoint(5, new Vector2f(-50f, 758f));
                _imgPlayer2.SetPoint(6, new Vector2f(-95f, 758f));

                _imgPlayer2.Position = new Vector2f(1428f, 0f);
                _imgPlayer2.Texture = _img.Character[_characterPlayer2];
                _imgPlayer2.TextureRect = new IntRect(0, 0, Convert.ToInt32(_img.Character[_characterPlayer2].Size.X), Convert.ToInt32(_img.Character[_characterPlayer2].Size.Y));
            }
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

            shape = ( ShapeHelpers.RedCircleShape(68f, 6, new Vector2f(465f, 179f), Color.Transparent, Color.White) );
            shape.Texture = _img.Avatar["Bison"];
            shape.TextureRect = new IntRect(0, 0, Convert.ToInt32(_img.Avatar["Bison"].Size.X), Convert.ToInt32(_img.Avatar["Bison"].Size.Y));
            circleShape.Add(shape);

            shape = ( ShapeHelpers.RedCircleShape(68f, 6, new Vector2f(608f, 179f), Color.Transparent, Color.White) );
            shape.Texture = _img.Avatar["Sagat"];
            shape.TextureRect = new IntRect(0, 0, Convert.ToInt32(_img.Avatar["Sagat"].Size.X), Convert.ToInt32(_img.Avatar["Sagat"].Size.Y));
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

        internal ConvexShape ImgPlayer1 => _imgPlayer1;

        internal ConvexShape ImgPlayer2 => _imgPlayer2;

        internal List<CircleShape> Avatars => _avatars;


        private List<string> CreateNameAvatars()
        {
            List<string> NameAvatar = new List<string>();

            NameAvatar.Add("Balrog");
            NameAvatar.Add("Chunli");
            NameAvatar.Add("Ryu");
            NameAvatar.Add("Bison");
            NameAvatar.Add("Sagat");

            return NameAvatar;
        }




    }
}
