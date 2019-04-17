using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace pi
{
    public class Character //:Sprite
    {
        readonly internal string _name;
        public Sprite _sprite;
        // internal Special _special;
        internal uint _health;
        internal Vector2f _position;
        Dictionary<string, IntRect> _rects;
        bool _isJumping;
        bool _isFalling;
        int i;
        //Animation _animation;

        public Character(string name, Sprite sprite)
        {
            _name = name;
            _health = 100;
            _sprite = sprite;
            _isJumping = false;
            _isFalling = false;
            // _animation = new Animation(this);
        }

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
            // WHILE JUMPING
            if (_isJumping == true && _isFalling == false)
            {
                if(i < 200) this._sprite.Position -= new Vector2f(0, 1.8F);
                if(i >= 200) this._sprite.Position -= new Vector2f(0, 1.3F);
                i++;
                if(i == 300)
                {
                    _isJumping = false;
                    _isFalling = true;
                    i = -1;
                }
            }
            // WHILE FALLING AFTER JUMPING
            if (_isJumping == false && _isFalling == true)
            {
                if (i == -1) i = 0;
                if (i < 100) this._sprite.Position += new Vector2f(0, 1.3F);
                if (i >= 100) this._sprite.Position += new Vector2f(0, 1.8F);
                i++;
                if(i == 300)
                {
                    _isJumping = false;
                    _isFalling = false;
                    i = 0;
                }
            }
        }

        internal void Waiting()
        {

        }

        internal void MoveRight(float xToAdd)
        {
            if (this._sprite.Scale.X > 0)
            {
                if (this._sprite.Position.X < 1655)
                {
                    this._sprite.Position += new Vector2f(xToAdd, 0);
                }
            }
            if (this._sprite.Scale.X < 0)
            {
                if (this._sprite.Position.X < 1990)
                {
                    this._sprite.Position += new Vector2f(xToAdd, 0);
                }
            }
        }

        internal void MoveLeft(float xToRemove)
        {
            if (this._sprite.Scale.X > 0)
            {
                if (this._sprite.Position.X > -75)
                {
                    this._sprite.Position -= new Vector2f(xToRemove, 0);
                }
            }
            if (this._sprite.Scale.X < 0)
            {
                if (this._sprite.Position.X > 250)
                {
                    this._sprite.Position -= new Vector2f(xToRemove, 0);
                }
            }
            
        }

        internal void Jump()
        {
            if(_isJumping != true && _isFalling != true)
            {
                _isJumping = true;
            }
        }

        internal void LightPunch()
        {
        }

        internal void HeavyPunch()
        {

        }

        internal void LightKick()
        {

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
    }
}