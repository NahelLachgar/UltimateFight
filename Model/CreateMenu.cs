using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using UI;

namespace Model
{
    internal class CreateMenu
    {
        private Texture _img = new Texture("../../../../img/Menu/menu.png");


        internal CreateMenu()
        {
        }

        internal (Sprite, Sprite) NewButton(string color)
        {

            IntRect Color = this.ChooseButtonColor(color);
            Sprite button = new Sprite(_img, Color);

            Color = this.SelectButtonColor(color);
            Sprite selectButton = new Sprite(_img, Color);

            return (button, selectButton);
        }


        internal Text NewTextMenu(string Text, Vector2f PositionText, uint SizeFont )
        {
            Text text = new Text(Text, new Font("../../../../Ui/Resources/Fonts/space_ranger/spaceranger.ttf"), SizeFont);
            text.Position = PositionText;
            text.FillColor = Color.Black;
            return text;
        }

        private IntRect ChooseButtonColor(string color)
        {
            IntRect colorSize;
            switch(color)
            {
                case "Green":
                    colorSize = new IntRect(new Vector2i(324, 68), new Vector2i(95, 25));
                    return colorSize;
                    break;
                case "Yellow":
                    colorSize = new IntRect(new Vector2i(218, 40), new Vector2i(95, 25));
                    return colorSize;
                    break;
                case "Blue":
                    colorSize = new IntRect(new Vector2i(219, 130), new Vector2i(95, 25));
                    return colorSize;
                    break;
                case "White":
                    colorSize = new IntRect(new Vector2i(219, 10), new Vector2i(95, 25));
                    return colorSize;
                    break;
                case "Orange":
                    colorSize = new IntRect(new Vector2i(219, 100), new Vector2i(95, 25));
                    return colorSize;
                    break;

                default:
                    //Button green by default
                    colorSize = new IntRect(new Vector2i(324, 68), new Vector2i(95, 25));
                    return colorSize;
                    break;
            }
        }

        private IntRect SelectButtonColor(string color)
        {
            IntRect colorSize;
            switch ( color )
            {
                case "Green":
                    colorSize = new IntRect(new Vector2i(9, 69), new Vector2i(94, 21));
                    return colorSize;
                    break;
                case "Yellow":
                    colorSize = new IntRect(new Vector2i(9, 39), new Vector2i(94, 21));
                    return colorSize;
                    break;
                case "Blue":
                    colorSize = new IntRect(new Vector2i(9, 129), new Vector2i(94, 21));
                    return colorSize;
                    break;
                case "White":
                    colorSize = new IntRect(new Vector2i(9, 9), new Vector2i(94, 21));
                    return colorSize;
                    break;
                case "Orange":
                    colorSize = new IntRect(new Vector2i(9, 99), new Vector2i(94, 21));
                    return colorSize;
                    break;

                default:
                    //Button green by default
                    colorSize = new IntRect(new Vector2i(324, 68), new Vector2i(94, 21));
                    return colorSize;
                    break;
            }
        }


        internal Sprite NewBackground()
        {
            Sprite backMenu = new Sprite(_img, new IntRect(new Vector2i(640, 195),  new Vector2i(93, 89) ));
            return backMenu;
        }

        internal bool MouseInButton(Sprite Button, RenderWindow window)
        {
            return Button.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y);
        }


    }
}
