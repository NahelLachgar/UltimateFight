using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace UI
{
    public class Map : IAppState
    {
        public IAppState _nextState { get; set; }
        CharacterMenu _characterMenu;
        RectangleShape _background;
        List<RectangleShape> _mapImage;
        Vector2f MousePosition;




        public Map(RenderWindow window, CharacterMenu character)
        {
            _nextState = this;
            _characterMenu = character;
            _mapImage = CreateListMap();

            _background = new RectangleShape()
            {
                Position = new Vector2f(0f, 0f),
                Size = new Vector2f(window.Size.X, window.Size.Y),
                FillColor = Color.Black,
            };

            window.MouseButtonReleased += (sender, e) => ClickSelectMap(e, window);
        }


        public void Draw(RenderWindow window)
        {
            window.Draw(_background);
            foreach ( RectangleShape value in _mapImage ) window.Draw(value);

        }

        public IAppState Update(RenderWindow window)
        {
            MousePosition = new Vector2f(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y);


            return _nextState;
        }



        private void ClickSelectMap(MouseButtonEventArgs e, RenderWindow window)
        {
            int x = 0;
            foreach ( RectangleShape value in _mapImage )
            {
                x++;
                if ( e.Button == Mouse.Button.Left && value.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) == true )
                {
                    this._nextState = new GameUI( new Game(new Time(), Factory.NewCharacter(_characterMenu._avatars._characterPlayer1.ToLower()), Factory.NewCharacter(_characterMenu._avatars._characterPlayer2.ToLower()), Factory.NewStage("stage"+x), window) );
                    //Console.WriteLine("Map numéro : " + x);
                };
            }

        }



        private List<RectangleShape> CreateListMap()
        {
            List<RectangleShape> Map = new List<RectangleShape>();
            RectangleShape stage1 = new RectangleShape()
            {
                Position = new Vector2f(200f, 880f),
                Size = new Vector2f(300f, 150f),
                Texture = new Texture("../../../../img/stages/stage1.jpg"),
            };
            Map.Add(stage1);

            RectangleShape stage2 = new RectangleShape()
            {
                Position = new Vector2f(600f, 880f),
                Size = new Vector2f(300f, 150f),
                Texture = new Texture("../../../../img/stages/stage2.jpg"),
            };
            Map.Add(stage2);

            RectangleShape stage3 = new RectangleShape()
            {
                Position = new Vector2f(1000f, 880f),
                Size = new Vector2f(300f, 150f),
                Texture = new Texture("../../../../img/stages/stage3.png"),
            };
            Map.Add(stage3);

            RectangleShape stage4 = new RectangleShape()
            {
                Position = new Vector2f(200f, 680f),
                Size = new Vector2f(300f, 150f),
                Texture = new Texture("../../../../img/stages/stage4.png"),
            };
            Map.Add(stage4);

            RectangleShape stage5 = new RectangleShape()
            {
                Position = new Vector2f(600f, 680f),
                Size = new Vector2f(300f, 150f),
                Texture = new Texture("../../../../img/stages/stage5.png"),
            };
            Map.Add(stage5);

            RectangleShape stage6 = new RectangleShape()
            {
                Position = new Vector2f(1000f, 680f),
                Size = new Vector2f(300f, 150f),
                Texture = new Texture("../../../../img/stages/stage6.jpg"),
            };
            Map.Add(stage6);

            return Map;
        }

    }
}
