using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Model
{
    public class Character //:Sprite
    {
        readonly internal string _name;
        public Sprite _sprite;
        internal int _health = 100;
        internal uint _energy = 0;
        internal Vector2f _position;
        Dictionary<string, IntRect> _rects;
        string _hit;

        bool _canMove;
        bool _canJump;

        internal bool _isCrouching;
        internal bool _isMoving;
        bool _isJumping;
        bool _isFighting;
        bool _isTakingDamage;
        internal bool _isKo;
        internal bool _isWinner;

        bool _lightPunch;
        bool _lightKick;
        bool _crouchPunch;
        bool _special;

        int i = -1;
        internal Animation _animation;
      //  internal Special _special;
        public Sprite _shadow;
        public RectangleShape _hitbox;

        public Character(string name, Sprite sprite)
        {
            _name = name;
            _hit = string.Empty;
            _isJumping = false; 
            _isFighting = false;
            _isMoving = false;
            _isTakingDamage = false;
            _isKo = false;
            _isWinner = false;

            _lightPunch = false;
            _lightKick = false;
            _crouchPunch = false;
            _special = false;
            
            _canMove = true;
            _canJump = true;

            _sprite = sprite;

            _shadow = new Sprite
            {
                Texture = sprite.Texture,
                TextureRect = new IntRect(501, 17, 41, 93),
                Scale = _sprite.Scale,
                Color = new Color(255, 255, 255, 0)
            };

            _hitbox = new RectangleShape
            {
                // FillColor = Color.Red
               FillColor = new Color(255, 255, 255, 0)
            };

            _animation = new Animation(sprite, _hitbox);

        }

        public uint Energy => _energy;

        internal string Name => _name;

        internal bool IsAlive => Health != 0;

        public int Health => _health;

        internal Vector2f Position
        {
            get { return _position; }
            set { _position = value; }
        }

        internal void Update()
        {

            // SHADOW FOLOWING THE CHARACTER
            _shadow.Position = new Vector2f(0f, 580f);
            if (_sprite.Scale.X < 0)
            {
                _shadow.Position += new Vector2f(this._sprite.Position.X, 0f);
              //  if(_shadow.Scale.X < 0) _shadow.Scale = new Vector2f(_shadow.Scale.X * -1, _shadow.Scale.Y);
            }

            if (_sprite.Scale.X > 0)
            {
                _shadow.Position += new Vector2f(_sprite.Position.X, 0f);
              //  if (_shadow.Scale.X < 0) _shadow.Scale = new Vector2f(_shadow.Scale.X * -1, _shadow.Scale.Y);
            }

            _hitbox.Position = new Vector2f(0f, this._sprite.Position.Y);
            //_hitbox.Size = new Vector2f(_sprite.TextureRect.Width, _sprite.TextureRect.Height);
            _hitbox.Scale = new Vector2f(this._sprite.Scale.X, this._sprite.Scale.Y);
            if (_sprite.Scale.X < 0) _hitbox.Position += new Vector2f(_sprite.Position.X , 0f);
            if (_sprite.Scale.X > 0) _hitbox.Position += new Vector2f(_sprite.Position.X, 0f);

            // IS KO 
            if (_isKo == true)
            {
                _canMove = false;
                _canJump = false;
                _isFighting = false;

                _animation.KO();
            }

            // IS WINNING
            if (_isWinner == true)
            {
                _animation.VictoryPose();
            }

            // TAKING DAMAGE ANIMATION
            if (_isTakingDamage == true)
            {
                switch (_hit)
                {
                    case "low":
                        _animation.FaceHit();
                        if (_animation.FaceHit() == false)
                        {
                            _isTakingDamage = false;
                            _canMove = true;
                            _canJump = true;
                            _hit = string.Empty;
                        }
                        break;
                    case "crouchHit":
                        _animation.CrouchHit();
                        if (_animation.CrouchHit() == false)
                        {
                            _isTakingDamage = false;
                            _canMove = true;
                            _canJump = true;
                            _hit = string.Empty;
                        }
                        break;
                }
            }

            // FIGTHING ANIMATION
            if (_isFighting == true)
            {
                _canMove = false;
                _isMoving = false;
                _canJump = false;

                // CROUCH PUNCH
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

                // LIGHT PUNCH
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
                
                // LIGHT KICK 
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

                // SPECIAL 
                if (_special == true)
                {
                    _animation.Special();
                    if (_animation.Special() == false)
                    {
                        _isFighting = false;
                        _special = false;
                        _canMove = true;
                        _canJump = true;
                        _energy = 0;
                    }
                }
            }

            // WAITING ANIMATION
            if (_isMoving == false && _isFighting == false && _isCrouching == false && _isJumping == false && _isTakingDamage == false && _isKo == false && _isWinner == false) _animation.Waiting();

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
             //       _shadow.Scale = new Vector2f(4f, 5f);
                }
                if (i >= 300 && i < 400)
                {
                    this._sprite.Position += new Vector2f(0, 1F);
               //     _shadow.Scale = new Vector2f(3f, 5f);
                }
                if (i >= 400 && i < 600)
                {
                    this._sprite.Position += new Vector2f(0, 2F);
             //       _shadow.Scale = new Vector2f(4f, 5f);
                }
                if (i == 600)
                {
                    _isJumping = false;
                    i = -1;
                    _shadow.Color = new Color(255, 255, 255, 0);
             //       _shadow.Scale = new Vector2f(5f, 5f);
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

        // JUMP
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

        // CROUCH
        internal void Crouch()
        {
            if (_canMove == true && _isJumping == false)
            {
                _isCrouching = true;
                _animation.Crouch();
            }
        }
        
        // LIGHT PUNCH
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

        // LIGTH KICK
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

        // SPECIAL
        internal void Special()
        {
            if (_isFighting == false && _isJumping == false)
            {
                _canMove = false;
                _isFighting = true;
                _special = true;
                _animation.Special();
            }
        }

        internal bool TakeDammage(int Damage, string Hit)
        {
            if (_isTakingDamage == false)
            {
                _health -= Damage;
                _hit = Hit;
                _isTakingDamage = true;
                _canMove = false;
                _canJump = false;
                _isFighting = false;

                if (_health <= 0)
                {
                    _hit = string.Empty;
                    _isKo = true;
                    _health = 0;
                    _isTakingDamage = false;
                    _animation.KO();
                }

                if (_isCrouching == true && _hit == "low" && _isKo == false)
                {
                    _animation.CrouchHit();
                    _hit = "crouchHit";
                    return true;
                }

                if (_hit == "low" && _isKo == false)
                {
                    _animation.FaceHit();
                    return true;
                }
            }
            return false;
        }

        internal void GainEnergy(uint Gain)
        { 
            if( _energy < 100)
            {
                _energy += Gain;
            }

            if ( _energy > 100 )
            {
                _energy = 100;
            }
        }


    }
}
