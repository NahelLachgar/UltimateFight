using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace pi
{
    public class Animation
    {
        Sprite _sprite;
        int _spriteNb;

        public Animation (Sprite sprite)
        {
            _sprite = sprite;
        }

        public void Waiting()
        {
            switch (_spriteNb)
            {
                case 0: this._sprite.TextureRect = new IntRect(4, 18, 45, 92);
                    break;
                case 80: this._sprite.TextureRect = new IntRect(57, 18, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    break;
                case 160: this._sprite.TextureRect = new IntRect(112, 18, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    break;
                case 240: this._sprite.TextureRect = new IntRect(168, 18, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                          _spriteNb = 0;
                    break;
            }
            _spriteNb += 1;
        }
    }
}
