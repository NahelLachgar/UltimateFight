using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace pi
{
    public class Game { 
        public Stage stage;
        UInt16 _round = 1;
        UInt16 _roundNb;
        public Character _fighter1;
        public Character _fighter2;
        public Stage _stage;
        User _user1;
        User _user2;
        float _moveSpeed = 4;
        float _jumpSpeed = 20;
        float _gravity = 1;
        User _winner;
        User _loser;
        public Clock _clock = new Clock();
        Time _timer = new Time();
        float _timerGame = 99f;
        float _currentTime;


        public Game(Time timer, Character fighter1, Character fighter2, Stage stage, User user1=null, User user2=null)
        {
            _timer = timer;
            _fighter1 = fighter1;
            _fighter2 = fighter2;
            _stage = stage;
            _user1 = user1;
            _user2 = user2;
            _roundNb = 1;
        }

        internal void EndGame ()
        {
          /*  if (_fighter1.Health > _fighter2.Health)
            {
                _winner = _user1;
            }
            else
            {
                _winner = _user2;
            }
            _winner.Wins += 1;*/
        }

        public void Update ()
        {
            // Timer management
            _timer = _clock.ElapsedTime;
            _currentTime = _timer.AsSeconds();

            if (_fighter1.Health == 0 || _fighter2.Health == 0 || _round == _roundNb && _timer.AsSeconds() == 0)
                EndGame();

            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) _fighter1.MoveRight(1.5F);

            _fighter1.Update();
            _fighter2.Update();

            //====================================================================================
            //====================================================================================
            // *** Just for test : Must be delete in the futur ***
            // *** Key 'P' for test damages on the player's health bar, and O for reset. ***
            // *** The same for the player 2 with the key M and L. ***
            if ( Keyboard.IsKeyPressed(Keyboard.Key.P) ) _fighter1.TakeDammage(1);
            if ( Keyboard.IsKeyPressed(Keyboard.Key.O) ) _fighter1._health = 100;
            if ( Keyboard.IsKeyPressed(Keyboard.Key.M) ) _fighter2.TakeDammage(1);
            if ( Keyboard.IsKeyPressed(Keyboard.Key.L) ) _fighter2._health = 100;
            //====================================================================================
            //====================================================================================
        }
    }
}