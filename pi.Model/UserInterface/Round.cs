using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFight
{
    internal class Round
    {
        internal CircleShape _P1round1;
        internal CircleShape _P1round2;
        internal CircleShape _P2round1;
        internal CircleShape _P2round2;


        internal Round(HealthBar healthBar)
        {
            _P1round1 = new CircleShape(17f, 4)
            {
                FillColor = Color.Transparent,
                OutlineColor = Color.Magenta,
                OutlineThickness = 5f,
                Position = new Vector2f( healthBar.Bar[0].Position.X, healthBar.Bar[0].Position.Y + 50f),
            };

            _P1round2 = new CircleShape(_P1round1);
            _P1round2.Position += new Vector2f(40f, 0f);

            _P2round1 = new CircleShape(_P1round1)
            {
                Position = new Vector2f(healthBar.Bar[1].Position.X + healthBar.Bar[1].Size.X, healthBar.Bar[0].Position.Y + 50f),
                Scale = new Vector2f(-1, 1),
                
            };

            _P2round2 = new CircleShape(_P2round1);
            _P2round2.Position += new Vector2f(-40f, 0f);
        }



        internal void Update(Game game)
        {
            UpdateColorRound(game);
        }

        internal void UpdateColorRound(Game game)
        {
            if ( game._fighter1._roundWin >= 1 ) _P1round1.FillColor = Color.Yellow;
            if ( game._fighter1._roundWin >= 2 ) _P1round2.FillColor = Color.Yellow;

            if ( game._fighter2._roundWin >= 1 ) _P2round1.FillColor = Color.Yellow;
            if ( game._fighter2._roundWin >= 2 ) _P2round2.FillColor = Color.Yellow;
        }

    }
}
