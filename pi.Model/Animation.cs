using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFight
{
    public class Animation
    {
        Sprite _sprite;
        int _spriteNb;
        int _p;
        int _i;

        public Animation (Sprite sprite)
        {
            _sprite = sprite;
        }

        public void Waiting()
        {
            switch (_spriteNb)
            {
                case 0: this._sprite.TextureRect = new IntRect(4, 17, 45, 93);
                    _i = 0;
                    break;
                case 90: this._sprite.TextureRect = new IntRect(57, 17, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    break;
                case 180: this._sprite.TextureRect = new IntRect(112, 17, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    break;
                case 270: this._sprite.TextureRect = new IntRect(168, 17, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    _spriteNb = -1;
                    break;
            }
            _spriteNb++;
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

        public void WalkingForward()
        {
            switch (_i)
            {
                case 0:
                    this._sprite.TextureRect = new IntRect(227, 17, 45, 93);
                    _spriteNb = 0;
                    break;
                case 90:
                    this._sprite.TextureRect = new IntRect(281, this._sprite.TextureRect.Top, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    break;
                case 180:
                    this._sprite.TextureRect = new IntRect(337, this._sprite.TextureRect.Top, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    break;
                case 270:
                    this._sprite.TextureRect = new IntRect(394, this._sprite.TextureRect.Top, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    _i = -1;
                    break;
            }
            _i++;
        }
    }
}
