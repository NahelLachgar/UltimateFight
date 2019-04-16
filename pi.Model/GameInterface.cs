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
        private float _delaySecond = 0.4f;
        private Texture texture;
        private List<Sprite> animation_ko = new List<Sprite>();
        private Sprite _KO = new Sprite();
        private List<Sprite> animation_fontTimer = new List<Sprite>();
        private Sprite _fontTimer1 ;
        private Sprite _fontTimer2 ;
        private bool endGame = false;
        private float _timerKO = 0;
        private int _iKO = 0;
        private float _timerGame = 99f;
        private bool _end = false;
        private Sprite _BackEnergyBar1;
        private Sprite _BackEnergyBar2;

        public List<Sprite> _EnergyBar = new List<Sprite>();
        public List<Sprite> _animation_BlueFlame = new List<Sprite>();
        private Sprite _blueFlame1;
        private Sprite _blueFlame2;
        private int _blueFlameCount = 14;
        private float _energyTimer = 0f;


        //Stream s = typeof(GameInterface).Assembly.GetManifestResourceStream("pi.Ui.Resources.space_ranger.spaceranger.ttf");
        private List<RectangleShape> _gameInterface = new List<RectangleShape>();


        public GameInterface(RenderWindow window, Clock clock)
        {
            _clock = clock;
            _windowX = Convert.ToSingle(window.Size.X);
            _windowY = Convert.ToSingle(window.Size.Y);
            /* _text = new Text()
             {
                 DisplayedString = String.Format("{0}", _timerGame),
                 //Font = new Font("../../../../pi.Ui/Resources/space_ranger/spaceranger.ttf"),
                 Font = new Font("../../../../pi.Ui/Resources/monsters_attack/Monsters_Attack.ttf"),
                 Scale = new Vector2f( 1.5f, 1f),
                 CharacterSize = 64,
                 FillColor = Color.Blue,
                 OutlineThickness = 5.0F,
                 OutlineColor = Color.White,
                 Style = 0,
                 Position = new Vector2f(( _windowX / 2f )-50f, 20.0f)
             };*/

            // Sprite for draw the animation of "K.O" when a player dies
            for ( int i = 1; i <= 38; i++ )
            {
                texture = new Texture("../../../../pi.Ui/Resources/k_o/" + i + ".png");
                Sprite _ko = new Sprite(texture);
                _ko.Scale = new Vector2f(  (_windowX * 0.0016f)    , ( _windowY * 0.0016f )  );
                _ko.Position = new Vector2f(  (_windowX / 2f) - (_ko.Texture.Size.X / 2f *_ko.Scale.X)  , ( _windowY / 2f ) - ( _ko.Texture.Size.Y / 2f * _ko.Scale.Y )  );

                animation_ko.Add(_ko);
            }

            // Sprite for draw the timer in-game
            for ( int i = 0; i < 10; i++ )
            {
                texture = new Texture("../../../../pi.Ui/Resources/Fight_Font/" + i + ".png");
                Sprite font = new Sprite(texture);
                font.Scale = new Vector2f(( _windowX * 0.00105f ), ( _windowY * 0.0013f ));
                animation_fontTimer.Add(font);
            }

            // Sprite for draw the animation of blue flame for energy bars's players
            for ( int i = 1; i <= 19; i++ )
            {
                texture = new Texture("../../../../pi.Ui/Resources/Blue_Flame/Blue_Flame(photoshop)/" + i + ".png");
                Sprite flame = new Sprite(texture);
                _animation_BlueFlame.Add(flame);
            }

            _fontTimer1 = new Sprite
            {
                Texture = animation_fontTimer [0].Texture,
                //Position = new Vector2f(( _windowX / 2f ) - Convert.ToSingle(animation_fontTimer[0].TextureRect.Width), 40.0f),
                Scale = new Vector2f(( _windowX * 0.00105f ), ( _windowY * 0.0013f )),
                Position = new Vector2f(( _windowX / 2f ) - animation_fontTimer [ 0 ].Texture.Size.X, ( _windowY * 0.05f )),

        };

            _fontTimer2 = new Sprite
            {
                Texture = animation_fontTimer [ 0 ].Texture,
                Scale = new Vector2f(( _windowX * 0.00105f ), ( _windowY * 0.0013f )),
                Position = new Vector2f(( _windowX / 2f ) + animation_fontTimer [ 0 ].Texture.Size.X, ( _windowY * 0.05f )),
            };

            _HealthBar1 = new RectangleShape()
            {
                Position = new Vector2f((_windowX * 0.10f), ( _windowY * 0.0542f )),
                Size = new Vector2f((_windowX * 0.30f), ( _windowY * 0.0210f)),
                FillColor = Color.Green,
            };


            _RedBar1 = new RectangleShape()
            {
                Position = new Vector2f(( _windowX * 0.10f ), ( _windowY * 0.0542f )),
                Size = new Vector2f(( _windowX * 0.30f ), ( _windowY * 0.0203f )),
                FillColor = Color.Red,
            };

            _BackHealthBar1 = new RectangleShape()
            {
                Position = new Vector2f(( _windowX * 0.10f ), ( _windowY * 0.0542f )),
                Size = new Vector2f(( _windowX * 0.30f ), ( _windowY * 0.0203f )),
                FillColor = Color.Black,
                OutlineThickness = (4),
                OutlineColor = Color.White
            };




            _HealthBar2 = new RectangleShape()
            {
                Position = new Vector2f(_windowX - (_HealthBar1.Size.X + _HealthBar1.Position.X ), ( _windowY * 0.0542f )),
                Size = new Vector2f(( _windowX * 0.30f ), ( _windowY * 0.0203f )),
                FillColor = Color.Green,
            };

            _BackHealthBar2 = new RectangleShape()
            {
                Position = new Vector2f(_windowX - (_HealthBar1.Size.X + _HealthBar1.Position.X ), ( _windowY * 0.0542f )),
                Size = new Vector2f(( _windowX * 0.30f ), ( _windowY * 0.0203f )),
                FillColor = Color.Black,
                OutlineThickness = (4),
                OutlineColor = Color.White
            };

            _RedBar2 = new RectangleShape()
            {
                Position = new Vector2f(_windowX - ( _HealthBar1.Size.X + _HealthBar1.Position.X ), ( _windowY * 0.0542f )),
                Size = new Vector2f(( _windowX * 0.30f ), ( _windowY * 0.0203f )),
                FillColor = Color.Red,
            };

            _gameInterface.Add(_BackHealthBar1);
            _gameInterface.Add(_BackHealthBar2);
            _gameInterface.Add(_RedBar1);
            _gameInterface.Add(_RedBar2);
            _gameInterface.Add(_HealthBar1);
            _gameInterface.Add(_HealthBar2);


            texture = new Texture("../../../../pi.Ui/Resources/Fight_Font/bar1.png");
            _BackEnergyBar1 = new Sprite()
            {
                Texture = texture,
                Scale = new Vector2f(( _windowX * 0.000157f ), ( _windowY * 0.00047f )),
                Position = new Vector2f(( _windowX * 0.227f ), (_windowY * 0.11f)),               
            };
            _EnergyBar.Add(_BackEnergyBar1);


            _BackEnergyBar2 = new Sprite()
            {
                Texture = texture,
                Scale = new Vector2f(( _windowX * 0.000157f ), ( _windowY * 0.00047f )),
                Position = new Vector2f(_windowX - _BackEnergyBar1.Position.X - ( _BackEnergyBar1.Texture.Size.X * _BackEnergyBar1.Scale.X ), ( _windowY * 0.11f )),
            };
            _EnergyBar.Add(_BackEnergyBar2);




            // Animation of BlueFlame on Energy Bar for Player 1
            _blueFlame1 = new Sprite(_animation_BlueFlame [ 0 ].Texture, new IntRect(0, 140, 120, 140) )
            {
                Scale = new Vector2f(( _windowX * 0.00025f ), ( _windowY * 0.00035f )),
                Position = new Vector2f(( _windowX * 0.217f ), ( _windowY * 0.082f )),
            };

            _blueFlame2 = new Sprite(_animation_BlueFlame [ 0 ].Texture, new IntRect(0, 140, 120, 140))
            {
                // Don't forget to multiply by the scale applicated :  Here it's by 0.4f
                Scale = new Vector2f(( _windowX * 0.00025f ), ( _windowY * 0.00035f )),
                Position = new Vector2f(_windowX - _blueFlame1.Position.X  - (_blueFlame1.TextureRect.Width * _blueFlame1.Scale.X), ( _windowY * 0.082f )),
            };

            //================================================================================================================================
            // End Builder--------------------------------------------------------------------------------------------------------------------
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
       
        private void UpdateRedBarPlayers()
        {
           // Update the Red Health Bar of player 1
           if(_redTimer1 + _delaySecond < _clock.ElapsedTime.AsSeconds() && _RedBar1.Size.X > _HealthBar1.Size.X)
            {
                _red1 -= 0.1f;
                _gameInterface[2].Size = _HealthBar1.Size + new Vector2f(  ((_windowX * 0.30f / 100f) * _red1) , 0f   );
            }

            // Update the Red Health Bar of player 2
            if ( _redTimer2 + _delaySecond < _clock.ElapsedTime.AsSeconds() && _RedBar2.Size.X > _HealthBar2.Size.X )
            {
                _red2 -= 0.1f;
                _gameInterface[3].Size = _HealthBar2.Size + new Vector2f(( ( _windowX / 100f * 30f ) / 100f * _red2 ), 0f);
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

        public Text Text
            => _text;

        public void Update(uint HealthPlayer1, uint HealthPlayer2)
        {
            if ( _end == false )
            {
                UpdateHealthBarPlayers(HealthPlayer1, HealthPlayer2);
                UpdateTimerGame();
            }
            UpdateEnergyBar();
            UpdateRedBarPlayers();
            EndGame();
        }

        public List<Sprite> EnergyBar
            => _EnergyBar;

        private void UpdateEnergyBar()
        {
            if ( _clock.ElapsedTime.AsSeconds() > _energyTimer + 0.02f )
            {
                _blueFlame1.Texture = _animation_BlueFlame [ _blueFlameCount ].Texture;
                _blueFlame2.Texture = _animation_BlueFlame [ _blueFlameCount ].Texture;

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
