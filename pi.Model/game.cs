using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace pi
{
    public class Game { 
        Time _timer;
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
        Clock _clock = new Clock();
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
            if (_fighter1.Health == 0 || _fighter2.Health == 0 || _round == _roundNb && _timer.AsSeconds() == 0)
                EndGame();
            _fighter1.Update();
            _fighter2.Update();
        }
    }
}