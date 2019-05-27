<<<<<<< HEAD
﻿//using SFML.Graphics;
//using SFML.System;
//using SFML.Window;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Model;
=======
﻿/*using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
>>>>>>> c024e1faa1940fad830c75c797bfc6323258e1b0

//namespace UI
//{
//    public class EndGameMenu
//    {
//        internal bool _isActived = false;
//        private Dictionary<string, Sprite> _menu = new Dictionary<string, Sprite>();
//        private Dictionary<string, Text> _textMenu = new Dictionary<string, Text>();
//        CreateMenu CreateMenu = new CreateMenu();

//        internal EndGameMenu()
//        {
//            _menu.Add("Back", CreateMenu.NewBackground());
//            _menu["Back"].Position = new Vector2f(1980f / 2f - Convert.ToSingle(_menu["Back"].TextureRect.Width) * 3f, 1080f / 2f - Convert.ToSingle(_menu["Back"].TextureRect.Height) * 2f);
//            _menu["Back"].Scale = new Vector2f(6f, 6f);
//            _menu["Back"].Position += new Vector2f(-20f, -20f);
//            _textMenu.Add("BackText", CreateMenu.NewTextMenu("Menu", new Vector2f(790f, 400f), 50));

//            _menu.Add("Rejouer", CreateMenu.NewButton("Green").Item1);
//            _menu["Rejouer"].Position = new Vector2f(1980f / 2f - Convert.ToSingle(_menu["Rejouer"].TextureRect.Width)*2f, 515f  );
//            _menu["Rejouer"].Scale = new Vector2f(4f, 3f);
//            _textMenu.Add("RejouerText", CreateMenu.NewTextMenu("Rejouer", new Vector2f(900f, 525f), 40));

//            _menu.Add("Changer", CreateMenu.NewButton("Yellow").Item1);
//            _menu["Changer"].Position = _menu["Rejouer"].Position + new Vector2f(0f, 120f);
//            _menu["Changer"].Scale = new Vector2f(4f, 3f);
//            _textMenu.Add("ChangerText", CreateMenu.NewTextMenu("Changer  de\npersonnage", new Vector2f(900f, 635f), 30));
//            _textMenu["ChangerText"].LineSpacing = 0.9f;

//            _menu.Add("Quitter", CreateMenu.NewButton("Orange").Item1);
//            _menu["Quitter"].Position = _menu["Rejouer"].Position + new Vector2f(0f, 240f);
//            _menu["Quitter"].Scale = new Vector2f(4f, 3f);
//            _textMenu.Add("QuitterText", CreateMenu.NewTextMenu("Quitter", new Vector2f(900f, 765f), 40));
//        }

//        public void Update(Game game, bool animationKO)
//        {
//            if ( (game._player1Win == 2 || game._player2Win == 2) && animationKO == true) _isActived = true;
//            else _isActived = false;

//            if ( _isActived == true )
//            {
//                _textMenu["BackText"].DisplayedString = string.Format("Joueur {0} wins", game.NameWinner());

//                // Button for replay : "Rejouer"
//                if (CreateMenu.MouseInButton(_menu["Rejouer"], game._window) ) _menu["Rejouer"] = CreateMenu.NewButton("Green").Item2;
//                else _menu["Rejouer"] = CreateMenu.NewButton("Green").Item1;
//                _menu["Rejouer"].Position = new Vector2f(1980f / 2f - Convert.ToSingle(_menu["Rejouer"].TextureRect.Width) * 2f, 515f);
//                _menu["Rejouer"].Scale = new Vector2f(4f, 3f);

//                // Button for change the players : "Chnager de personnage"
//                if ( CreateMenu.MouseInButton(_menu["Changer"], game._window) ) _menu["Changer"] = CreateMenu.NewButton("Yellow").Item2;
//                else _menu["Changer"] = CreateMenu.NewButton("Yellow").Item1;
//                _menu["Changer"].Position = _menu["Rejouer"].Position + new Vector2f(0f, 120f);
//                _menu["Changer"].Scale = new Vector2f(4f, 3f);

//                // Button for return at the menu : "Quitter"
//                // Button for change the players : "Chnager de personnage"
//                if ( CreateMenu.MouseInButton(_menu["Quitter"], game._window) ) _menu["Quitter"] = CreateMenu.NewButton("Orange").Item2;
//                else _menu["Quitter"] = CreateMenu.NewButton("Orange").Item1;
//                _menu["Quitter"].Position = _menu["Rejouer"].Position + new Vector2f(0f, 240f);
//                _menu["Quitter"].Scale = new Vector2f(4f, 3f);
//            }
//        }

//        public void Draw(RenderWindow window)
//        {
//            if (_isActived == true )
//            {
//                foreach ( Sprite T in _menu.Values ) window.Draw(T);
//                foreach ( Text T in _textMenu.Values ) window.Draw(T);
//            }
//        }

<<<<<<< HEAD
//        public Dictionary<string, Sprite> BackMenu => _menu;
//    }
//}
=======
        public Dictionary<string, Sprite> BackMenu => _menu;
    }
}
*/
>>>>>>> c024e1faa1940fad830c75c797bfc6323258e1b0
