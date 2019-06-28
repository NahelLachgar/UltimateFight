using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace UI
{
    internal class BlueFlames 
    {
        private List<Sprite> _animation_BlueFlame = new List<Sprite>();
        private Sprite _blueFlame1;
        private Sprite _blueFlame2;
        private int _blueFlameCount = 14;
        private float _energyTimer = 0f;
        private Clock _clock;

        internal BlueFlames(Game game)
        {
            _clock = game._clock;

            // Sprite for draw the animation of blue flame for energy bars's players
            for ( int i = 1; i <= 19; i++ )
            {
                Texture texture = new Texture("../../../../Ui/Resources/Img/Blue_Flame/Blue_Flame(photoshop)/" + i + ".png");
                texture.Smooth = true;
                Sprite flame = new Sprite(texture);
                _animation_BlueFlame.Add(flame);
            }

            // Animation of BlueFlame on Energy Bar for Player 1 & Player 2
            _blueFlame1 = new Sprite(_animation_BlueFlame[0].Texture, new IntRect(0, 140, 120, 140))
            {
                Scale = new Vector2f(0.48f, 0.378f),
                Position = new Vector2f(401f, 95f),
            };

            _blueFlame2 = new Sprite(_animation_BlueFlame[0].Texture, new IntRect(0, 140, 120, 140))
            {
                // Don't forget to multiply by the scale applicated :  Here it's by 0.4f
                Scale = new Vector2f(0.48f, 0.378f),
                Position = new Vector2f(1920 - _blueFlame1.Position.X - ( _blueFlame1.TextureRect.Width * _blueFlame1.Scale.X ), _blueFlame1.Position.Y),
            };

        }


        internal void UpdateEnergyFlame(EnergyBars energyBars)
        {
            if ( _clock.ElapsedTime.AsSeconds() > _energyTimer + 0.02f )
            {
                _blueFlame1.Texture = _animation_BlueFlame[_blueFlameCount].Texture;
                _blueFlame1.Position = new Vector2f(energyBars.EnergyBar[0].Position.X + energyBars.EnergyBar[0].Size.X - 30f, energyBars.EnergyBar[0].Position.Y - energyBars.EnergyBar[0].Size.Y);

                _blueFlame2.Texture = _animation_BlueFlame[_blueFlameCount].Texture;
                _blueFlame2.Position = new Vector2f(energyBars.EnergyBar[1].Position.X - energyBars.EnergyBar[1].Size.X - 30f, energyBars.EnergyBar[1].Position.Y - energyBars.EnergyBar[1].Size.Y);

                _energyTimer += 0.115f;
                if ( _blueFlameCount < 18 ) _blueFlameCount++;
                else _blueFlameCount = 14;
            }
        }


        internal Sprite BlueFlame1 => _blueFlame1;

        internal Sprite BlueFlame2 => _blueFlame2;

    }
}
