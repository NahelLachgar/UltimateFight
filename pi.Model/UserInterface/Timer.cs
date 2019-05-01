using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateFight;

namespace UltimateFight
{
    internal class Timer 
    {
        private List<Sprite> animation_fontTimer = new List<Sprite>() ;
        private Sprite _fontTimer1 ;
        private Sprite _fontTimer2 ;

        internal Timer()
        {
            Texture texture;
            // Sprite for draw the timer in-game
            for ( int i = 0; i < 10; i++ )
            {
                texture = new Texture("../../../../pi.Ui/Resources/Img/Fight_Font/" + i + ".png");
                texture.Smooth = true;
                Sprite font = new Sprite(texture);
                font.Scale = new Vector2f(1f, 1f);
                animation_fontTimer.Add(font);
            }

            _fontTimer1 = new Sprite
            {
                Texture = animation_fontTimer[9].Texture,
                Scale = new Vector2f( 2.3f, 2.3f),
                Position = new Vector2f(  900f, 50f ),
            };

            _fontTimer2 = new Sprite(_fontTimer1)
            {
                Position = new Vector2f(963f, 50f),
            };
        }
        


        internal void UpdateTimer(Game game)
        {
            float time = game._timerGame - game._clock.ElapsedTime.AsSeconds();
            decimal font_time1;
            decimal font_time2;
            if ( time > 0f )
            {
                font_time1 = Math.Truncate(Convert.ToDecimal(time / 10f));
                font_time2 = Math.Truncate(Convert.ToDecimal(time) - ( font_time1 * 10 ));

                _fontTimer1.Texture = animation_fontTimer[Convert.ToInt32(font_time1)].Texture;
                _fontTimer2.Texture = animation_fontTimer[Convert.ToInt32(font_time2)].Texture;
            }
        }

        internal Sprite FontTimer1 => _fontTimer1;

        internal Sprite FontTimer2 => _fontTimer2;

    }
}
