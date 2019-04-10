using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using System.Text;

namespace pi
{
    public class Stage
    {
        string _name;
        public Sprite _sprite;
        int _groundHeight;

        public Stage(string name, /*Sprite sprite,*/ int groundHeight, float X, float Y, Texture texture)
        {
            _name = name;
            _groundHeight = groundHeight;
            _sprite = new Sprite(texture);

            _sprite.Scale = new Vector2f(( X / texture.Size.X ), ( Y / texture.Size.Y ));
        //    _sprite.Scale = new Vector2f(3f, 3f);
        }
    }
}
