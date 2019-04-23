﻿using System;
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
        internal uint _health;
        internal uint _energy = 0;
        internal Vector2f _position;
        Dictionary<string, IntRect> _rects;
        bool _canMove;
        bool _isJumping;
        bool _isFalling;
        bool _isFighting;

        bool _lightPunch;
        bool _lightKick;
        bool _crouchPunch;

        internal bool _isCrouching;
        internal bool _isMoving;
        int i;
        internal Animation _animation;
        public Sprite _shadow;

        public Character(string name, Sprite sprite)
        {
            _name = name;
            _health = 100;
            _isJumping = false; 
            _isFalling = false;
            _isFighting = false;
            _isMoving = false;

            _lightPunch = false;
            _lightKick = false;
            _crouchPunch = false;
            

            _canMove = true;
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
             /* _isCrouching = false; BUG LIGHT KICK */

                if(_crouchPunch == true)
                {
                    _animation.CrouchLight();
                    if (_animation.CrouchLight() == false)
                    {
                        _isFighting = false;
                        _canMove = true;
                        _crouchPunch = false;
                    }
                }

                if (_lightPunch == true)
                {
                    _animation.LightPunch();
                    if (_animation.LightPunch() == false)
                    {
                        _isFighting = false;
                        _canMove = true;
                        _lightPunch = false;
                    }
                }
                
                if (_lightKick == true)
                {
                    _animation.LightKick();
                    if (_animation.LightKick() == false)
                    {
                        _isFighting = false;
                        _canMove = true;
                        _lightKick = false;
                    }
                }
            }

            // WAITING ANIMATION
            if (_isMoving == false && _isFighting == false && _isCrouching == false && _isJumping == false && _isFalling == false) _animation.Waiting();
            
            // WHILE JUMPING
            if (_isJumping == true || _isFalling == true)
            {
                _animation.Jump();
                _shadow.Color = new Color(255, 255, 255, 255);
                if (_isJumping == true && _isFalling == false)
                {
                    if (i < 200) this._sprite.Position -= new Vector2f(0, 1.8F);
                    if (i >= 200) this._sprite.Position -= new Vector2f(0, 1.3F);
                    i++;
                    if (i == 300)
                    {
                        _isJumping = false;
                        _isFalling = true;
                        i = 0;
                    }
                }
                // WHILE FALLING AFTER JUMPING
                if (_isJumping == false && _isFalling == true)
                {
                    if (i < 100) this._sprite.Position += new Vector2f(0, 1.3F);
                    if (i >= 100) this._sprite.Position += new Vector2f(0, 1.8F);
                    i++;
                    if (i == 300)
                    {
                        _isJumping = false;
                        _isFalling = false;
                        i = 0;
                        _shadow.Color = new Color(255, 255, 255, 0);
                    }
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
                        if (_isJumping == false && _isFalling == false)
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
                        if (_isJumping == false && _isFalling == false)
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
                        if (_isJumping == false && _isFalling == false)
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
                        if (_isJumping == false && _isFalling == false)
                        {
                            _animation.WalkingForward();
                        }
                    }
                }
            }
        }

        internal void Jump()
        {
            if(_isJumping == false && _isFalling == false)
            {
                _isJumping = true;
            }
        }

        internal void Crouch()
        {
            if (_canMove == true && _isFalling == false && _isJumping == false)
            {
                _isCrouching = true;
                _animation.Crouch();
            }
        }
        
        internal void LightPunch()
        {
            if (_isFighting == false)
            {
                if (_isJumping == true || _isFalling == true)
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
                if (_isJumping == true || _isFalling == true)
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