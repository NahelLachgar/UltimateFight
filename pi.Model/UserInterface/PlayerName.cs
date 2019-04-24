using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFight
{
    internal class PlayerName 
    {
        Text _namePlayer1;
        Text _namePlayer2;

        internal PlayerName(Game game)
        {
            _namePlayer1 = new Text
            {
                Font = new Font("../../../Resources/Fonts/space_ranger/spaceranger.ttf"),
                Position = new Vector2f(190f, -15f),
                DisplayedString = game._fighter1.Name,
                CharacterSize = 60,
                
            };

            _namePlayer2 = new Text(_namePlayer1)
            {
                Position = new Vector2f(1150f, -15f),
                DisplayedString = game._fighter2.Name,

            };

        }

        internal Text NamePlayer1 => _namePlayer1;
        internal Text NamePlayer2 => _namePlayer2;



    }
}
