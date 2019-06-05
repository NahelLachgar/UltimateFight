using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CharacterMenu
    {
        Sprite _imgBackGround;
        SelectCharacter _avatars = new SelectCharacter();
        Dictionary<int, CircleShape> _buttons;
        int _chooseOptionMenu = -1;


        public CharacterMenu()
        {
            _imgBackGround = this.ImgBackGround();
            _buttons = Buttons();
        }

        public void Update(MainMenu mainMenu, StartGame startGame, RenderWindow window)
        {
            if ( _chooseOptionMenu == -1 )
            {
               this.SelectOption(window);
                this.RedirectionMenu(mainMenu, startGame, window);
            }
        }

        public void Draw(MainMenu mainMenu, StartGame startGame, RenderWindow window)
        {
            this.Update(mainMenu, startGame, window);
            window.Draw(_imgBackGround);
            foreach ( CircleShape value in _buttons.Values ) window.Draw(value);
            foreach ( CircleShape value in _avatars.Avatars ) window.Draw(value);
            window.Draw(_avatars.ttt);
            window.Draw(_avatars.aaa);
        }


        private Sprite ImgBackGround()
        {
            Sprite img =  new Sprite(new Texture("../../../../img/Menu/Character_menu.jpg"));
            img.Scale = new Vector2f(( 1920f / Convert.ToSingle(img.Texture.Size.X) ), 1080f / Convert.ToSingle(img.Texture.Size.Y));
            img.Texture.Smooth = true;
            return img;
        }

        private Dictionary<int, CircleShape> Buttons()
        {
            Dictionary<int, CircleShape> buttons = new Dictionary<int, CircleShape>();

            //On the screen of selection character :
            // Add the button "Back to Menu" 
            buttons.Add(0, ShapeHelpers.RedCircleShape(78f, 6, new Vector2f(19f, 915f), Color.Cyan));

            // Add the button "Random Character"
            buttons.Add(1, ShapeHelpers.RedCircleShape(78f, 6, new Vector2f(312f, 915f), Color.Cyan));

            // Add the button "Next" to go to selection stage screen
            buttons.Add(2, ShapeHelpers.RedCircleShape(78f, 6, new Vector2f(1766f, 923f), Color.Cyan));

            return buttons;
        }


        private void SelectOption(RenderWindow window)
        {
            Vector2i mousePosition = Mouse.GetPosition(window);

            for ( byte i = 0; i <= 2; i++ )
            {
                if ( _buttons[i].GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y) )
                {
                    _buttons[i].OutlineThickness = 13f;
                    _buttons[i].OutlineColor = Color.Red;

                    if ( Mouse.IsButtonPressed(Mouse.Button.Left) )
                    {
                        _chooseOptionMenu = i;
                        Console.WriteLine("Option Character Menu : " + i + " choisis.");
                    }
                }
                else
                {
                    //_buttons[i].FillColor = Color.Transparent;
                    _buttons[i].OutlineThickness = 0f;
                }
            }
        }


        private void RedirectionMenu(MainMenu mainMenu, StartGame startGame, RenderWindow window)
        {
            switch ( _chooseOptionMenu )
            {
                case 0:  // Button "Back to menu"
                    this._chooseOptionMenu = -1;
                    startGame._chooseOptionMenu = -1;
                    mainMenu._chooseOptionMenu = -1;
                    break;

                case 1:  // Button "Random Character"
                    break;

                case 2:  // Button "Next"
                    break;

            }

        }




    }
}
