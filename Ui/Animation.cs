using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace UI

{
    public class Animation
    {
        public Sound _music = new Sound();
        Sprite _sprite;
        RectangleShape _hitbox;
        //IntRect _test;
        Dictionary<string, IntRect> _animationRect;
        int _spriteNb;
        int _p = -1;
        int _m = -1;
        int _i = -1;
        int _v = -1;
        int _c;
        int _j = -1;

        public Animation(Sprite sprite, RectangleShape hitbox, Dictionary<string, IntRect> animationRect)
        {
            _sprite = sprite;
            _hitbox = hitbox;
            _animationRect = animationRect;
        }

        public void Waiting()
        {
            switch (_spriteNb)
            {
                case 0:
                    // IF THE PLAYER WAS CROUCHING
                    if (_c != 0)
                    {
                        this._sprite.TextureRect = _animationRect["crouch1"];
                    }
                    else
                    {
                        this._sprite.TextureRect = _animationRect["waiting1"];
                    }
                    _i = 0;
                    _c = 0;
                    break;
                case 90: this._sprite.TextureRect = _animationRect["waiting2"];
                    break;
                case 180: this._sprite.TextureRect = _animationRect["waiting3"];
                    break;
                case 270: this._sprite.TextureRect = _animationRect["waiting4"];
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
                        this._sprite.TextureRect = _animationRect["crouch1"];
                    }
                    else
                    {
                        this._sprite.TextureRect = _animationRect["walking1"];
                    }
                    _spriteNb = 0;
                    _c = 0;
                    break;
                case 90:
                    this._sprite.TextureRect = _animationRect["walking2"];
                    break;
                case 180:
                    this._sprite.TextureRect = _animationRect["walking3"];
                    break;
                case 270:
                    this._sprite.TextureRect = _animationRect["walking4"];
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
                        this._sprite.TextureRect = _animationRect["crouch1"];
                    }
                    else
                    {
                        this._sprite.TextureRect = _animationRect["walking1"];

                    }
                    _spriteNb = 0;
                    _c = 0;
                    break;
                case 90:
                    this._sprite.TextureRect = _animationRect["walking4"];
                    break;
                case 180:
                    this._sprite.TextureRect = _animationRect["walking3"];
                    break;
                case 270:
                    this._sprite.TextureRect = _animationRect["walking2"];
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
                    this._sprite.TextureRect = _animationRect["crouch1"];
                    _spriteNb = 0;
                    _i = 0;
                    break;
                case 45:
                    this._sprite.TextureRect = _animationRect["crouch2"];
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
                    this._sprite.TextureRect = _animationRect["jump1"];
                    _i = -1;
                    _spriteNb = -1;
                    _c = -1;
                    break;
                case 125:
                    this._sprite.TextureRect = _animationRect["jump2"];
                    break;
                case 250:
                    this._sprite.TextureRect = _animationRect["jump3"];
                    break;
                case 375:
                    this._sprite.TextureRect = _animationRect["jump2"];
                    break;
                case 500:
                    this._sprite.TextureRect = _animationRect["jump1"];
                    break;
                case 600:
                    this._sprite.TextureRect = _animationRect["waiting1"];
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
                    _music._currentSound = _music._punch0;
                    _music._currentSound.Stop();
                    _music._currentSound.Play();

                    _spriteNb = 0;
                    this._sprite.TextureRect = _animationRect["lightPunch1"];
                    break;
                case 150:
                    this._sprite.TextureRect = _animationRect["lightPunch2"];
                    _hitbox.Position = new Vector2f(this._sprite.Position.X, this._sprite.Position.Y);
                    this._hitbox.Size = new Vector2f(this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    break;
                case 300:
                    this._sprite.TextureRect = _animationRect["lightPunch1"];
                    this._hitbox.Size = new Vector2f(0f, 0f);
                    break;
                // NEEDED TO GET THE ANIMATION SMOOTHER
                case 400:
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
                    _music._currentSound = _music._punch1;
                    _music._currentSound.Stop();
                    _music._currentSound.Play();
                    _spriteNb = 0;
                    this._sprite.TextureRect = _animationRect["lightKick1"];
                    break;
                case 120:
                    this._sprite.TextureRect = _animationRect["lightKick2"];
                    break;
                case 240:
                    this._sprite.TextureRect = _animationRect["lightKick3"];
                    _hitbox.Position = new Vector2f(this._sprite.Position.X, this._sprite.Position.Y);
                    this._hitbox.Size = new Vector2f(this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    break;
                case 360:
                    this._sprite.TextureRect = _animationRect["lightKick2"];
                    this._hitbox.Size = new Vector2f(0f, 0f);
                    break;
                case 480:
                    this._sprite.TextureRect = _animationRect["lightKick1"];
                    break;
                case 600:
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
                    this._sprite.TextureRect = _animationRect["jumpLight"];
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
                    this._sprite.TextureRect = _animationRect["crouchLight1"];
                    break;
                case 120:
                    this._sprite.TextureRect = _animationRect["crouchLight2"];
                    _hitbox.Position = new Vector2f(this._sprite.Position.X, this._sprite.Position.Y);
                    this._hitbox.Size = new Vector2f(this._sprite.TextureRect.Width, this._sprite.TextureRect.Height);
                    break;
                case 240:
                    this._sprite.TextureRect = _animationRect["crouchLight1"];
                    this._hitbox.Size = new Vector2f(0f, 0f);
                    break;
                case 360:
                    this._sprite.TextureRect = _animationRect["crouch2"];
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
                    _music._currentSound = _music._punch2;
                    _music._currentSound.Stop();
                    _music._currentSound.Play();
                    this._sprite.TextureRect = _animationRect["faceHit1"];
                    _spriteNb = -1;
                    _i = -1;
                    _c = 0;
                    break;
                case 100:
                    this._sprite.TextureRect = _animationRect["faceHit2"];
                    break;
                case 200 :
                    this._sprite.TextureRect = _animationRect["faceHit3"];
                    break;
                case 300:
                    this._sprite.TextureRect = _animationRect["faceHit2"];
                    break;
                case 400:
                    _p = -1;
                    return false;    
            }
            return true;
        }

        public bool CrouchHit()
        {
            _p++;

            switch (_p)
            {
                case 0:
                    this._sprite.TextureRect = _animationRect["crouch2"];
                    _spriteNb = -1;
                    _i = -1;
                    break;
                case 200:
                    this._sprite.TextureRect = _animationRect["crouchHit"];
                    break;
                case 400:
                    this._sprite.TextureRect = _animationRect["crouch2"];
                    _p = -1;
                    return false;
            }
            return true;
        }

        public void KO()
        {
            _p++;

            if (_sprite.Scale.X < 0)
            {
                switch (_p)
                {
                    case 0:
                        this._sprite.TextureRect = _animationRect["ko1"];
                        this._sprite.Position += new Vector2f(80f, 0f);
                        break;
                    case 150:
                        this._sprite.TextureRect = _animationRect["ko2"];
                        this._sprite.Position += new Vector2f(80f, 0f);
                        break;
                    case 300:
                        this._sprite.TextureRect = _animationRect["ko3"];
                        this._sprite.Position += new Vector2f(80f, 0f);
                        break;
                    case 450:
                        this._sprite.TextureRect = _animationRect["ko2"];
                        this._sprite.Position += new Vector2f(80f, 0f);
                        break;
                    case 600:
                        this._sprite.TextureRect = _animationRect["ko3"];
                        this._sprite.Position += new Vector2f(80f, 0f);
                        break;
                }
            }
            else
            {
                switch (_p)
                {
                    case 0:
                        this._sprite.TextureRect = _animationRect["ko1"];
                        this._sprite.Position -= new Vector2f(80f, 0f);
                        break;
                    case 150:
                        this._sprite.TextureRect = _animationRect["ko2"];
                        this._sprite.Position -= new Vector2f(80f, 0f);
                        break;
                    case 300:
                        this._sprite.TextureRect = _animationRect["ko3"];
                        this._sprite.Position -= new Vector2f(80f, 0f);
                        break;
                    case 450:
                        this._sprite.TextureRect = _animationRect["ko2"];
                        this._sprite.Position -= new Vector2f(80f, 0f);
                        break;
                    case 600:
                        this._sprite.TextureRect = _animationRect["ko3"];
                        this._sprite.Position -= new Vector2f(80f, 0f);
                        break;
                }
            }
        }

        // VICTORY POSE
        public void VictoryPose()
        {
           // if (_i == -1 && _j == -1 && _m == -1 && _c == 0)
            //{
                _v++;
                switch (_v)
                {
                    case 0:
                        this._sprite.TextureRect = new IntRect(363, 973, 43, 107);
                        _p = 0;
                        _c = 0;
                        _i = -1;
                        _j = -1;
                        _m = -1;
                        break;
                    case 225:
                        this._sprite.TextureRect = new IntRect(414, 973, 58, 107);
                        break;
                    case 450:
                        this._sprite.TextureRect = new IntRect(481, 973, 78, 107);
                        break;
                }
           // }
        }

    }// DONT TOUCH
}
