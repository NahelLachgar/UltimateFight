using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Model;

namespace UI
{
    public class MainMenu : IAppState
    {
        RenderWindow _window;
        public Sprite _imgMenu;
        public List<Sprite> _listButton;
        public List<Sprite> _listSelectButton;
        public RectangleShape _blackBackMenu;
        public List<Text> _optionMenu;
        public int _chooseOptionMenu = -1;
        public IAppState _nextState { get; set; }
        public Sound _music1 = new Sound();


        public MainMenu(RenderWindow window)
        {
            _window = window;
            _imgMenu = this.BackGround();

            //_listButton = this.CreateButton();
            //_listSelectButton = this.CreateSelectButton();
            _blackBackMenu = new RectangleShape()
            {
                FillColor = new Color(0, 0, 0, 120),
                Size = new Vector2f(500f, 1080f),
                Position = new Vector2f(0f, 0f),
            };

            _optionMenu = OptionMenu();
            _nextState = this;
            _music1._currentMusic = _music1._musicMenu;
            _music1._currentMusic.Loop = true;
            _music1._currentMusic.Play();
        }

        public IAppState Update(RenderWindow window/*, Menus menus*/)
        {
            if ( _chooseOptionMenu == -1 ) SelectOption(window);
            return _nextState;
        }

        public void Draw(RenderWindow window)
        {

            window.Draw(_imgMenu);
            if ( _chooseOptionMenu > -1 )
            {
                _blackBackMenu.FillColor = new Color(0, 0, 0, 230);
                foreach ( Text value in _optionMenu ) window.Draw(value);
                window.Draw(_blackBackMenu);
            }
            else
            {
                _blackBackMenu.FillColor = new Color(0, 0, 0, 150);
                window.Draw(_blackBackMenu);
                foreach ( Text value in _optionMenu ) window.Draw(value);
            }
        }

        private void SelectOption(RenderWindow window)
        {
            Vector2i mousePosition = Mouse.GetPosition(window);


            for ( byte i = 0; i <= 2; i++ )
            {
                if ( _optionMenu[i].GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y) )
                {
                    _optionMenu[i].FillColor = Color.Red;
                    _optionMenu[i].OutlineThickness = 6f;
                    _optionMenu[i].OutlineColor = Color.White;

                    if ( Mouse.IsButtonPressed(Mouse.Button.Left) )
                    {
                        _chooseOptionMenu = i;
                    }
                }
                else if ( i != _chooseOptionMenu )
                {
                    _optionMenu[i].FillColor = Color.White;
                    _optionMenu[i].OutlineThickness = 0f;
                }

            }
        }

        private Sprite BackGround()
        {
            _imgMenu = new Sprite()
            {
                Texture = new Texture("../../../../Ui/Resources/Menu/image_menu1.jpg"),
                TextureRect = new IntRect(0, 0, Convert.ToInt32(_window.Size.X), Convert.ToInt32(_window.Size.Y)),
            };
            _imgMenu.Scale = new Vector2f(( 1920f / Convert.ToSingle(_imgMenu.Texture.Size.X) ), 1080f / Convert.ToSingle(_imgMenu.Texture.Size.Y));
            return _imgMenu;
        }

        private List<Sprite> CreateButton()
        {
            CreateMenu createMenu = new CreateMenu();
            List<Sprite> listButton = new List<Sprite>();

            listButton.Add(createMenu.NewButton("White").Item1);
            listButton[0].Scale = new Vector2f(3f, 2f);
            listButton[0].Position = new Vector2f(100f, 300f);

            return listButton;
        }

        private List<Sprite> CreateSelectButton()
        {
            CreateMenu createMenu = new CreateMenu();
            List<Sprite> listSelectButton = new List<Sprite>();

            listSelectButton.Add(createMenu.NewButton("Orange").Item2);
            return listSelectButton;
        }

        private List<Text> OptionMenu()
        {
            List<Text> OptionMenu = new List<Text>();
            Font font = new Font("../../../../Ui/Resources/Fonts/GrizzlyAttack/GrizzlyAttack.ttf");

            OptionMenu.Add(new Text("Lancer une partie", font, 50));
            OptionMenu[0].Position = new Vector2f(( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( OptionMenu[0].GetGlobalBounds().Width / 2f ), 400f);
            OptionMenu[0].Style = Text.Styles.Bold;

            //OptionMenu.Add(new Text("Option", font, 50));
            //OptionMenu[1].Position = new Vector2f(( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( OptionMenu[1].GetGlobalBounds().Width / 2f ), 485f);
            //OptionMenu[1].Style = Text.Styles.Bold;

            //OptionMenu.Add(new Text("Statistiques", font, 50));
            //OptionMenu[2].Position = new Vector2f(( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( OptionMenu[2].GetGlobalBounds().Width / 2f ), 570f);
            //OptionMenu[2].Style = Text.Styles.Bold;

            //OptionMenu.Add(new Text("Coup Speciaux", font, 50));
            //OptionMenu[3].Position = new Vector2f(( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( OptionMenu[3].GetGlobalBounds().Width / 2f ), 655f);
            //OptionMenu[3].Style = Text.Styles.Bold;

            OptionMenu.Add(new Text("Credit", font, 50));
            OptionMenu[1].Position = new Vector2f(( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( OptionMenu[1].GetGlobalBounds().Width / 2f ), 485f /*740f*/);
            OptionMenu[1].Style = Text.Styles.Bold;

            OptionMenu.Add(new Text("Quitter", font, 50));
            OptionMenu[2].Position = new Vector2f(( _blackBackMenu.GetGlobalBounds().Width / 2f ) - ( OptionMenu[2].GetGlobalBounds().Width / 2f ), 570f /*825f*/);
            OptionMenu[2].Style = Text.Styles.Bold;

            return OptionMenu;
        }





    }
}
