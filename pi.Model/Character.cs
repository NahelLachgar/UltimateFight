using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace UltimateFight
{
    public class Character //:Sprite
    {
        readonly internal string _name;
        public Sprite _sprite;
        // internal Special _special;
        internal uint _health = 100;
        internal uint _energy = 0;
        internal Vector2f _position;
        Dictionary<string, IntRect> _rects;
        bool _canMove;
        bool _canJump;

        bool _isJumping;
        bool _isFighting;

        bool _lightPunch;
        bool _lightKick;
        bool _crouchPunch;

        internal bool _isCrouching;
        internal bool _isMoving;
        int i = -1;
        internal Animation _animation;
        public Sprite _shadow;

        public Character(string name, Sprite sprite)
        {
            _name = name;
            _isJumping = false; 
            _isFighting = false;
            _isMoving = false;

            _lightPunch = false;
            _lightKick = false;
            _crouchPunch = false;
            
            _canMove = true;
            _canJump = true;

            _sprite = sprite;
            _animation = new Animation(sprite);
            _shadow = new Sprite
            {
                Texture = sprite.Texture,
                TextureRect = new IntRect(501, 17, 41, 93),
                Scale = _sprite.Scale,
                Color = new Color(255, 255, 255, 0)
            };
        }

        public uint Energy => _energy;

        internal string Name => _name;

        internal bool IsAlive => Health != 0;

        public uint Health => _health;

        internal Vector2f Position
        {
            get { return _position; }
            set { _position = value; }
        }

        internal void Update()
        {
            // SHADOW FOLOWING THE CHARACTER
            _shadow.Position = new Vector2f(0f, 580f);
            if(_sprite.Scale.X < 0) _shadow.Position += new Vector2f(_sprite.Position.X - 180, 0f);
            if(_sprite.Scale.X > 0) _shadow.Position += new Vector2f(_sprite.Position.X, 0f);

            // FIGTHING ANIMATION
            if (_isFighting == true)
            {
                _canMove = false;
                _isMoving = false;
                _canJump = false;
             /* _isCrouching = false; BUG LIGHT KICK */

                if(_crouchPunch == true)
                {
                    _animation.CrouchLight();
                    if (_animation.CrouchLight() == false)
                    {
                        _isFighting = false;
                        _crouchPunch = false;
                        _canMove = true;
                        _canJump = true;
                    }
                }

                if (_lightPunch == true)
                {
                    _animation.LightPunch();
                    if (_animation.LightPunch() == false)
                    {
                        _isFighting = false;
                        _lightPunch = false;
                        _canMove = true;
                        _canJump = true;
                    }
                }
                
                if (_lightKick == true)
                {
                    _animation.LightKick();
                    if (_animation.LightKick() == false)
                    {
                        _isFighting = false;
                        _lightKick = false;
                        _canMove = true;
                        _canJump = true;
                    }
                }
            }

            // WAITING ANIMATION
            if (_isMoving == false && _isFighting == false && _isCrouching == false && _isJumping == false) _animation.Waiting();

            // JUMPING ANIMATION
            if (_isJumping == true)
            {
                i++;
                _animation.Jump();
                _shadow.Color = new Color(255, 255, 255, 255);
                if (i < 200) this._sprite.Position -= new Vector2f(0, 2F);
                if (i >= 200 && i < 300)
                {
                    this._sprite.Position -= new Vector2f(0, 1F);
                    _shadow.Scale = new Vector2f(4f, 5f);
                }
                if (i >= 300 && i < 400)
                {
                    this._sprite.Position += new Vector2f(0, 1F);
                    _shadow.Scale = new Vector2f(3f, 5f);
                }
                if (i >= 400 && i < 600)
                {
                    this._sprite.Position += new Vector2f(0, 2F);
                    _shadow.Scale = new Vector2f(4f, 5f);
                }
                if (i == 600)
                {
                    _isJumping = false;
                    i = -1;
                    _shadow.Color = new Color(255, 255, 255, 0);
                    _shadow.Scale = new Vector2f(5f, 5f);
                }
            }
        } // UPDATE BRAKET DONT REMOVE IT

        // MOVING TO THE RIGHT
        internal void MoveRight(float xToAdd)
        {
            if (_canMove == true)
            {
                _isMoving = true;
                _isCrouching = false;
                if (this._sprite.Scale.X > 0)
                {
                    if (this._sprite.Position.X < 1700)
                    {
                        this._sprite.Position += new Vector2f(xToAdd, 0);
                        if (_isJumping == false)
                        {
                            _animation.WalkingForward();
                        }
                    }
                }
                if (this._sprite.Scale.X < 0)
                {
                    if (this._sprite.Position.X < 1925)
                    {
                        this._sprite.Position += new Vector2f(xToAdd, 0);
                        if (_isJumping == false)
                        {
                            _animation.WalkingBackward();
                        }
                    }
                }
            }
        }

        // MOVING TO THE LEFT
        internal void MoveLeft(float xToRemove)
        {
            if (_canMove == true)
            {
                _isMoving = true;
                _isCrouching = false;
                if (this._sprite.Scale.X > 0)
                {
                    if (this._sprite.Position.X > 0)
                    {
                        this._sprite.Position -= new Vector2f(xToRemove, 0);
                        if (_isJumping == false)
                        {
                            _animation.WalkingBackward();
                        }
                    }
                }
                if (this._sprite.Scale.X < 0)
                {
                    if (this._sprite.Position.X > 225)
                    {
                        this._sprite.Position -= new Vector2f(xToRemove, 0);
                        if (_isJumping == false)
                        {
                            _animation.WalkingForward();
                        }
                    }
                }
            }
        }

        internal void Jump()
        {
            if (_canJump == true)
            {
                if (_isJumping == false)
                {
                    _isJumping = true;
                }
            }
        }

        internal void Crouch()
        {
            if (_canMove == true && _isJumping == false)
            {
                _isCrouching = true;
                _animation.Crouch();
            }
        }
        
        internal void LightPunch()
        {
            if (_isFighting == false)
            {
                if (_isJumping == true)
                {
                    _animation.JumpLight();
                }
                else
                {
                    _canMove = false;
                    _isFighting = true;
                    if (_isCrouching == true)
                    {
                        _crouchPunch = true;
                        _animation.CrouchLight();
                    }
                    else
                    {
                        _lightPunch = true;
                        _animation.LightPunch();
                    }
                }
            }
        }

        internal void HeavyPunch()
        {

        }

        internal void LightKick()
        {
            if (_isFighting == false)
            {
                if (_isJumping == true)
                {
                    _animation.JumpLight();
                }
                else
                {
                    _canMove = false;
                    _isFighting = true;
                    if (_isCrouching == true)
                    {
                        _crouchPunch = true;
                        _animation.CrouchLight();
                    }
                    else
                    {
                        _lightKick = true;
                        _animation.LightKick();
                    }
                }
            }
        }

        internal void HeavyKick()
        {

        }

        internal void Special()
        {

        }

        internal void TakeDammage(uint Hit)
        {
            _health = _health - Hit;
            if (_health > 100)
            {
                _health = 0;
            }
        }

        internal void GainEnergy(uint Gain)
        {
            _energy += Gain;
            if ( _energy > 100 )
            {
                _energy = 100;
            }
        }


    }
}

/*
 
if (_isJumping == true)
{
    _animation.Jump();
    _shadow.Color = new Color(255, 255, 255, 255);
        if (i < 200) this._sprite.Position -= new Vector2f(0, 1.8F);
        if (i >= 200 && i <= 300)
        {
            this._sprite.Position -= new Vector2f(0, 1.3F);
            _shadow.Scale = new Vector2f(4f, 5f);
        }
        if (i > 300 && i < 400)
        {
            this._sprite.Position += new Vector2f(0, 1.3F);
            _shadow.Scale = new Vector2f(3f, 5f);
        }
        if (i >= 400 && i <= 600)
        {
            this._sprite.Position += new Vector2f(0, 1.8F);
            _shadow.Scale = new Vector2f(4f, 5f);
        }
        if (i == 601)
        {
            _isJumping = false;
            i = 0;
            _shadow.Color = new Color(255, 255, 255, 0);
            _shadow.Scale = new Vector2f(5f, 5f);
        }
        i++;
}

*/