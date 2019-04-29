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

        internal PlayerName(Game game, HealthBar bar)
        {
            _namePlayer1 = new Text
            {
                Font = new Font("../../../Resources/Fonts/Cocogoose/CocogooseBold.ttf"),
                Position = new Vector2f(190f, 6f),
                DisplayedString = game._fighter1.Name,
                CharacterSize = 35,
                Style = Text.Styles.Italic ,    
                OutlineColor = Color.Black,
                OutlineThickness = 4f,
            };
            _namePlayer1.Position = new Vector2f(bar.Bar[0].Position.X , _namePlayer1.Position.Y);


            _namePlayer2 = new Text(_namePlayer1)
            {
                DisplayedString = game._fighter2.Name,
            };
            _namePlayer2.Position = new Vector2f(bar.Bar[1].Position.X + bar.Bar[1].Size.X - _namePlayer2.GetGlobalBounds().Width, _namePlayer2.Position.Y);


        }

        internal Text NamePlayer1 => _namePlayer1;
        internal Text NamePlayer2 => _namePlayer2;



    }
}
