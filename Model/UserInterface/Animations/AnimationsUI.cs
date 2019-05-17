using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    internal class AnimationsUI
    {
        internal K_O KO;
        internal Ready _ready;

        internal AnimationsUI()
        {
            KO = new K_O();
            _ready = new Ready();
        }


        internal void Update(Game game)
        {
            KO.AnimationKO(game);
            _ready.AnimationReady(game);
        }


    }
}
