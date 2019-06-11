using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class StartGame
    {
        List<Text> _options;
        internal RectangleShape _whiteBackMenu;
        internal RectangleShape _blackBackMenu;
        internal int _chooseOptionMenu = -1;
        public CharacterMenu _characterMenu = new CharacterMenu();
        public OnlineMenu _onlineMenu = new OnlineMenu();

        public StartGame()
        {
            _whiteBackMenu = new RectangleShape()
            {
                FillColor = new Color(255, 255, 255, 255),
                Size = new Vector2f(10f, 1080f),
                Position = new Vector2f(500f, 0f),
            };

            _blackBackMenu = new RectangleShape()
            {
                FillColor = new Color(0, 0, 0, 120),
                Size = new Vector2f(500f, 1080f),
                Position = new Vector2f(510f, 0f),
            };

            _options = this.Option();

        }

        private void Update(RenderWindow window)
        {
            if (_chooseOptionMenu == -1) SelectOption(window);
        }

        public void Draw(RenderWindow window, MainMenu mainMenu)
        {
            this.Update(window);
            window.Draw(_whiteBackMenu);
            window.Draw(_blackBackMenu);
            foreach ( Text value in _options ) window.Draw(value);
            RedirectionMenu(mainMenu, this, window);
        }

        private List<Text> Option()
        {
            List<Text> Option = new List<Text>();

            Font font = new Font("../../../../Ui/Resources/Fonts/GrizzlyAttack/GrizzlyAttack.ttf");

            Option.Add(new Text("Player Vs. I.A", font, 50));
            Option[0].Position = new Vector2f(500F + ( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( Option[0].GetGlobalBounds().Width / 2f ), 400f);
            Option[0].Style = Text.Styles.Bold;

            Option.Add(new Text("Player Vs. Player", font, 50));
            Option[1].Position = new Vector2f(500F + ( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( Option[1].GetGlobalBounds().Width / 2f ), 485f);
            Option[1].Style = Text.Styles.Bold;

            Option.Add(new Text("Mode Online", font, 50));
            Option[2].Position = new Vector2f(500F + ( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( Option[2].GetGlobalBounds().Width / 2f ), 570f);
            Option[2].Style = Text.Styles.Bold;

            Option.Add(new Text("Retour", font, 50));
            Option[3].Position = new Vector2f(500F + ( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( Option[3].GetGlobalBounds().Width / 2f ), 655f);
            Option[3].Style = Text.Styles.Bold;

            return Option;
        }

        private void SelectOption(RenderWindow window)
        {
            Vector2i mousePosition = Mouse.GetPosition(window);


            for ( byte i = 0; i <= 3; i++ )
            {
                if ( _options[i].GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y) )
                {
                    _options[i].FillColor = Color.Red;
                    _options[i].OutlineThickness = 6f;
                    _options[i].OutlineColor = Color.White;

                    if ( Mouse.IsButtonPressed(Mouse.Button.Left) )
                    {
                        _chooseOptionMenu = i;
                    }
                }
                else
                {
                    _options[i].FillColor = Color.White;
                    _options[i].OutlineThickness = 0f;
                }

            }
        }

        private void RedirectionMenu(MainMenu mainMenu, StartGame startGame, RenderWindow window)
        {
            switch ( _chooseOptionMenu )
            {
                case 0:  // Mode Player versus A.I
                    _characterMenu.Draw(mainMenu, this, window);
                    break;

                case 1:  // Mode Player Versus Player
                    _characterMenu.Draw(mainMenu, this, window);
                    break;

                case 2:  // Mode online
                    _onlineMenu.Draw(mainMenu, this, window);
                    break;

                case 3:  // Option : "Retour" 
                    mainMenu._chooseOptionMenu = -1;
                    this._chooseOptionMenu = -1;
                    break;

            }

        }

    }
}
