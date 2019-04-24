using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFight
{
    internal class HealthBar
    {
        private Clock _clock;
        private float _windowX;
        private float _windowY;
        private List<RectangleShape> _bar = new List<RectangleShape>();
        private float _HealthPlayer1 = 100f;
        private float _HealthPlayer2 = 100f;
        private float _redTimer1 = 0f;
        private float _redTimer2 = 0f;
        private float _red1 = 0f;
        private float _red2 = 0f;
        private float _delaySecond = 0.4f;

        internal HealthBar(RenderWindow window, Game game)
        {
            _clock = game._clock;
            _windowX = window.Size.X;
            _windowY = window.Size.Y;

            //Health Bar in the back (color black) for players 1 & 2
            RectangleShape _BackHealthBar1 = new RectangleShape()
            {
                Position = new Vector2f(( _windowX * 0.10f ), ( _windowY * 0.0542f )),
                Size = new Vector2f(( _windowX * 0.30f ), ( _windowY * 0.0203f )),
                FillColor = Color.Black,
                OutlineThickness = ( 4 ),
                OutlineColor = Color.White
            };

            RectangleShape _BackHealthBar2 = new RectangleShape(_BackHealthBar1)
            {
                Position = new Vector2f(_windowX - _BackHealthBar1.Position.X - _BackHealthBar1.Size.X, _BackHealthBar1.Position.Y),
            };

            _bar.Add(_BackHealthBar1);  // Element 0
            _bar.Add(_BackHealthBar2);  // Element 1 */
                                                  //-------------------------------------------------------------------------------------------------------------------------


            // Red health bar of players 1 & 2
            RectangleShape _RedBar1 = new RectangleShape()
            {
                Position = new Vector2f(_BackHealthBar1.Position.X + _BackHealthBar1.Size.X, _BackHealthBar1.Position.Y),
                Size = _BackHealthBar1.Size,
                FillColor = Color.Red,
                Scale = new Vector2f(-1f, 1f),
            };
            RectangleShape _RedBar2 = new RectangleShape(_RedBar1)
            {
                Position = new Vector2f(_windowX - _BackHealthBar1.Position.X - _BackHealthBar1.Size.X, _BackHealthBar1.Position.Y),
                Scale = new Vector2f(1f, 1f),
            };
            _bar.Add(_RedBar1);  // Element 2
            _bar.Add(_RedBar2);  // Element 3             
            //-------------------------------------------------------------------------------------------------------------------------

            
            // Health Bar of players 1 & 2
            RectangleShape _HealthBar1 = new RectangleShape()
            {
                Position = new Vector2f(_BackHealthBar1.Position.X + _BackHealthBar1.Size.X, _BackHealthBar1.Position.Y),
                Size = _BackHealthBar1.Size,
                FillColor = Color.Green,
                Scale = new Vector2f(-1f, 1f),
            };

            RectangleShape _HealthBar2 = new RectangleShape(_HealthBar1)
            {
                Position = new Vector2f(_windowX - _BackHealthBar1.Position.X - _BackHealthBar1.Size.X, _BackHealthBar1.Position.Y),
                FillColor = Color.Green,
                Scale = new Vector2f(1f, 1f),
            };
            _bar.Add(_HealthBar1);  // Element 4
            _bar.Add(_HealthBar2);  // Element 5
        }


        private void UpdateHealthBarPlayers(float HealthPlayer1, float HealthPlayer2)
        {

            if ( _HealthPlayer1 > HealthPlayer1 )
            {
                _redTimer1 = _clock.ElapsedTime.AsSeconds();
                _red1 += _HealthPlayer1 - Convert.ToSingle(HealthPlayer1);
                _HealthPlayer1 = Convert.ToSingle(HealthPlayer1);
                // Update the Health bar of Player 
                _bar [4].Size = new Vector2f(( _windowX * 0.30f ) / 100f * HealthPlayer1, ( _windowY * 0.0203f ));
            }

            if ( _HealthPlayer2 > HealthPlayer2 )
            {
                _redTimer2 = _clock.ElapsedTime.AsSeconds();
                _red2 += _HealthPlayer2 - Convert.ToSingle(HealthPlayer2);
                _HealthPlayer2 = Convert.ToSingle(HealthPlayer2);
                // Update the Health bar of Player 
                _bar[ 5 ].Size = new Vector2f((  _windowX * 0.30f ) / 100f  * HealthPlayer2, ( _windowY * 0.0203f ));
            }
        }

        internal List<RectangleShape> Bar => _bar;

        private void UpdateRedBarPlayers()
        {
            // Update the Red Health Bar of player 1
            if ( _redTimer1 + _delaySecond < _clock.ElapsedTime.AsSeconds() && _bar[2].Size.X > _bar[4].Size.X )
            {
                _red1 -= 0.1f;
                _bar[2].Size = _bar[4].Size + new Vector2f(( ( _windowX * 0.30f / 100f ) * _red1 ), 0f);
            }

            // Update the Red Health Bar of player 2
            if ( _redTimer2 + _delaySecond < _clock.ElapsedTime.AsSeconds() && _bar[3].Size.X > _bar[5].Size.X )
            {
                _red2 -= 0.1f;
                _bar[3].Size = _bar[5].Size + new Vector2f(( ( _windowX / 100f * 30f ) / 100f * _red2 ), 0f);
            }

        }

        internal void UpdateBars(Game game)
        {
            float HealthPlayer1 = Convert.ToSingle(game._fighter1.Health);
            float HealthPlayer2 = Convert.ToSingle(game._fighter2.Health);

            this.UpdateHealthBarPlayers(HealthPlayer1, HealthPlayer2);
            this.UpdateRedBarPlayers();
        }
    }
}
