using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Model
{
    public class GameInterface
    {
        private Clock _clock;
        private float _windowX;
        private float _windowY;
        private float _HealthPlayer1 = 100f;
        private float _HealthPlayer2 = 100f;
        private float _energy1 = 50f;
        private float _energy2 = 50f;

        private List<RectangleShape> _gameInterface = new List<RectangleShape>();

        private float _redTimer1 = 0f;
        private float _redTimer2 = 0f;
        private float _red1 = 0f;
        private float _red2 = 0f;
        private float _delaySecond = 0.4f;
        private Texture texture;
        private List<Sprite> animation_ko = new List<Sprite>();
        private Sprite _KO = new Sprite();
        private List<Sprite> animation_fontTimer = new List<Sprite>();
        private Sprite _fontTimer1 ;
        private Sprite _fontTimer2 ;

        private float _timerKO = 0;
        private int _iKO = 0;
        private float _timerGame = 99f;
        private bool _end = false;


        public List<Sprite> _EnergyBar = new List<Sprite>();
        public List<Sprite> _animation_BlueFlame = new List<Sprite>();
        private Sprite _blueFlame1;
        private Sprite _blueFlame2;
        private int _blueFlameCount = 14;
        private float _energyTimer = 0f;

        //Stream s = typeof(GameInterface).Assembly.GetManifestResourcestream("Ui.Resources.space_ranger.spaceranger.ttf");

        public GameInterface(RenderWindow window, Clock clock)
        {
            _clock = clock;
            _windowX = Convert.ToSingle(window.Size.X);
            _windowY = Convert.ToSingle(window.Size.Y);

            {
                
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

                _gameInterface.Add(_BackHealthBar1);  // Element 0
                _gameInterface.Add(_BackHealthBar2);  // Element 1 
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
                _gameInterface.Add(_RedBar1);  // Element 2
                _gameInterface.Add(_RedBar2);  // Element 3             
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
                _gameInterface.Add(_HealthBar1);  // Element 4:
                _gameInterface.Add(_HealthBar2);  // Element 5
                //-------------------------------------------------------------------------------------------------------------------------

                // Back Energy Bar for Player 1 & Player 2
                RectangleShape _BackEnergyBar1 = new RectangleShape()
                {
                    Position = new Vector2f(_BackHealthBar1.Position.X + _BackHealthBar1.Size.X *0.4f, ( _windowY * 0.115f )),
                    Size = new Vector2f(( _windowX * 0.176f ), ( _windowY * 0.025f )),
                    FillColor = Color.White,
                    OutlineColor = Color.Black,
                    Texture = new Texture("../../../../Ui/Resources/Img/Fight_Font/bar1.png"),
                };

                RectangleShape _BackEnergyBar2 = new RectangleShape(_BackEnergyBar1)
                {
                    Position = new Vector2f(_windowX - _BackEnergyBar1.Position.X - _BackEnergyBar1.Size.X , _BackEnergyBar1.Position.Y),
                };

                //-------------------------------------------------------------------------------------------------------------------------

                // Energy Bar for Player 1 & Player 2
                RectangleShape _EnergyBar1 = new RectangleShape()
                {
                    Position = new Vector2f(_BackHealthBar1.Position.X + _BackHealthBar1.Size.X *0.4f, ( _windowY * 0.115f )),
                    Size = new Vector2f(( _windowX * 0.176f ), ( _windowY * 0.025f )),
                    FillColor = Color.Blue,
                    OutlineColor = Color.Black,
                    //Texture = new Texture("../../../../Ui/Resources/Fight_Font/bar1.png"),
                };

                RectangleShape _EnergyBar2 = new RectangleShape(_EnergyBar1)
                {
                    Position = new Vector2f(_windowX - _BackEnergyBar1.Position.X , _BackEnergyBar1.Position.Y),
                    Scale = new Vector2f(-1f, 1f),
                };
                _gameInterface.Add(_EnergyBar1);  // Element 6
                _gameInterface.Add(_EnergyBar2);  // Element 7
                _gameInterface.Add(_BackEnergyBar1);  // Element 8
                _gameInterface.Add(_BackEnergyBar2);  // Element 9
                //-------------------------------------------------------------------------------------------------------------------------

            }


            // Sprite for draw the animation of "K.O" when a player dies
            for ( int i = 1; i <= 38; i++ )
            {
                texture = new Texture("../../../../Ui/Resources/Img/k_o/" + i + ".png");
                texture.Smooth = true;
                Sprite _ko = new Sprite(texture);
                _ko.Scale = new Vector2f(( _windowX * 0.0016f ), ( _windowY * 0.0016f ));
                _ko.Position = new Vector2f(( _windowX / 2f ) - ( _ko.Texture.Size.X / 2f * _ko.Scale.X ), ( _windowY / 2f ) - ( _ko.Texture.Size.Y / 2f * _ko.Scale.Y ));

                animation_ko.Add(_ko);
            }

            // Sprite for draw the timer in-game
            for ( int i = 0; i < 10; i++ )
            {
                texture = new Texture("../../../../Ui/Resources/Img/Fight_Font/" + i + ".png");
                texture.Smooth = true;
                Sprite font = new Sprite(texture);
                font.Scale = new Vector2f(( _windowX * 0.00105f ), ( _windowY * 0.0013f ));
                animation_fontTimer.Add(font);
            }

            // Sprite for draw the animation of blue flame for energy bars's players
            for ( int i = 1; i <= 19; i++ )
            {
                texture = new Texture("../../../../Ui/Resources/Img/Blue_Flame/Blue_Flame(photoshop)/" + i + ".png");
                texture.Smooth = true;
                Sprite flame = new Sprite(texture);
                _animation_BlueFlame.Add(flame);
            }

            _fontTimer1 = new Sprite
            {
                Texture = animation_fontTimer [ 0 ].Texture,
                Scale = new Vector2f(( _windowX * 0.00105f ), ( _windowY * 0.0013f )),
                Position = new Vector2f(( _windowX / 2f ) - animation_fontTimer [ 0 ].Texture.Size.X, ( _windowY * 0.05f )),
            };

            _fontTimer2 = new Sprite
            {
                Texture = animation_fontTimer [ 0 ].Texture,
                Scale = new Vector2f(( _windowX * 0.00105f ), ( _windowY * 0.0013f )),
                Position = new Vector2f(( _windowX / 2f ) + animation_fontTimer [ 0 ].Texture.Size.X, ( _windowY * 0.05f )),
            };

            // Animation of BlueFlame on Energy Bar for Player 1 & Player 2
            _blueFlame1 = new Sprite(_animation_BlueFlame [ 0 ].Texture, new IntRect(0, 140, 120, 140) )
            {
                Scale = new Vector2f(( _windowX * 0.00025f ), ( _windowY * 0.00035f )),
                Position = new Vector2f(( _windowX * 0.209f ), ( _windowY * 0.0885f )),
            };

            _blueFlame2 = new Sprite(_animation_BlueFlame [ 0 ].Texture, new IntRect(0, 140, 120, 140))
            {
                // Don't forget to multiply by the scale applicated :  Here it's by 0.4f
                Scale = new Vector2f(( _windowX * 0.00025f ), ( _windowY * 0.00035f )),
                Position = new Vector2f(_windowX - _blueFlame1.Position.X  - (_blueFlame1.TextureRect.Width * _blueFlame1.Scale.X), _blueFlame1.Position.Y),
            };

                //================================================================================================================================

            // End Builder--------------------------------------------------------------------------------------------------------------------

        }





        public List<RectangleShape> GetGameInterface
            => _gameInterface;


        private void UpdateTimerGame()
        {
            float time = _timerGame - _clock.ElapsedTime.AsSeconds();
            decimal font_time1;
            decimal font_time2;
            if ( time > 0f )
            {
                font_time1 = Math.Truncate(Convert.ToDecimal(time / 10f));
                font_time2 = Math.Truncate(Convert.ToDecimal(time) - (font_time1*10)  );

                _fontTimer1.Texture = animation_fontTimer [ Convert.ToInt32(font_time1) ].Texture;
                _fontTimer2.Texture = animation_fontTimer [ Convert.ToInt32(font_time2) ].Texture;
                //_text.DisplayedString = String.Format("{0}{1}", font_time1, font_time2);
            }
        }

        public Sprite FontTime1
            => _fontTimer1;

        public Sprite FontTime2
            => _fontTimer2;

        private void UpdateHealthBarPlayers(float HealthPlayer1 , float HealthPlayer2)
        {
            if ( _HealthPlayer1 > HealthPlayer1 )
            {
                _redTimer1 = _clock.ElapsedTime.AsSeconds();
                _red1 += _HealthPlayer1 - Convert.ToSingle(HealthPlayer1);
                _HealthPlayer1 = Convert.ToSingle(HealthPlayer1);
                // Update the Health bar of Player 
                _gameInterface [4].Size = new Vector2f(( _windowX * 0.30f ) / 100f * HealthPlayer1, ( _windowY * 0.0203f ));
            }

            if ( _HealthPlayer2 > HealthPlayer2 )
            {
                _redTimer2 = _clock.ElapsedTime.AsSeconds();
                _red2 += _HealthPlayer2 - Convert.ToSingle(HealthPlayer2);
                _HealthPlayer2 = Convert.ToSingle(HealthPlayer2);
                // Update the Health bar of Player 
                _gameInterface [ 5 ].Size = new Vector2f((  _windowX * 0.30f ) / 100f  * HealthPlayer2, ( _windowY * 0.0203f ));
            }
        }
       
        private void UpdateEnergyBar(uint Energy1, uint Energy2)
        {
            _energy1 = Convert.ToSingle(Energy1);
            _energy2 = Convert.ToSingle(Energy2);

            _gameInterface [ 6 ].Size = new Vector2f(_gameInterface [ 8 ].Size.X / 100f * _energy1, _gameInterface [ 6 ].Size.Y);
            _gameInterface [ 7 ].Size = new Vector2f(_gameInterface [ 9 ].Size.X / 100f * _energy2, _gameInterface [ 7 ].Size.Y);
        }

        private void UpdateRedBarPlayers()
        {
           // Update the Red Health Bar of player 1
           if(_redTimer1 + _delaySecond < _clock.ElapsedTime.AsSeconds() && _gameInterface[2].Size.X > _gameInterface[4].Size.X)
            {
                _red1 -= 0.1f;
                _gameInterface[2].Size = _gameInterface[4].Size + new Vector2f(  ((_windowX * 0.30f / 100f) * _red1) , 0f   );
            }

            // Update the Red Health Bar of player 2
            if ( _redTimer2 + _delaySecond < _clock.ElapsedTime.AsSeconds() && _gameInterface[3].Size.X > _gameInterface[5].Size.X )
            {
                _red2 -= 0.1f;
                _gameInterface[3].Size = _gameInterface[5].Size + new Vector2f(( ( _windowX / 100f * 30f ) / 100f * _red2 ), 0f);
            }

        }

        private void EndGame()
        {
            if ( ( _HealthPlayer1 == 0 || _HealthPlayer2 == 0 ) && _timerKO < _clock.ElapsedTime.AsSeconds() && _iKO < 38 )
            {
                _KO = animation_ko [ _iKO ];
                _iKO++;
                _timerKO = _clock.ElapsedTime.AsSeconds() + 0.0400f;
                _end = true;
            }

        }

        public Sprite KO
            => _KO;


        public void Update(uint HealthPlayer1, uint HealthPlayer2, uint EnergyPlayer1, uint EnergyPlayer2)
        {
            if ( _end == false )
            {
                UpdateHealthBarPlayers(HealthPlayer1, HealthPlayer2);
                //UpdateTimerGame();
            }
             UpdateRedBarPlayers();
            UpdateEnergyBar(EnergyPlayer1, EnergyPlayer2);
            UpdateEnergyFlame();
            EndGame();
        }

        public List<Sprite> EnergyBar
            => _EnergyBar;

        private void UpdateEnergyFlame()
        {
            if ( _clock.ElapsedTime.AsSeconds() > _energyTimer + 0.02f )
            {
                _blueFlame1.Texture = _animation_BlueFlame [ _blueFlameCount ].Texture;
               _blueFlame1.Position = new Vector2f(  _gameInterface [ 6 ].Position.X + _gameInterface[6].Size.X - 30f , _gameInterface [ 6 ].Position.Y - _gameInterface[6].Size.Y);

                _blueFlame2.Texture = _animation_BlueFlame [ _blueFlameCount ].Texture;
                _blueFlame2.Position = new Vector2f(_gameInterface [ 7 ].Position.X - _gameInterface [ 7 ].Size.X - 30f, _gameInterface [ 6 ].Position.Y - _gameInterface [ 7 ].Size.Y);


                _energyTimer += 0.115f;
                if ( _blueFlameCount < 18 ) _blueFlameCount++;
                else _blueFlameCount = 14; 
            }

        }

        public Sprite BlueFame1
            => _blueFlame1;

        public Sprite BlueFlame2
            => _blueFlame2;


    }
}
