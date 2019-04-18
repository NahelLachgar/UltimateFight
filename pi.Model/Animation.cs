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
        int _p;

        public Animation (Sprite sprite)
        {
            _sprite = sprite;
        }

        public void Waiting()
        {
            switch (_spriteNb)
            {
                case 0: this._sprite.TextureRect = new IntRect(4, 17, 45, 93);
                    break;
                case 80: this._sprite.TextureRect = new IntRect(57, 17, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    break;
                case 160: this._sprite.TextureRect = new IntRect(112, 17, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    break;
                case 240: this._sprite.TextureRect = new IntRect(168, 17, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                          _spriteNb = -1;
                    break;
            }
            _spriteNb += 1;
        }

        public bool LightPunch()
        {
            
            switch (_p)
            {
                case 0:
                    _spriteNb = 0;
                    this._sprite.TextureRect = new IntRect(5, 137, 55, 93);
                    break;
                case 180:
                    this._sprite.TextureRect = new IntRect(64, this._sprite.TextureRect.Top, 74, this._sprite.TextureRect.Height);
                    break;
                case 350:
                    this._sprite.TextureRect = new IntRect(146, this._sprite.TextureRect.Top, 54, this._sprite.TextureRect.Height);
                    break;
                case 450:
                    _p = 0;
                    return false;
                    break;
            }
            _p++;
            return true;
        }
    }
}
