using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFight
{
    public class PlayerName 
    {
        Text _player1;
        Text _player2;

        public PlayerName(Game game)
        {
            _player1 = new Text
            {
                Font = new Font("../../../Resources/space_ranger/spaceranger.ttf"),
                Position = new Vector2f(190f, -15f),
                DisplayedString = game._fighter1.Name,
                CharacterSize = 60,
                
            };

            _player2 = new Text(_player1)
            {
                Position = new Vector2f(1150f, -15f),
            };

        }

        public Text Player1 => _player1;
        public Text Player2 => _player2;

        public void Update()
        {
            
        }

    }
}
