using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFight
{
    public class Game
    {
        internal bool _startRound = true;

        public Stage stage;
        UInt16 _round = 1;
        UInt16 _roundNb;
        internal uint _player1Win = 0;
        internal uint _player2Win = 0;
        internal float _timeBeforeResetRound = -4f;
        public Character _fighter1;
        public Character _fighter2;
        public Stage _stage;
        User _user1;
        User _user2;
        float _moveSpeed = 1F;
        float _jumpSpeed = 5;
        Vector2f _velocity = new Vector2f(0, 0);
        float _gravity = 1;
        User _winner;
        User _loser;
        public Clock _clock = new Clock();
        Time _timer = new Time();
        internal float _timerGame = 99.5f;
        float _currentTime;
        internal RenderWindow _window;
        public UserInterface userInterface;
        public MenuEndGame menuEndGame = new MenuEndGame();


        public Game(Time timer, Character fighter1, Character fighter2, Stage stage, RenderWindow window, User user1 = null, User user2 = null)
        {             
            _timer = timer;
            _fighter1 = fighter1;
            _fighter2 = fighter2;
            _fighter2._sprite.Scale = new Vector2f(-5f, 5f);
            // PLAYERS'S POSITIONS
            _fighter1._sprite.Position = new Vector2f(250, 580);
            _fighter2._sprite.Position = new Vector2f(1500, 580);
            _stage = stage;
            _user1 = user1;
            _user2 = user2;
            _roundNb = 1;
            _window = window;
        }



        internal void EndRound (Character Fighter1, Character Fighter2)
        {
            if( _startRound == false && _player1Win <= 1   &&  _player2Win <= 1)
            {
                if(Fighter1._health <= 0)
                {
                    _player2Win++;
                    if (_player2Win < 2) _startRound = true;
                    _round++;
                    _timeBeforeResetRound = _clock.ElapsedTime.AsSeconds();
                } 
                else if (Fighter2._health <= 0 )
                {
                    _player1Win++;
                    if ( _player1Win < 2 ) _startRound = true;
                    _round++;
                    _timeBeforeResetRound = _clock.ElapsedTime.AsSeconds();
                }
            }


        }

        public void Update (RenderWindow window)
        {
            _window.Size = window.Size;

            if ( _startRound == true && _clock.ElapsedTime.AsSeconds() > _timeBeforeResetRound+4f)
            {
                userInterface = new UserInterface(this);
                _fighter1 = new Character(_fighter1.Name, _fighter1._sprite);
                _fighter2 = new Character(_fighter2.Name, _fighter2._sprite);
                // PLAYERS'S POSITIONS
                _fighter1._sprite.Position = new Vector2f(250, 580);
                _fighter2._sprite.Position = new Vector2f(1500, 580);
                _startRound = false;
                _clock = new Clock();
            }

            //Interface game graphic
            userInterface.Update(this);
            // Menu in-game
            menuEndGame.Update(this, userInterface.AnimationUI.KO.Finish );

            // Timer management
            _timer = _clock.ElapsedTime;
            _currentTime = _timer.AsSeconds();

            //Check if the round is over
            EndRound(_fighter1, _fighter2);


            // A CHARACTER TURN AROUND WHEN ANOTHER CHARACTER IS BEHIND HIM 
            if (_fighter1._sprite.Position.X < _fighter2._sprite.Position.X + 225)
            {

                // PLAYER 1
                if (Keyboard.IsKeyPressed(Keyboard.Key.Q)) _fighter1.MoveLeft(_moveSpeed);
                // PLAYER 2
                if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad3)) _fighter2.MoveRight(_moveSpeed);

                // IF THE PLAYERS ARE STUCK TO EACHOTHER
                if (_fighter1._sprite.Position.X + _fighter1._sprite.TextureRect.Width + 180 <= _fighter2._sprite.Position.X - 180 - _fighter2._sprite.TextureRect.Width || _fighter1._sprite.Position.Y != _fighter2._sprite.Position.Y)
                {
                    // PLAYER 1
                    if (Keyboard.IsKeyPressed(Keyboard.Key.D)) _fighter1.MoveRight(_moveSpeed);
                    // PLAYER 2
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad1)) _fighter2.MoveLeft(_moveSpeed);
                }

                // TURNING THE PLAYERS
                if (_fighter1._sprite.Scale.X < 0)
                {
                    _fighter1._sprite.Scale = new Vector2f((_fighter1._sprite.Scale.X * -1), _fighter1._sprite.Scale.Y);
                    _fighter1._sprite.Position = new Vector2f(_fighter1._sprite.Position.X - 180 - _fighter2._sprite.TextureRect.Width, _fighter1._sprite.Position.Y);

                    _fighter2._sprite.Scale = new Vector2f((_fighter2._sprite.Scale.X * -1), _fighter2._sprite.Scale.Y);

                    _fighter2._sprite.Position = new Vector2f(_fighter2._sprite.Position.X + 180 + _fighter2._sprite.TextureRect.Width, _fighter2._sprite.Position.Y);
                }
            }

            if(_fighter1._sprite.Position.X > _fighter2._sprite.Position.X -225)

            {
                // PLAYER 1
                if (Keyboard.IsKeyPressed(Keyboard.Key.D)) _fighter1.MoveRight(_moveSpeed);
                // PLAYER 2
                if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad1)) _fighter2.MoveLeft(_moveSpeed);

                // IF THE PLAYERS ARE STUCK TO EACHOTHER
                if (_fighter1._sprite.Position.X - _fighter1._sprite.TextureRect.Width - 180 >= _fighter2._sprite.Position.X + 180 + _fighter2._sprite.TextureRect.Width || _fighter1._sprite.Position.Y != _fighter2._sprite.Position.Y)
                {
                    // PLAYER 1
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Q)) _fighter1.MoveLeft(_moveSpeed);
                    // PLAYER 2
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad3)) _fighter2.MoveRight(_moveSpeed);
                }
                
                // TURNING THE PLAYERS
                if (_fighter1._sprite.Scale.X > 0)
                {
                    _fighter1._sprite.Scale = new Vector2f((_fighter1._sprite.Scale.X * -1), _fighter1._sprite.Scale.Y);
                    _fighter1._sprite.Position = new Vector2f(_fighter1._sprite.Position.X + 180 + _fighter2._sprite.TextureRect.Width , _fighter1._sprite.Position.Y);
                    
                    _fighter2._sprite.Scale = new Vector2f((_fighter2._sprite.Scale.X * -1), _fighter2._sprite.Scale.Y);
                    _fighter2._sprite.Position = new Vector2f(_fighter2._sprite.Position.X - 180 - _fighter2._sprite.TextureRect.Width, _fighter2._sprite.Position.Y);
                }
            }

          /*  Console.WriteLine(_fighter1._sprite.Position.X + _fighter1._sprite.TextureRect.Width );
          /*  Console.WriteLine(_fighter2._sprite.Position.X - _fighter2._sprite.TextureRect.Width - 180); */


            // PLAYER 1 CONTROLER
            if (Keyboard.IsKeyPressed(Keyboard.Key.Z)) _fighter1.Jump();
            if (Keyboard.IsKeyPressed(Keyboard.Key.S) && !Keyboard.IsKeyPressed(Keyboard.Key.D) && !Keyboard.IsKeyPressed(Keyboard.Key.Q)) _fighter1.Crouch();
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                _fighter1.LightPunch();
                if(_fighter1._sprite.Position.X + _fighter2._sprite.TextureRect.Width + 235> _fighter2._sprite.Position.X - _fighter2._sprite.TextureRect.Width - 235)
                {
                    _fighter2.TakeDammage(10, "low");
                }
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.E))
            {
                _fighter1.LightKick();
                if (_fighter1._sprite.Position.X + _fighter1._sprite.TextureRect.Width + 225 > _fighter2._sprite.Position.X - 235 - _fighter2._sprite.TextureRect.Width)
                {
                    _fighter2.TakeDammage(15, "low");
                }
            }

            // PLAYER 2 CONTROLER
            if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad5)) _fighter2.Jump();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad2) && !Keyboard.IsKeyPressed(Keyboard.Key.Numpad3) && !Keyboard.IsKeyPressed(Keyboard.Key.Numpad1)) _fighter2.Crouch();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad4)) _fighter2.LightPunch();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Numpad6)) _fighter2.LightKick();

            _fighter1.Update();
            _fighter2.Update();
            
            
            _window.KeyReleased += (sender, e) =>
            {
                // PLAYER 1
                if (e.Code == Keyboard.Key.D) _fighter1._isMoving = false;
                if (e.Code == Keyboard.Key.Q) _fighter1._isMoving = false;
                if (e.Code == Keyboard.Key.S) _fighter1._isCrouching = false;

                // PLAYER 2
                if (e.Code == Keyboard.Key.Numpad3) _fighter2._isMoving = false;
                if (e.Code == Keyboard.Key.Numpad1) _fighter2._isMoving = false;
                if (e.Code == Keyboard.Key.Numpad2) _fighter2._isCrouching = false;

            };

            _window.KeyPressed += (sender, e) =>
            {
                if (e.Code == Keyboard.Key.P) _fighter1.TakeDammage(100, "low");
            };
            //====================================================================================
            //====================================================================================
            // *** Just for test : Must be deleted in the futur ***
            // *** Key 'P' for test damages on the player's health bar, and O for reset. ***
            // *** The same for the player 2 with the key M and L. ***
          //  if ( Keyboard.IsKeyPressed(Keyboard.Key.P) ) _fighter1.TakeDammage(1, "low");
            if ( Keyboard.IsKeyPressed(Keyboard.Key.O) ) _fighter1._health = 100;
            if ( Keyboard.IsKeyPressed(Keyboard.Key.I) ) _fighter1.GainEnergy(1);


            if ( Keyboard.IsKeyPressed(Keyboard.Key.M) ) _fighter2.TakeDammage(1, "low");
            if ( Keyboard.IsKeyPressed(Keyboard.Key.L) ) _fighter2._health = 100;
            if ( Keyboard.IsKeyPressed(Keyboard.Key.K) ) _fighter2.GainEnergy(1);

            //====================================================================================
            //====================================================================================
        }
    }
}