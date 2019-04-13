using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace pi
{
    public class GameInterface
    {
        private Text _text;
        private RectangleShape _HealthBar1;
        private RectangleShape _BackHealthBar1;
        private RectangleShape _RedBar1;
        private RectangleShape _RedBar2;
        private RectangleShape _HealthBar2;
        private RectangleShape _BackHealthBar2;
        private float _windowX;
        private float _windowY;
        private float _HealthPlayer1 = 100f;
        private float _HealthPlayer2 = 100f;
        private float _OldHealth1 = 100f;
        private float _OldHealth2 = 100f;
        private Clock _clock;
        private float _currentTimer;
        private float _redTimer1 = 0f;
        private float _redTimer2 = 0f;
        private float _red1 = 0f;
        private float _red2 = 0f;





        Stream s = typeof(GameInterface).Assembly.GetManifestResourceStream("pi.Ui.Resources.space_ranger.spaceranger.ttf");
        private List<RectangleShape> _gameInterface = new List<RectangleShape>();


        public GameInterface(RenderWindow window, Clock clock)
        {
            _clock = clock;
            _windowX = Convert.ToSingle(window.Size.X);
            _windowY = Convert.ToSingle(window.Size.Y);
            /* _text = new Text()
             {
                 Font = new Font(s),
                 CharacterSize = 64,
                 FillColor = Color.Blue,
                 OutlineThickness = 5.0F,
                 OutlineColor = Color.White,
                 Style = 0
             };*/

            _HealthBar1 = new RectangleShape()
            {
                Position = new Vector2f((_windowX /100f * 10f), 30f),
                Size = new Vector2f((_windowX /100f *30f), 20f),
                FillColor = Color.Green,
            };

            _BackHealthBar1 = new RectangleShape()
            {
                Position = new Vector2f(( _windowX / 100f * 10f), 30f),
                Size = new Vector2f(( _windowX / 100f *30f), 20f),
                FillColor = Color.Black,
                OutlineThickness = (4),
                OutlineColor = Color.White
            };

            _HealthBar2 = new RectangleShape()
            {
                Position = new Vector2f(_windowX - (_HealthBar1.Size.X + _HealthBar1.Position.X ), 30f),
                Size = new Vector2f(( _windowX / 100f *30f), 20f),
                FillColor = Color.Green,
            };

            _BackHealthBar2 = new RectangleShape()
            {
                Position = new Vector2f(_windowX - (_HealthBar1.Size.X + _HealthBar1.Position.X ), 30f),
                Size = new Vector2f(( _windowX / 100f *30f), 20f),
                FillColor = Color.Black,
                OutlineThickness = (4),
                OutlineColor = Color.White
            };

            _RedBar1 = new RectangleShape()
            {
                //Position = new Vector2f(( _windowX / 100f * 10f), 30f),
                //Size = new Vector2f(0f, 20f),
                Position = _HealthBar1.Position,
                Size = _HealthBar1.Size,
                FillColor = Color.Red,
            };

            _RedBar2 = new RectangleShape()
            {
                //Position = new Vector2f(_windowX - ( _HealthBar1.Size.X + _HealthBar1.Position.X ), 30f),
                //Size = new Vector2f(0f, 20f),
                Position = _HealthBar2.Position,
                Size = _HealthBar2.Size,
                FillColor = Color.Red,
            };

            _gameInterface.Add(_BackHealthBar1);
            _gameInterface.Add(_BackHealthBar2);
            _gameInterface.Add(_RedBar1);
            _gameInterface.Add(_RedBar2);
            _gameInterface.Add(_HealthBar1);
            _gameInterface.Add(_HealthBar2);
        }


        internal RectangleShape HealthBar1
            =>  _HealthBar1;

        internal RectangleShape BackHealthBar1
            => _BackHealthBar1;

        internal RectangleShape RedBar1
            => _RedBar1;

        internal RectangleShape HealthBar2
            => _HealthBar2;

        internal RectangleShape BackHealthBar2
            => _BackHealthBar2;

        public List<RectangleShape> GetGameInterface
            => _gameInterface;

        public void Update(uint HealthPlayer1, uint HealthPlayer2)
        {
            UpdateHealthBarPlayers(HealthPlayer1, HealthPlayer2);
            UpdateRedBarPlayers();
        }

        private void UpdateHealthBarPlayers(float HealthPlayer1 , float HealthPlayer2)
        {
            if ( _HealthPlayer1 > HealthPlayer1 )
            {
                _redTimer1 = _clock.ElapsedTime.AsSeconds();
                _red1 += _HealthPlayer1 - Convert.ToSingle(HealthPlayer1);
                _HealthPlayer1 = Convert.ToSingle(HealthPlayer1);
                // Update the Health bar of Player 
                _gameInterface [4].Size = new Vector2f(( _windowX / 100f * 30f ) / 100f * HealthPlayer1, 20f);
            }

            if ( _HealthPlayer2 > HealthPlayer2 )
            {
                _redTimer2 = _clock.ElapsedTime.AsSeconds();
                _red2 += _HealthPlayer2 - Convert.ToSingle(HealthPlayer2);
                _HealthPlayer2 = Convert.ToSingle(HealthPlayer2);
                // Update the Health bar of Player 
                _gameInterface [5].Size = new Vector2f(( _windowX / 100f * 30f ) / 100f * HealthPlayer2, 20f);
            }
        }
       
        private void UpdateRedBarPlayers()
        {
           // Update the Red Health Bar of player 1
           if(_redTimer1 + 1f < _clock.ElapsedTime.AsSeconds() && _RedBar1.Size.X > _HealthBar1.Size.X)
            {
                _red1 -= 0.1f;
                _RedBar1.Size = _HealthBar1.Size + new Vector2f(  ((_windowX / 100f * 30f) / 100f * _red1) , 0f   );
            }

            // Update the Red Health Bar of player 2
            if ( _redTimer2 + 1f < _clock.ElapsedTime.AsSeconds() && _RedBar2.Size.X > _HealthBar2.Size.X )
            {
                _red2 -= 0.1f;
                _RedBar2.Size = _HealthBar2.Size + new Vector2f(( ( _windowX / 100f * 30f ) / 100f * _red2 ), 0f);
            }

        }


    }
}
