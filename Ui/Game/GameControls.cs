using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace UI
{
    public class GameControls
    {
        Game _game;
        public GameControls(Game game)
        {
            _game = game;

        }

        public void Update(string key = null)
        {
            /*  if (Keyboard.IsKeyPressed(Keyboard.Key.Q)) Client.SendKey("Q");
              if (Keyboard.IsKeyPressed(Keyboard.Key.Z)) Client.SendKey("Z");
              if (Keyboard.IsKeyPressed(Keyboard.Key.S)) Client.SendKey("S");
              if (Keyboard.IsKeyPressed(Keyboard.Key.D)) Client.SendKey("D");
              if (Keyboard.IsKeyPressed(Keyboard.Key.A)) Client.SendKey("A");
              if (Keyboard.IsKeyPressed(Keyboard.Key.E)) Client.SendKey("E"); */

            // PROJECTILE 
            if (_game._fighter1._projectile.isThrown == true)
            {
                _game._fighter1._projectile.Position += new Vector2f(_game._fighter1._projectile.Path.X * _game._fighter1.Scale , _game._fighter1._projectile.Path.Y * _game._fighter1.Scale);
            }

            // ADAPTE LA TAILLE DU PERSONNAGE A LA CARTE
            if (_game._fighter1.Height != _game._stage._groundHeight && _game._fighter1._isJumping == false)
            {
                _game._fighter1._sprite.Position = new Vector2f(_game._fighter1._sprite.Position.X, _game._stage._groundHeight - _game._fighter1._sprite.TextureRect.Height * _game._fighter1._sprite.Scale.Y);
            }

            if (_game._fighter2.Height != _game._stage._groundHeight && _game._fighter2._isJumping == false)
            {
                _game._fighter2._sprite.Position = new Vector2f(_game._fighter2._sprite.Position.X, _game._stage._groundHeight - _game._fighter2._sprite.TextureRect.Height * _game._fighter2._sprite.Scale.Y);
            }

            // SHADOW
            _game._fighter1._shadow.Position = new Vector2f(0, _game._stage._groundHeight - _game._fighter1._shadow.TextureRect.Height * _game._fighter1._shadow.Scale.Y);

            // A CHARACTER TURN AROUND WHEN ANOTHER CHARACTER IS BEHIND HIM 
            // LEFT TO THE RIGHT 
            if (_game._fighter1.Position.X < _game._fighter2._sprite.Position.X + ((_game._fighter2._sprite.TextureRect.Width * _game._fighter2._sprite.Scale.X) / 2))
            {
                // PLAYER 1
               // if (key=="Q") _game._fighter1.MoveLeft(_game._moveSpeed);

                if (Keyboard.IsKeyPressed(Keyboard.Key.Q)) _game._fighter1.MoveLeft(_game._moveSpeed);
                // PLAYER 2
                if (Joystick.GetAxisPosition(0,Joystick.Axis.X) < 0) _game._fighter2.MoveRight(_game._moveSpeed);

                // TAKE DAMAGE ==========================
                // PUNCHES
                if (_game._fighter1.Hitbox > _game._fighter2.Position.X + _game._fighter2.Width)
                {
                    if (_game._fighter2.TakeDammage(10, "low") == true)
                    {
                        _game._fighter1.GainEnergy(25);
                    }
                }
                if (_game._fighter2.Hitbox < _game._fighter1.Position.X + _game._fighter1.Width && _game._fighter2.Hitbox != 0)
                {
                    if (_game._fighter1.TakeDammage(10, "low") == true)
                    {
                        _game._fighter2.GainEnergy(25);
                    }
                }

                // PROJECTILES
                if (_game._fighter1._projectile.isThrown == true)
                {
                    if (_game._fighter1._projectile.Position.X + _game._fighter1._projectile.Width > _game._fighter2._sprite.Position.X + _game._fighter2._sprite.TextureRect.Width * _game._fighter2._sprite.Scale.X)
                    {
                        _game._fighter1._projectile.isThrown = false;
                        if (_game._fighter2.TakeDammage(45, "low") == true)
                        {
                            _game._fighter1.GainEnergy(0);
                        }
                    }
                }
                // ======================================

                // LIGHT PUNCH 
                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                {
                    _game._fighter1.LightPunch();
                }
                //if (Joystick.IsButtonPressed(0, 2))
                if(Keyboard.IsKeyPressed(Keyboard.Key.RShift))
                {
                    _game._fighter2.LightPunch();
                }

                // LIGHT KICK 
                if (Keyboard.IsKeyPressed(Keyboard.Key.E))
                {
                    _game._fighter1.LightKick();
                    if (_game._fighter1._hitbox.Position.X + _game._fighter1._hitbox.Size.X * _game._fighter1._hitbox.Scale.X > _game._fighter2._sprite.Position.X + _game._fighter2._sprite.TextureRect.Width * _game._fighter2._sprite.Scale.X)
                    {
                        if (_game._fighter2.TakeDammage(15, "low") == true)
                        {
                            _game._fighter1.GainEnergy(10);
                        }
                    }
                }

                if (Joystick.IsButtonPressed(0, 1))
                {
                    _game._fighter2.LightKick();
                    if (_game._fighter2._hitbox.Position.X + _game._fighter2._hitbox.Size.X * _game._fighter2._hitbox.Scale.X > _game._fighter1._sprite.Position.X + _game._fighter1._sprite.TextureRect.Width * _game._fighter1._sprite.Scale.X)
                    {
                        if (_game._fighter1.TakeDammage(15, "low") == true)
                        {
                            _game._fighter1.GainEnergy(10);
                        }
                    }
                }

                // Special
                if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _game._fighter1.Energy == 100) _game._fighter1.SpecialMove();

                if (Joystick.IsButtonPressed(0,1) && Joystick.IsButtonPressed(0,2) && _game._fighter2.Energy == 100) _game._fighter2.SpecialMove();


                // IF THE PLAYERS ARE STUCK TO EACHOTHER
                if (_game._fighter1._sprite.Position.X + _game._fighter1._sprite.TextureRect.Width * _game._fighter1._sprite.Scale.X < _game._fighter2._sprite.Position.X + _game._fighter2._sprite.TextureRect.Width * _game._fighter2._sprite.Scale.X /* || _game._fighter1._sprite.Position.Y != _game._fighter2._sprite.Position.Y*/)
                {
                    // PLAYER 1
                    if (Keyboard.IsKeyPressed(Keyboard.Key.D)) _game._fighter1.MoveRight(_game._moveSpeed);
                    // PLAYER 2
                    if (Joystick.GetAxisPosition(0, Joystick.Axis.X) > 0) _game._fighter2.MoveLeft(_game._moveSpeed);


                }

                // TURNING THE PLAYERS
                if (_game._fighter1._sprite.Scale.X < 0)
                {
                    _game._fighter1._sprite.Scale = new Vector2f((_game._fighter1._sprite.Scale.X * -1), _game._fighter1._sprite.Scale.Y);
                    _game._fighter1._sprite.Position = new Vector2f(_game._fighter1._sprite.Position.X - _game._fighter1._sprite.TextureRect.Width * _game._fighter1._sprite.Scale.X, _game._fighter1._sprite.Position.Y);

                    _game._fighter2._sprite.Scale = new Vector2f((_game._fighter2._sprite.Scale.X * -1), _game._fighter2._sprite.Scale.Y);
                    _game._fighter2._sprite.Position = new Vector2f(_game._fighter2._sprite.Position.X + _game._fighter2._sprite.TextureRect.Width * _game._fighter2._sprite.Scale.X * -1, _game._fighter2._sprite.Position.Y);
                }

            }

            // RIGHT TO THE LEFT
            if (_game._fighter1.Position.X >= _game._fighter2._sprite.Position.X + ((_game._fighter2._sprite.TextureRect.Width * _game._fighter2._sprite.Scale.X) / 2))
            {
                // PLAYER 1
                if (Keyboard.IsKeyPressed(Keyboard.Key.D)) _game._fighter1.MoveRight(_game._moveSpeed);
                // PLAYER 2
                if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad3)) _game._fighter2.MoveRight(_game._moveSpeed);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad1)) _game._fighter2.MoveLeft(_game._moveSpeed);

                // LIGHT PUNCH 
                if (Keyboard.IsKeyPressed(Keyboard.Key.A)) _game._fighter1.LightPunch();
                
                // Special
                if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _game._fighter1.Energy == 100) _game._fighter1.SpecialMove();

                // TAKE DAMAGE ==========================
                // PUNCHES
                if (_game._fighter1.Hitbox < _game._fighter2.Position.X + _game._fighter2.Width)
                {
                    if (_game._fighter2.TakeDammage(10, "low") == true)
                    {
                        _game._fighter1.GainEnergy(25);
                    }
                }

                // PROJECTILES
                if (_game._fighter1._projectile.isThrown == true)
                {
                    if (_game._fighter1._projectile.Position.X + _game._fighter1._projectile.Width < _game._fighter2._sprite.Position.X + _game._fighter2._sprite.TextureRect.Width * _game._fighter2._sprite.Scale.X)
                    {
                        _game._fighter1._projectile.isThrown= false;
                        if (_game._fighter2.TakeDammage(20, "low") == true)
                        {
                            _game._fighter1.GainEnergy(0);
                        }
                    }
                }
                // ======================================

                // IF THE PLAYERS ARE STUCK TO EACHOTHER
                if (_game._fighter1._sprite.Position.X + _game._fighter1._sprite.TextureRect.Width * _game._fighter1._sprite.Scale.X >= _game._fighter2._sprite.Position.X + _game._fighter2._sprite.TextureRect.Width * _game._fighter2._sprite.Scale.X || _game._fighter1._sprite.Position.Y != _game._fighter2._sprite.Position.Y)
                {
                    // PLAYER 1
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Q)) _game._fighter1.MoveLeft(_game._moveSpeed);
                   
                }

                // TURNING THE PLAYERS
                if (_game._fighter1._sprite.Scale.X > 0)
                {
                    _game._fighter1._sprite.Scale = new Vector2f((_game._fighter1._sprite.Scale.X * -1), _game._fighter1._sprite.Scale.Y);
                    _game._fighter1._sprite.Position = new Vector2f(_game._fighter1._sprite.Position.X + _game._fighter2._sprite.TextureRect.Width * _game._fighter1._sprite.Scale.X * -1, _game._fighter1._sprite.Position.Y);

                    _game._fighter2._sprite.Scale = new Vector2f((_game._fighter2._sprite.Scale.X * -1), _game._fighter2._sprite.Scale.Y);
                    _game._fighter2._sprite.Position = new Vector2f(_game._fighter2._sprite.Position.X - _game._fighter2._sprite.TextureRect.Width * _game._fighter2._sprite.Scale.X, _game._fighter2._sprite.Position.Y);
                }
            }


            // PLAYER 1 CONTROLER
            if (Keyboard.IsKeyPressed(Keyboard.Key.S) && !Keyboard.IsKeyPressed(Keyboard.Key.D) && !Keyboard.IsKeyPressed(Keyboard.Key.Q)) _game._fighter1.Crouch();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Z)) _game._fighter1.Jump();

            if (Joystick.GetAxisPosition(0, Joystick.Axis.Y) < 0 && !Keyboard.IsKeyPressed(Keyboard.Key.D) && !Keyboard.IsKeyPressed(Keyboard.Key.Q)) _game._fighter1.Crouch();
            if (Joystick.GetAxisPosition(0, Joystick.Axis.Y) > 0) _game._fighter1.Jump();




            _game._fighter1.Update();
            _game._fighter2.Update();


            _game._window.KeyReleased += (sender, e) =>
            {
                // PLAYER 1
                if (e.Code == Keyboard.Key.D) _game._fighter1._isMoving = false;
                if (e.Code == Keyboard.Key.Q) _game._fighter1._isMoving = false;
                if (e.Code == Keyboard.Key.S) _game._fighter1._isCrouching = false;

               

            };

            _game._window.JoystickMoved += (sender, e) =>
            {
                // PLAYER 1
                if (e.Axis == Joystick.Axis.X) _game._fighter1._isMoving = false;
                if (e.Axis == Joystick.Axis.Y) _game._fighter1._isCrouching = false;
            };

            /*
            _game._window.KeyPressed += (sender, e) =>
            {
                if (e.Code == Keyboard.Key.P) _game._fighter1.TakeDammage(100, "low");
            };*/
            //====================================================================================
            //====================================================================================
            // *** Just for test : Must be deleted in the futur ***
            // *** Key 'P' for test damages on the player's health bar, and O for reset. ***
            // *** The same for the player 2 with the key M and L. ***
            //  if ( Keyboard.IsKeyPressed(Keyboard.Key.P) ) _game._fighter1.TakeDammage(1, "low");
            if (Keyboard.IsKeyPressed(Keyboard.Key.O)) _game._fighter1._health = 100;
            if (Keyboard.IsKeyPressed(Keyboard.Key.I)) _game._fighter1.GainEnergy(1);
            if (Keyboard.IsKeyPressed(Keyboard.Key.P)) _game._fighter1.TakeDammage(1, "low");


            if (Keyboard.IsKeyPressed(Keyboard.Key.M)) _game._fighter2.TakeDammage(1, "low");
            if (Keyboard.IsKeyPressed(Keyboard.Key.L)) _game._fighter2._health = 100;
            if (Keyboard.IsKeyPressed(Keyboard.Key.K)) _game._fighter2.GainEnergy(1);

            //====================================================================================
            //====================================================================================
        }
    }
}
