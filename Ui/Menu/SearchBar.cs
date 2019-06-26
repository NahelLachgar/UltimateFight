using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Model;

namespace UI
{
    public class SearchBar : IAppState
    {
        Input _input = new Input();
        Vector2f MousePosition;
        RectangleShape _searchBar;
        Text _searchText;
        bool _inSearchBar = true;
        public IAppState _nextState { get; set; }


        internal SearchBar(RenderWindow window)
        {
            _searchBar = new RectangleShape()
            {
                FillColor = Color.White,
                Size = new Vector2f(800f, 30f),
                Position = new Vector2f(200f, 300f),
                OutlineThickness = 5,
                OutlineColor = Color.Black,
            };

            _searchText = new Text()
            {
                Style = Text.Styles.Regular,
                FillColor = Color.Blue,
                Font = new Font("../../../../Ui/Resources/Fonts/karate2/karate2.otf"),
                CharacterSize = 15,
                DisplayedString = "Entrez l'adresse IP de votre adversaire : ",
            };
            window.MouseButtonReleased += (sender, e) => ClickOnSearchBar(e);
            window.TextEntered += (sender, e) => WriteAdressIP(e);
            window.KeyPressed += (sender, e) => RemoveAdressIP(e);

            _nextState = this;
        }

        public IAppState Update(RenderWindow window)
        {
            _searchText.Position = new Vector2f(_searchBar.GetGlobalBounds().Left + ( _searchBar.GetGlobalBounds().Width / 2 ) - ( _searchText.GetGlobalBounds().Width / 2 ), _searchBar.GetGlobalBounds().Top + ( _searchBar.GetGlobalBounds().Height / 2 ) - ( _searchText.GetGlobalBounds().Height / 2 ));

            MousePosition = new Vector2f( Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y);
            //if ( Mouse.IsButtonPressed(Mouse.Button.Left) ) ClickOnSearchBar(window);
            //window.MouseButtonReleased += (sender, e) => ClickOnSearchBar(e);
            //if ( _inSearchBar == true ) WriteAdressIP(window);
            return _nextState;
        }

        public void Draw(RenderWindow Window)
        {
            Window.Draw(_searchBar);
            Window.Draw(_searchText);
        }

        private bool ClickOnSearchBar(MouseButtonEventArgs e)
        {
            
            if ( e.Button == Mouse.Button.Left && _searchBar.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) == true )
            {
                Console.WriteLine("true");
                if(_searchText.DisplayedString == "Entrez l'adresse IP de votre adversaire : ") _searchText.DisplayedString = "";

                return true;
            };

            if ( e.Button == Mouse.Button.Left && _searchBar.GetGlobalBounds().Contains(MousePosition.X, MousePosition.Y) == false )
            {
                //window.Close();
                Console.WriteLine("false");
                if ( _searchText.DisplayedString == string.Empty ) _searchText.DisplayedString = "Entrez l'adresse IP de votre adversaire : ";

                return false;
            }

            return _inSearchBar;
        }

        private void WriteAdressIP(TextEventArgs e)
        {
            if ( Regex.IsMatch(e.Unicode, "^[a-zA-Z0-9_]*$") && _inSearchBar == true)
            {

                Console.WriteLine("Lettre choissis : " + e.Unicode);

                if ( _inSearchBar == true )
                {
                    _searchText.DisplayedString += e.Unicode.ToString();
                }
            }
        }

        private void RemoveAdressIP(KeyEventArgs e)
        {
            if ( _inSearchBar == true && _searchText.DisplayedString.Length >= 1 )
            {

                if ( e.Code == Keyboard.Key.Backspace ) _searchText.DisplayedString = _searchText.DisplayedString.Remove(_searchText.DisplayedString.Length-1);
                if (e.Code == Keyboard.Key.Enter)
                {
                    // CODE DE NAHEL A INSERER ICI
                    Console.WriteLine("Appuis sur enter");
                    _nextState = null;
                }

            }
        }

    }
}
