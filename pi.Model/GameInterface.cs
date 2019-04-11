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
        Text _text;
        internal RectangleShape _HealthBar1;
        RectangleShape _BackHealthBar1;
        RectangleShape _RedBar1;
        RectangleShape _HealthBar2;
        RectangleShape _BackHealthBar2;

        Stream s = typeof(GameInterface).Assembly.GetManifestResourceStream("pi.Ui.Resources.space_ranger.spaceranger.ttf");
        public List<RectangleShape> _inteface = new List<RectangleShape>();


        public GameInterface(RenderWindow _window)
        {
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
                Position = new Vector2f((_window.Size.X /100 * 10), 30),
                Size = new Vector2f((_window.Size.X /100 *30), 20),
                FillColor = Color.Green,
            };

            _BackHealthBar1 = new RectangleShape()
            {
                Position = new Vector2f((_window.Size.X /100 * 10), 30),
                Size = new Vector2f((_window.Size.X /100 *30), 20),
                FillColor = Color.Black,
                OutlineThickness = (4),
                OutlineColor = Color.White
            };

            _HealthBar2 = new RectangleShape()
            {
                Position = new Vector2f(_window.Size.X - (_HealthBar1.Size.X + _HealthBar1.Position.X ), 30),
                Size = new Vector2f((_window.Size.X /100 *30), 20),
                FillColor = Color.Green,
            };

            _BackHealthBar2 = new RectangleShape()
            {
                Position = new Vector2f(_window.Size.X - (_HealthBar1.Size.X + _HealthBar1.Position.X ), 30),
                Size = new Vector2f((_window.Size.X /100 *30), 20),
                FillColor = Color.Black,
                OutlineThickness = (4),
                OutlineColor = Color.White
            };

            _RedBar1 = new RectangleShape()
            {
                Position = new Vector2f((_window.Size.X /100 * 10), 30),
                Size = new Vector2f(0f, 20f),
                FillColor = Color.Red,
            };

            
            _inteface.Add(_BackHealthBar1);
            _inteface.Add(_BackHealthBar2);
            _inteface.Add(_RedBar1);
            
            _inteface.Add(_HealthBar1);
            _inteface.Add(_HealthBar2);
        }

        public RectangleShape HealthBar1
        {
            get { return _HealthBar1; }
            set { _HealthBar1 = value; }
        }
        public RectangleShape BackHealthBar1
        {
            get { return _BackHealthBar1; }
            set { _BackHealthBar1 = value; }
        }
        public RectangleShape RedBar1
        {
            get { return _RedBar1; }
            set { _RedBar1 = value; }
        }
        public RectangleShape HealthBar2
        {
            get { return _HealthBar2; }
            set { _HealthBar2 = value; }
        }
        public RectangleShape BackHealthBar2
        {
            get { return _BackHealthBar2; }
            set { _BackHealthBar2 = value; }
        }
    }
}
