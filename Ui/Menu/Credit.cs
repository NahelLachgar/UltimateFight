using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace UI
{
    public class Credit 
    {

        public RectangleShape _background;
        internal RectangleShape _whiteBackMenu;
        internal RectangleShape _blackBackMenu;
        internal RectangleShape _intech;

        List<Text> _options;
        internal int _chooseOptionMenu = -1;

        public Credit(RenderWindow window)
        {
            _intech = new RectangleShape()
            {
                Texture = new Texture("../../../../img/Menu/intech.png"),
                Position = new Vector2f(0f, 0f),
                Size = new Vector2f(300f, 200f),
            };



            _background = new RectangleShape()
            {
                Position = new Vector2f(0f, 0f),
                Size = new Vector2f(window.Size.X, window.Size.Y),

            };

            _whiteBackMenu = new RectangleShape()
            {
                FillColor = new Color(255, 255, 255, 255),
                Size = new Vector2f(10f, 1080f),
                Position = new Vector2f(500f, 0f),
            };

            _blackBackMenu = new RectangleShape()
            {
                FillColor = new Color(0, 0, 0, 220),
                Size = new Vector2f(1200f, 1080f),
                Position = new Vector2f(510f, 0f),
            };

            _options = this.Option();

        }


        public void Draw(RenderWindow window, MainMenu mainMenu)
        {
            this.Update(window);
            window.Draw(_whiteBackMenu);
            window.Draw(_blackBackMenu);
            _intech.Position = new Vector2f(500F + ( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( _intech.GetGlobalBounds().Width / 2f ), 50f);
            window.Draw(_intech);
            foreach ( Text value in _options ) window.Draw(value);
            RedirectionMenu(window, mainMenu, this);
        }

        public void Update(RenderWindow window)
        {

            if ( _chooseOptionMenu == -1 ) SelectOption(window);
        }



        private List<Text> Option()
        {
            List<Text> Option = new List<Text>();

            Font font = new Font("../../../../Ui/Resources/Fonts/GrizzlyAttack/GrizzlyAttack.ttf");

            Option.Add(new Text("Projet etudiant realise par :", font, 50));
            Option[0].Position = new Vector2f(390F + ( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( Option[0].GetGlobalBounds().Width / 2f ), 300f);
            Option[0].Style = Text.Styles.Bold;
            Option[0].FillColor = Color.Red;
            Option[0].OutlineThickness = 4;
            Option[0].OutlineColor = Color.White;
            Option[0].Font = new Font("../../../../Ui/Resources/Fonts/Cocogoose/CocogooseBold.ttf");


            Option.Add(new Text("Sami ANKI \nKevin BARAO DA SILVA \nNahel LACHGAR", font, 50));
            Option[1].Position = new Vector2f(500F + ( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( Option[1].GetGlobalBounds().Width / 2f ), 385f);
            Option[1].Style = Text.Styles.Bold;
            Option[1].LineSpacing = 0.75f;
            Option[1].FillColor = Color.White;
            Option[1].OutlineThickness = 4;
            Option[1].OutlineColor = Color.Red;
            Option[1].Font = new Font("../../../../Ui/Resources/Fonts/GrizzlyAttack/GrizzlyAttack.ttf");

            Option.Add(new Text("Remerciement", font, 50));
            Option[2].Position = new Vector2f(270F + ( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( Option[2].GetGlobalBounds().Width / 2f ), 650f);
            Option[2].Style = Text.Styles.Bold;
            Option[2].FillColor = Color.Red;
            Option[2].OutlineThickness = 4;
            Option[2].OutlineColor = Color.White;
            Option[2].Font = new Font("../../../../Ui/Resources/Fonts/Cocogoose/CocogooseBold.ttf");


            Option.Add(new Text("Antoine RAQUILLET \nOlivier SPINELLI", font, 50));
            Option[3].Position = new Vector2f(450F + ( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( Option[3].GetGlobalBounds().Width / 2f ), 735f);
            Option[3].Style = Text.Styles.Bold;
            Option[3].LineSpacing = 0.75f;
            Option[3].FillColor = Color.White;
            Option[3].OutlineThickness = 4;
            Option[3].OutlineColor = Color.Red;
            Option[3].Font = new Font("../../../../Ui/Resources/Fonts/GrizzlyAttack/GrizzlyAttack.ttf");


            Option.Add(new Text("\n\n\n\nRetour", font, 50));
            Option[4].Position = new Vector2f(450F + ( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( Option[4].GetGlobalBounds().Width / 2f ), 685f);
            Option[4].Style = Text.Styles.Bold;
            Option[4].LineSpacing = 0.75f;
            Option[4].FillColor = Color.White;
            Option[4].OutlineThickness = 4;
            Option[4].OutlineColor = Color.Red;
            Option[4].Font = new Font("../../../../Ui/Resources/Fonts/GrizzlyAttack/GrizzlyAttack.ttf");

            return Option;
        }


        private void SelectOption(RenderWindow window)
        {
            Vector2i mousePosition = Mouse.GetPosition(window);


            for ( byte i = 4; i <= 4; i++ )
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



        private void RedirectionMenu(RenderWindow window, MainMenu mainMenu, Credit startGame)
        {
            switch ( _chooseOptionMenu )
            {
                case 0: 

                    break;

                case 1: 

                    break;

                case 2:  

                    break;

                case 3:  

                    break;

                case 4:  // Option : "Retour" 
                    mainMenu._chooseOptionMenu = -1;
                    this._chooseOptionMenu = -1;
                    break;
            }

        }
    }
}
