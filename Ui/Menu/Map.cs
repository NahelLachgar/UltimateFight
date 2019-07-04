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
        List<CircleShape> _selectMap;
        Vector2f MousePosition;
        ConvexShape _Map1 = new ConvexShape();
        ConvexShape _Map2 = new ConvexShape();
        ConvexShape _Map3 = new ConvexShape();
        ConvexShape _Map4 = new ConvexShape();
        ConvexShape _Map5 = new ConvexShape();
        ConvexShape _Map6 = new ConvexShape();
        RectangleShape _mapDisplay;





        public Map(RenderWindow window, CharacterMenu character)
        {
            _nextState = this;
            _characterMenu = character;
            _mapImage = CreateListMap();
            _selectMap = CreateSelectMao();

            _background = new RectangleShape()
            {
                Position = new Vector2f(0f, 0f),
                Size = new Vector2f(window.Size.X, window.Size.Y),
                Texture = new Texture("../../../../img/Menu/SelectMap.jpg"),
            };

            _mapDisplay = new RectangleShape()
            {
                Size = new Vector2f(1880f, 517f),
                Position = new Vector2f(20f, 175f),
                Texture = new Texture("../../../../img/stages/stage1.jpg"),
            };

            _Map1.SetPointCount(4);
            _Map1.SetPoint(0, new Vector2f(0f, 0f));
            _Map1.SetPoint(1, new Vector2f(72f, 0f));
            _Map1.SetPoint(2, new Vector2f(189f, 187f));
            _Map1.SetPoint(3, new Vector2f(115f, 187f));
            _Map1.Texture = new Texture("../../../../img/stages/stage1.jpg");
            _Map1.Texture.Smooth = true;
            _Map1.OutlineColor = Color.White;
            _Map1.OutlineThickness = 2;
            _Map1.Position = new Vector2f(594f, 744f);

            _Map2.SetPointCount(4);
            _Map2.SetPoint(0, new Vector2f(0f, 0f));
            _Map2.SetPoint(1, new Vector2f(72f, 0f));
            _Map2.SetPoint(2, new Vector2f(189f, 187f));
            _Map2.SetPoint(3, new Vector2f(115f, 187f));
            _Map2.Texture = new Texture("../../../../img/stages/stage2.jpg");
            _Map2.Texture.Smooth = true;
            _Map2.OutlineColor = Color.White;
            _Map2.OutlineThickness = 2;
            _Map2.Position = new Vector2f(676f, 744f);

            _Map3.SetPointCount(4);
            _Map3.SetPoint(0, new Vector2f(0f, 0f));
            _Map3.SetPoint(1, new Vector2f(72f, 0f));
            _Map3.SetPoint(2, new Vector2f(189f, 187f));
            _Map3.SetPoint(3, new Vector2f(115f, 187f));
            _Map3.Texture = new Texture("../../../../img/stages/stage3.png");
            _Map3.Texture.Smooth = true;
            _Map3.OutlineColor = Color.White;
            _Map3.OutlineThickness = 2;
            _Map3.Position = new Vector2f(758f, 744f);

            _Map4.SetPointCount(4);
            _Map4.SetPoint(0, new Vector2f(0f, 0f));
            _Map4.SetPoint(1, new Vector2f(72f, 0f));
            _Map4.SetPoint(2, new Vector2f(189f, 187f));
            _Map4.SetPoint(3, new Vector2f(115f, 187f));
            _Map4.Texture = new Texture("../../../../img/stages/stage4.png");
            _Map4.Texture.Smooth = true;
            _Map4.OutlineColor = Color.White;
            _Map4.OutlineThickness = 2;
            _Map4.Position = new Vector2f(1162f, 744f);
            _Map4.Scale = new Vector2f(-1f, 1f);

            _Map5.SetPointCount(4);
            _Map5.SetPoint(0, new Vector2f(0f, 0f));
            _Map5.SetPoint(1, new Vector2f(72f, 0f));
            _Map5.SetPoint(2, new Vector2f(189f, 187f));
            _Map5.SetPoint(3, new Vector2f(115f, 187f));
            _Map5.Texture = new Texture("../../../../img/stages/stage5.png");
            _Map5.Texture.Smooth = true;
            _Map5.OutlineColor = Color.White;
            _Map5.OutlineThickness = 2;
            _Map5.Position = new Vector2f(1244f, 744f);
            _Map5.Scale = new Vector2f(-1f, 1f);

            _Map6.SetPointCount(4);
            _Map6.SetPoint(0, new Vector2f(0f, 0f));
            _Map6.SetPoint(1, new Vector2f(72f, 0f));
            _Map6.SetPoint(2, new Vector2f(189f, 187f));
            _Map6.SetPoint(3, new Vector2f(115f, 187f));
            _Map6.Texture = new Texture("../../../../img/stages/stage6.jpg");
            _Map6.Texture.Smooth = true;
            _Map6.OutlineColor = Color.White;
            _Map6.OutlineThickness = 2;
            _Map6.Position = new Vector2f(1326f, 744f);
            _Map6.Scale = new Vector2f(-1f, 1f);

            window.MouseButtonReleased += (sender, e) => ClickSelectMap(e, window);
        }

        private  List<CircleShape> CreateSelectMao()
        {
            List<CircleShape> list = new List<CircleShape>();

            CircleShape t = new CircleShape()
            {

            };

            return list;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(_background);
            window.Draw(_Map1);
            window.Draw(_Map2);
            window.Draw(_Map3);
            window.Draw(_Map4);
            window.Draw(_Map5);
            window.Draw(_Map6);
            window.Draw(_mapDisplay);
            //foreach ( RectangleShape value in _mapImage ) window.Draw(value);

        }

        public IAppState Update(RenderWindow window)
        {
            MousePosition = new Vector2f(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y);
            DrawMapMenu();

            return _nextState;
        }

        private void DrawMapMenu()
        {
            if ( _Map1.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) ) _mapDisplay.Texture = new Texture("../../../../img/stages/stage1.jpg");
            if ( _Map2.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) ) _mapDisplay.Texture = new Texture("../../../../img/stages/stage2.jpg");
            if ( _Map3.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) ) _mapDisplay.Texture = new Texture("../../../../img/stages/stage3.png");
            if ( _Map4.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) ) _mapDisplay.Texture = new Texture("../../../../img/stages/stage4.png");
            if ( _Map5.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) ) _mapDisplay.Texture = new Texture("../../../../img/stages/stage5.png");
            if ( _Map6.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) ) _mapDisplay.Texture = new Texture("../../../../img/stages/stage6.jpg");

        }

        private void ClickSelectMap(MouseButtonEventArgs e, RenderWindow window)
        {

            if ( e.Button == Mouse.Button.Left && _Map1.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) == true )
            { // Map 1
                this._nextState = new GameUI(new Game(new Time(), Factory.NewCharacter(_characterMenu._avatars._characterPlayer1.ToLower()), Factory.NewCharacter(_characterMenu._avatars._characterPlayer2.ToLower()), Factory.NewStage("stage1"), window));
            };
            if ( e.Button == Mouse.Button.Left && _Map2.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) == true )
            { // Map 2
                this._nextState = new GameUI(new Game(new Time(), Factory.NewCharacter(_characterMenu._avatars._characterPlayer1.ToLower()), Factory.NewCharacter(_characterMenu._avatars._characterPlayer2.ToLower()), Factory.NewStage("stage2"), window));
            };
            if ( e.Button == Mouse.Button.Left && _Map3.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) == true )
            { // Map 3
                this._nextState = new GameUI(new Game(new Time(), Factory.NewCharacter(_characterMenu._avatars._characterPlayer1.ToLower()), Factory.NewCharacter(_characterMenu._avatars._characterPlayer2.ToLower()), Factory.NewStage("stage3"), window));
            };
            if ( e.Button == Mouse.Button.Left && _Map4.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) == true )
            { // Map 4
                this._nextState = new GameUI(new Game(new Time(), Factory.NewCharacter(_characterMenu._avatars._characterPlayer1.ToLower()), Factory.NewCharacter(_characterMenu._avatars._characterPlayer2.ToLower()), Factory.NewStage("stage4"), window));
            };
            if ( e.Button == Mouse.Button.Left && _Map5.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) == true )
            { // Map 5
                this._nextState = new GameUI(new Game(new Time(), Factory.NewCharacter(_characterMenu._avatars._characterPlayer1.ToLower()), Factory.NewCharacter(_characterMenu._avatars._characterPlayer2.ToLower()), Factory.NewStage("stage5"), window));
            };
            if ( e.Button == Mouse.Button.Left && _Map6.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) == true )
            { // Map 6
                this._nextState = new GameUI(new Game(new Time(), Factory.NewCharacter(_characterMenu._avatars._characterPlayer1.ToLower()), Factory.NewCharacter(_characterMenu._avatars._characterPlayer2.ToLower()), Factory.NewStage("stage6"), window));
            };


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
