using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace UI
{
    public class OnlineMenu : IAppState
    {
        private Sprite _imgBackGround;
        private Sprite _imgButtons;
        private RectangleShape _backLobby;
        private Text _textButtonLobby;
        private Text _textTitleLobby;
        internal int _chooseOptionMenu = -1;
        private Sprite _returnButton;
        private Text _textReturnButton;
        internal SearchBar _searchBar ;
        public IAppState _nextState { get; set; }

        public OnlineMenu(RenderWindow window)
        {
            _searchBar = new SearchBar(window);
            _imgBackGround = this.CreateImgBackGround();
            _imgButtons = this.CreateImgButtons();
            _textButtonLobby = this.CreateTextButtonLobby();

            _backLobby = new RectangleShape
            {
                OutlineThickness = 8,
                OutlineColor = Color.Black,
                Size = new Vector2f(1200f, 780f),
                Position = new Vector2f(30, 170f),
                FillColor = new Color(0, 0, 0, 110),
            };

            _textTitleLobby = this.CreateTextTitleLobby();

            _returnButton = new Sprite(new Texture("../../../../img/Menu/return_button.png"))
            {
                Scale = new Vector2f(0.35f, 0.25f),
                Position = new Vector2f(55f, 890f)
            };

            _textReturnButton = new Text()
            {
                Style = Text.Styles.Regular,
                Font = new Font("../../../../Ui/Resources/Fonts/Cocogoose/CocogooseBold.ttf"),
                CharacterSize = 30,
                DisplayedString = "Retour",
                Position = new Vector2f(95f, 900f),
            };

            _nextState = this;
        }



        public IAppState Update(/*MainMenu mainMenu, StartGame startGame,*/ RenderWindow window)
        {
            if(_imgButtons.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y ) )
            {
                _imgButtons.Color = new Color(_imgButtons.Color.R, _imgButtons.Color.G, _imgButtons.Color.B, 130);
                _textButtonLobby.FillColor = new Color(_textButtonLobby.FillColor.R, _textButtonLobby.FillColor.G, _textButtonLobby.FillColor.B, 120);


                if ( Mouse.IsButtonPressed(Mouse.Button.Left) )
                {
                    _chooseOptionMenu = 0;
                }
            }
            else
            {
                _imgButtons.Color = new Color(_imgButtons.Color.R, _imgButtons.Color.G, _imgButtons.Color.B, 255);
                _textButtonLobby.FillColor = new Color(_textButtonLobby.FillColor.R, _textButtonLobby.FillColor.G, _textButtonLobby.FillColor.B, 255);

            }

            if ( _chooseOptionMenu == 0 ) this.ActionButtonLobby();

            if ( _returnButton.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y) && Mouse.IsButtonPressed(Mouse.Button.Left) ) _chooseOptionMenu = 1;

            if(_chooseOptionMenu == 1)
            {
                //startGame._chooseOptionMenu = -1;
                //mainMenu._chooseOptionMenu = -1;
                this._chooseOptionMenu = -1;
            }

            _searchBar.Update(window);
            return _nextState;
        }

        private void ReturnMenu(MainMenu mainMenu, StartGame startGame)
        {

        }


        public void Draw(/*MainMenu mainMenu, StartGame startGame, */RenderWindow window)
        {
            this.Update(/*mainMenu, startGame, */window);
            window.Draw(_imgBackGround);
            window.Draw(_backLobby);
            window.Draw(_imgButtons);
            window.Draw(_textButtonLobby);
            window.Draw(_textTitleLobby);
            window.Draw(_returnButton);
            window.Draw(_textReturnButton);
            _searchBar.Draw(window);
        }

        private void ActionButtonLobby()
        {
            throw new NotImplementedException();
        }

        private Sprite CreateImgBackGround()
        {
            Sprite img =  new Sprite(new Texture("../../../../img/Menu/OnlineMenu.png"));
            img.Scale = new Vector2f(( 1920f / Convert.ToSingle(img.Texture.Size.X) ), 1080f / Convert.ToSingle(img.Texture.Size.Y));
            img.Texture.Smooth = true;
            return img;
        }


        private Sprite CreateImgButtons()
        {
            Sprite img =  new Sprite(new Texture("../../../../img/Menu/OnlineMenuButtons.png"), new IntRect(84, 700, 315, 130 ) );
            img.Scale = new Vector2f(1f, 0.9f);
            img.Texture.Smooth = true;
            img.Position = new Vector2f(1250f, 870f);
            return img;
        }


        private Text CreateTextButtonLobby()
        {
            Text text = new Text()
            {
                Style = Text.Styles.Regular,
                Font = new Font("../../../../Ui/Resources/Fonts/Cocogoose/CocogooseBold.ttf"),
                CharacterSize = 30,
                DisplayedString = "Héberger\nune partie",
                Position = new Vector2f(1320f, 895f),
            };

            return text;
        }

        private Text CreateTextTitleLobby()
        {
            Text text = new Text()
            {
                Style = Text.Styles.Regular,
                Font = new Font("../../../../Ui/Resources/Fonts/Cocogoose/CocogooseBold.ttf"),
                CharacterSize = 30,
                DisplayedString = "Lobby en cours . . .",
            };
            text.Position = new Vector2f(_backLobby.Position.X + (_backLobby.GetLocalBounds().Width/2) -  (text.GetLocalBounds().Width / 2f ), _backLobby.Position.Y + 30f );

            return text;
        }


    }
}
