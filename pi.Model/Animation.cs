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
        int _p = -1;
        int _m = -1;
        int _i = -1;
        int _c;
        int _j = -1;

        public Animation(Sprite sprite)
        {
            _sprite = sprite;
        }

        public void Waiting()
        {
            switch (_spriteNb)
            {
                case 0:
                    // IF THE PLAYER WAS CROUCHING
                    if (_c != 0)
                    {
                        this._sprite.TextureRect = new IntRect(786, 17, 45, 93);
                    }
                    else
                    {
                        this._sprite.TextureRect = new IntRect(4, 17, 45, 93);
                    }
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
            _j++;
            switch (_j)
            {

                case 0:
                    this._sprite.TextureRect = new IntRect(594, 17, 38, this._sprite.TextureRect.Height);
                    _i = -1;
                    _spriteNb = -1;
                    _c = -1;
                    break;
                case 100:
                    this._sprite.TextureRect = new IntRect(641, 17, 39, this._sprite.TextureRect.Height);
                    break;
                case 200:
                    this._sprite.TextureRect = new IntRect(687, 17, 38, this._sprite.TextureRect.Height);
                    break;
                case 400:
                    this._sprite.TextureRect = new IntRect(733, 17, 43, this._sprite.TextureRect.Height);
                    break;
                case 500:
                    this._sprite.TextureRect = new IntRect(733, 17, 43, this._sprite.TextureRect.Height);
                    break;
                case 600:
                    _j = -1;
                    break;

            }

        }
        
        internal bool LightPunch()
        {
            _p++;

            switch (_p)
            {
                case 0:
                    _spriteNb = 0;
                    this._sprite.TextureRect = new IntRect(5, 137, 55, 93);
                    break;
                case 100:
                    this._sprite.TextureRect = new IntRect(64, this._sprite.TextureRect.Top, 74, this._sprite.TextureRect.Height);
                    break;
                case 200:
                    this._sprite.TextureRect = new IntRect(146, this._sprite.TextureRect.Top, 54, this._sprite.TextureRect.Height);
                    break;
                // NEEDED TO GET THE ANIMATION SMOOTHER
                case 300:
                    _p = -1;
                    return false;
            }
            return true;
        }
        
        internal bool LightKick()
        {
            _m++;

            switch (_m)
            {
                case 0:
                    _spriteNb = 0;
                    this._sprite.TextureRect = new IntRect(5, 248, 68, 94);
                    break;
                case 180:
                    this._sprite.TextureRect = new IntRect(81, this._sprite.TextureRect.Top, 74, this._sprite.TextureRect.Height);
                    break;
                case 350:
                    this._sprite.TextureRect = new IntRect(164, this._sprite.TextureRect.Top, 68, this._sprite.TextureRect.Height);
                    break;
                case 450:
                    _m = -1;
                    return false;
            }
            return true;
        }

        // LIGHT KICK OR LIGHT PUNCH WHILE JUMPING
        public void JumpLight()
        {
            _p++;

            switch (_p)
            {
                case 0:
                    this._sprite.TextureRect = new IntRect(22, 498, 55, 84);
                    _p = -1;
                    break;

            }
        }

        public bool CrouchLight()
        {
            _p++;

            switch (_p)
            {
                case 0:
                    this._sprite.TextureRect = new IntRect(5, 377, 47, 93);
                    break;
                case 120:
                    this._sprite.TextureRect = new IntRect(63, 377, 67, 93);
                    break;
                case 240:
                    this._sprite.TextureRect = new IntRect(5, 377, 47, 93);
                    break;
                case 360:
                    this._sprite.TextureRect = new IntRect(837, 17, 43, 93);
                    _p = -1;
                    return false;                    
            }
            return true;

        }

        // ===============================================
        // TAKING DAMAGE & K.O.
        // ===============================================

        public bool FaceHit()
        {
            _p++;

            switch (_p)
            {
                case 0:
                    this._sprite.TextureRect = new IntRect(196, 851, 44, 100);
                    _spriteNb = -1;
                    _i = -1;
                    _c = 0;
                    break;
                case 100:
                    this._sprite.TextureRect = new IntRect(252, 851, 46, 100);
                    break;
                case 200 :
                    this._sprite.TextureRect = new IntRect(301, 851, 49, 100);
                    break;
                case 300:
                    this._sprite.TextureRect = new IntRect(196, 851, 44, 100);
                    break;
                case 400:
                    _p = -1;
                    return false;    
            }
            return true;
        }

        public bool KO()
        {
            _p++;

            switch (_p)
            {
                case 0:
                    this._sprite.TextureRect = new IntRect(7, 986, 42, 93);
                    _spriteNb = -1;
                    _i = -1;
                    _c = 0;
                    break;
                case 100:
                    this._sprite.TextureRect = new IntRect(61, 986, 62, 93);
                    break;
                case 200:
                    this._sprite.TextureRect = new IntRect(132, 851, 70, 98);
                    break;
                case 300:
                    this._sprite.TextureRect = new IntRect(61, 986, 62, 93);
                    break;
                case 400:
                    this._sprite.TextureRect = new IntRect(132, 851, 70, 98);
                    break;
                case 500:
                    _p = -1;
                    return false;
            }
            return true;
        }



    }
}
