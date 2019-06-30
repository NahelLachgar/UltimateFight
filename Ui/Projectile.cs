using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Model
{
    public class Projectile
    {
        IntRect _intRect;
        bool _isThrown;
        Texture _texture;
        Vector2f _path;
        Sprite _sprite;
        float _width;

        public Projectile(string img, IntRect intRect, Vector2f path, Vector2f scale)
        {
            _isThrown = false;
            _path = path;
            _texture = new Texture("../../../../img/characters/" + img);
            _texture.Smooth = true;
            _sprite = new Sprite(_texture);
            _sprite.Scale = scale;
            _sprite.TextureRect = intRect;
            _width = _sprite.TextureRect.Width * _sprite.Scale.X;
        }

        public Sprite Sprite {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public bool isThrown
        {
            get { return _isThrown; }
            set { _isThrown = value; }
        }

        public Vector2f Position
        {
            get { return _sprite.Position; }
            set { _sprite.Position = value; }
        }

        public Color Color
        {
            set { _sprite.Color = value; }
        }

        public Vector2f Path => _path;

        public float Width => _width;
    }
}
