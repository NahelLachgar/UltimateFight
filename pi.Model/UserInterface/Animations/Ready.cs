using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    internal class Ready
    {
        internal Text _text;
        internal bool _start = false;
        




        internal Ready()
        {

            _text = new Text()
            {
                Position = new Vector2f(960, 540),
                CharacterSize = 160,
                Font = new Font("../../../Resources/Fonts/Gyosho/Gyosho.ttf"),
                OutlineThickness = 16f,
                OutlineColor = Color.Black,
                LetterSpacing = 2f,
                Style = Text.Styles.Italic,
            };

        }

        internal void AnimationReady(Game game)
        {
            if ( _start == false )
            {
                if ( game._clock.ElapsedTime.AsSeconds() < 2f )
                {
                    _text.DisplayedString = "Ready";
                    _text.Position = new Vector2f(960 - ( _text.GetGlobalBounds().Width / 2 ), 540 - ( _text.GetGlobalBounds().Height / 2 ));
                }
                else if ( game._clock.ElapsedTime.AsSeconds() < 3f )
                {
                    _text.DisplayedString = "3";
                    _text.CharacterSize = 450;
                    _text.Position = new Vector2f(960 - ( _text.GetGlobalBounds().Width / 2 ), 540 - ( _text.GetGlobalBounds().Height / 2 ));

                }
                else if ( game._clock.ElapsedTime.AsSeconds() < 4f )
                {
                    _text.DisplayedString = "2";
                    _text.Position = new Vector2f(960 - ( _text.GetGlobalBounds().Width / 2 ), 540 - ( _text.GetGlobalBounds().Height / 2 ));

                }
                else if ( game._clock.ElapsedTime.AsSeconds() < 5f )
                {
                    _text.DisplayedString = "1";
                    _text.Position = new Vector2f(960 - ( _text.GetGlobalBounds().Width / 2 ), 540 - ( _text.GetGlobalBounds().Height / 2 ));

                }
                else if ( game._clock.ElapsedTime.AsSeconds() < 6f )
                {
                    _text.DisplayedString = "FIGHT !";
                    _text.CharacterSize = 160;
                    _text.Position = new Vector2f(960 - ( _text.GetGlobalBounds().Width / 2 ), 540 - ( _text.GetGlobalBounds().Height / 2 ));

                }
                else
                {
                    _start = true;
                    game._clock.Restart();
                    _text.DisplayedString = string.Empty;
                }
            }

        }

    }
}
