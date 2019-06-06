using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    internal class OnlineMenu
    {
        private Sprite _imgBackGround;
        private Sprite _imgButtons;
        private RectangleShape _backLobby;
        private Text _textButtonLobby;
        private Text _textTitleLobby;

        internal OnlineMenu()
        {
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

        }


        internal void Update()
        {

        }

        internal void Draw(MainMenu mainMenu, StartGame startGame, RenderWindow window)
        {
            window.Draw(_imgBackGround);
            window.Draw(_backLobby);
            window.Draw(_imgButtons);
            window.Draw(_textButtonLobby);
            window.Draw(_textTitleLobby);
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
