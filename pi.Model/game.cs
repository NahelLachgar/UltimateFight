using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace pi
{
    public class Game { 
        Time _timer;
        User _player1;
        User _player2;
        float _moveSpeed = 4.0f;
        float _jumpSpeed = 20.0F;
        float _gravity = 1;
        int _groundHeight = 600;

        public Game(Time timer, User player1, User player2)
        {
            _timer = timer;
            _player1 = player1;
            _player2 = player2;
        }
        internal void EndGame ()
        {
           
        }
        public void Update ()
        {
            _player1.Update();
            _player2.Update();
        }
    }
}