using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFight
{
    public class Stage
    {
        string _name;
        public Sprite _sprite;
        public int _groundHeight;

        public Stage(string name, /*Sprite sprite,*/ int groundHeight, RenderWindow window, Texture texture)
        {
            _name = name;
            _groundHeight = groundHeight;
            _sprite = new Sprite(texture);

            _sprite.Scale = new Vector2f(( Convert.ToSingle(window.Size.X) / Convert.ToSingle(texture.Size.X) ), Convert.ToSingle( ( window.Size.Y) / Convert.ToSingle(texture.Size.Y) ));
        //    _sprite.Scale = new Vector2f(3f, 3f);
        }
    }
}
