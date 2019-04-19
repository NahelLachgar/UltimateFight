using SFML.Graphics;
using SFML.System;
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
        int _c;
        int _j;

        public Animation(Sprite sprite)
        {
            _sprite = sprite;
        }

        public void Waiting()
        {
            switch (_spriteNb)
            {
                case 0: this._sprite.TextureRect = new IntRect(4, 17, 45, 93);
                    _i = 0;
                    _c = 0;
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
                    // IF THE PLAYER WAS CROUCHING
                    if (_c != 0)
                    {
                        this._sprite.TextureRect = new IntRect(786, 17, 45, 93);
                    }
                    else
                    {
                        this._sprite.TextureRect = new IntRect(227, 17, 45, 93);
                    }
                    _spriteNb = 0;
                    _c = 0;
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

        public void WalkingBackward()
        {
            switch (_i)
            {
                case 0:
                    // IF THE PLAYER WAS CROUCHING
                    if (_c != 0)
                    {
                        this._sprite.TextureRect = new IntRect(786, 17, 45, 93);
                    }
                    else
                    {
                        this._sprite.TextureRect = new IntRect(227, 17, 45, 93);
                        
                    }
                    _spriteNb = 0;
                    _c = 0;
                    break;
                case 90:
                    this._sprite.TextureRect = new IntRect(394, this._sprite.TextureRect.Top, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    break;
                case 180:
                    this._sprite.TextureRect = new IntRect(337, this._sprite.TextureRect.Top, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    break;
                case 270:
                    this._sprite.TextureRect = new IntRect(281, this._sprite.TextureRect.Top, this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    _i = -1;
                    break;
            }
            _i++;
        }

        public void Crouch()
        {
            switch (_c)
            {
                case 0:
                    this._sprite.TextureRect = new IntRect(786, 17, 45, 93);
                    _spriteNb = 0;
                    _i = 0;
                    break;
                case 45:
                    this._sprite.TextureRect = new IntRect(837, this._sprite.TextureRect.Top, 43, this._sprite.TextureRect.Height);
                    break;
            }
            if (_c != 45)
            {
                _c++;
            }
        }
        
        public void Jump( )
        {
            
            switch (_j)
            {
                case 0:
                    this._sprite.TextureRect = new IntRect(450, 17, 45, 93);
                    _i = 0;
                    _c = 0;
                    _spriteNb = 0;
                    break;
                case 20:
                    this._sprite.TextureRect = new IntRect(545, 17, 43, this._sprite.TextureRect.Height);
                    break;
                case 100:
                    this._sprite.TextureRect = new IntRect(594, 17, 38, this._sprite.TextureRect.Height);
                    break;
                case 200:
                    this._sprite.TextureRect = new IntRect(641, 17, 39, this._sprite.TextureRect.Height);
                    break;
                case 400:
                    this._sprite.TextureRect = new IntRect(687, 17, 38, this._sprite.TextureRect.Height);
                    break;
                case 500:
                    this._sprite.TextureRect = new IntRect(733, 17, 43, this._sprite.TextureRect.Height);
                    break;
                case 599:
                    this._sprite.TextureRect = new IntRect(450, 17, 45, 93);
                    _j = 0;
                    break;
            }
            _j++;

        }
    }
}
