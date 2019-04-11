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
        private RectangleShape _HealthBar2;
        private RectangleShape _BackHealthBar2;
        private float _windowX;
        private float _windowY;



        Stream s = typeof(GameInterface).Assembly.GetManifestResourceStream("pi.Ui.Resources.space_ranger.spaceranger.ttf");
        private List<RectangleShape> _gameInterface = new List<RectangleShape>();


        public GameInterface(RenderWindow window)
        {
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
                Position = new Vector2f(( _windowX / 100f * 10f), 30f),
                Size = new Vector2f(0f, 20f),
                FillColor = Color.Red,
            };

            
            _gameInterface.Add(_BackHealthBar1);
            _gameInterface.Add(_BackHealthBar2);
            _gameInterface.Add(_RedBar1);
            _gameInterface.Add(_HealthBar1);
            _gameInterface.Add(_HealthBar2);

        }


        internal RectangleShape GetHealthBar1
            =>  _HealthBar1;

        internal RectangleShape GetBackHealthBar1
            => _BackHealthBar1;

        internal RectangleShape GetRedBar1
            => _RedBar1;

        internal RectangleShape GetHealthBar2
            => _HealthBar2;

        internal RectangleShape GetBackHealthBar2
            => _BackHealthBar2;

        public List<RectangleShape> GetGameInterface
            => _gameInterface;

        public void Update(uint HealthPlayer1, uint HealthPlayer2)
        {
            float _HealthPlayer1 = Convert.ToSingle(HealthPlayer1);
            float _HealthPlayer2 = Convert.ToSingle(HealthPlayer2);

            if ( _HealthPlayer1 > 0f && _HealthPlayer1 <= 100 )
            {
                _gameInterface[3].Size = new Vector2f( ( (_windowX / 100f * 30f) ) / 100f * _HealthPlayer1, 20f);
            }
            else _gameInterface[3].Size = new Vector2f(0f, 20f);

            if ( _HealthPlayer2 > 0f && _HealthPlayer2 <= 100 )
            {
                _gameInterface [ 4 ].Size = new Vector2f(( Convert.ToSingle(_windowX / 100 * 30) ) / 100f * _HealthPlayer2, 20f);
            }
            else _gameInterface [ 4 ].Size = new Vector2f(0f, 20f);


        }
    }
}
