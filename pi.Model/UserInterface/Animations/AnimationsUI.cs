using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFight
{
    internal class AnimationsUI
    {
        K_O KO;


        internal AnimationsUI(RenderWindow window, Game game)
        {
            KO = new K_O(window, game);
        }


        internal void Update(Game game)
        {
            KO.AnimationKO(game);
        }

        internal K_O Ko => KO;
    }
}
