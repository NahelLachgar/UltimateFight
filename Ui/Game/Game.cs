using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace UI
{
    public class Game : IAppState
    {
        public IAppState _nextState { get; set; }
        public int _intMenus = 0;
        internal bool _startRound = true;
        internal Server _server;
        internal string _host;
        internal GameControls _controls;
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
        internal float _moveSpeed = 1F;
        float _jumpSpeed = 5;
        Vector2f _velocity = new Vector2f(0, 0);
        float _gravity = 1;
        User _winner;
        User _loser;
        public Clock _clock = new Clock();
        Time _timer = new Time();
        internal float _timerGame = 99.5f;
        float _currentTime;
        public RenderWindow _window;
        public UserInterface _userInterface;
        //public Sound _music = new Sound();

        public GameEndMenu _gameEndMenu;   
        public Game(Time timer, Character fighter1, Character fighter2, Stage stage, RenderWindow window, User user1 = null, User user2 = null, string host = null)
        {
            _server = new Server (this, "127.0.0.1");
            _server.Start();

            _timer = timer;
            _fighter1 = fighter1;
            _fighter2 = fighter2;
            _fighter2._sprite.Scale = new Vector2f(_fighter2._sprite.Scale.X * -1, fighter2._sprite.Scale.Y);
            _stage = stage;
            _user1 = user1;
            _user2 = user2;
            _roundNb = 1;
            _window = window;
            _controls = new GameControls(this);
            _userInterface = new UserInterface(this);
            //_music._currentMusic = _music._musicGame;
            //_music._currentMusic.Play();

            _nextState = this;
            _gameEndMenu = new GameEndMenu(this);

        }

        internal void EndRound (Character Fighter1, Character Fighter2)
        {
            if (_startRound == false && _player1Win <= 1 && _player2Win <= 1)
            {
                if (Fighter1._health <= 0)
                {
                    _player2Win++;
                    if (_player2Win < 2) _startRound = true;
                    _round++;
                    _timeBeforeResetRound = _clock.ElapsedTime.AsSeconds();
                }
                else if (Fighter2._health <= 0)
                {
                    _player1Win++;
                    if ( _player1Win < 2 ) _startRound = true;
                    _round++;
                    _timeBeforeResetRound = _clock.ElapsedTime.AsSeconds();
                }
            }
        }

        public void Draw(RenderWindow window)
        {

        }

        public IAppState Update(RenderWindow window)
        {
            _userInterface.Draw(window);
            _controls.Update();
            _window.Size = window.Size;

            if (_startRound == true && _clock.ElapsedTime.AsSeconds() > _timeBeforeResetRound + 4f)
            {
                _userInterface = new UserInterface(this);
                _fighter1 = new Character(_fighter1.Name, _fighter1._sprite, _fighter1._animationRect, _fighter1._projectile);
                _fighter2 = new Character(_fighter2.Name, _fighter2._sprite, _fighter2._animationRect, _fighter2._projectile);
                _startRound = false;
                _clock = new Clock();
            }

            //Interface game graphic
            _userInterface.Update(this);

            // Timer management
            _timer = _clock.ElapsedTime;
            _currentTime = _timer.AsSeconds();

            //Check if the round is over
            EndRound(_fighter1, _fighter2);


            /*   // IF FIGHTERS WINS
               if (_fighter2.Health == 0)
               {
                   _fighter1._isWinner = true;
               }
               if (_fighter1.Health == 0)
               {
                   _fighter2._isWinner = true;

               }
               */
            // Menu in-game
            _gameEndMenu.Update(this, _userInterface.AnimationUI.KO.Finish);
            return this._nextState;
           
        }

        internal uint NameWinner()
        {
            if (_player1Win == 2) return 1;
            else if (_player2Win == 2) return 2;
            else return 0;
        }
    }
}
