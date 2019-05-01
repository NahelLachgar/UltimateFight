using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFight
{
    internal class K_O
    {
        private List<Sprite> animation_ko = new List<Sprite>();
        private Sprite _KO = new Sprite();
        private float _timerKO = 0;
        private int _iKO = 0;
        internal bool _finish = true; 



        internal K_O(RenderWindow window)
        {
            float _windowX = window.Size.X;
            float _windowY = window.Size.Y;

            // Sprite for draw the animation of "K.O" when a player dies
            for ( int i = 1; i <= 38; i++ )
            {
                Texture texture = new Texture("../../../../pi.Ui/Resources/Img/k_o/" + i + ".png");
                texture.Smooth = true;
                Sprite _ko = new Sprite(texture);
                _ko.Scale = new Vector2f(( _windowX * 0.0016f ), ( _windowY * 0.0016f ));
                _ko.Position = new Vector2f(( _windowX / 2f ) - ( _ko.Texture.Size.X / 2f * _ko.Scale.X ), ( _windowY / 2f ) - ( _ko.Texture.Size.Y / 2f * _ko.Scale.Y ));

                animation_ko.Add(_ko);
            }
        }


        internal void AnimationKO(Game game)
        {
            if ( ( game._fighter1.Health == 0 || game._fighter2.Health == 0 ) && _timerKO < game._clock.ElapsedTime.AsSeconds() && _iKO < 38 )
            {
                _KO = animation_ko[_iKO];
                _iKO++;
                _timerKO = game._clock.ElapsedTime.AsSeconds() + 0.0400f;
            }

        }

        internal Sprite KO => _KO;

    }
}
