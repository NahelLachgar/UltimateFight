using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFight
{
    internal class EnergyBars
    {
        private float _windowX;
        private float _windowY;
        private float _energy1 = 2f;
        private float _energy2 = 2f;
        private List<RectangleShape> _EnergyBar = new List<RectangleShape>();
        internal BlueFlames blueFlames;

        internal EnergyBars(RenderWindow window, HealthBar healthBar, Game game)
        {
            _windowX = window.Size.X;
            _windowY = window.Size.Y;
            List<RectangleShape> list = healthBar.Bar;
            blueFlames = new BlueFlames(window, game);

            // Back Energy Bar for Player 1 & Player 2
            RectangleShape _BackEnergyBar1 = new RectangleShape()
            {
                Position = new Vector2f(list[0].Position.X + list[0].Size.X *0.4f, ( _windowY * 0.115f )),
                Size = new Vector2f(( _windowX * 0.176f ), ( _windowY * 0.025f )),
                FillColor = Color.White,
                OutlineColor = Color.Black,
                Texture = new Texture("../../../../pi.Ui/Resources/Img/Fight_Font/bar1.png"),
            };

            RectangleShape _BackEnergyBar2 = new RectangleShape(_BackEnergyBar1)
            {
                Position = new Vector2f(_windowX - _BackEnergyBar1.Position.X - _BackEnergyBar1.Size.X , _BackEnergyBar1.Position.Y),
            };

            //-------------------------------------------------------------------------------------------------------------------------

            // Energy Bar for Player 1 & Player 2
            RectangleShape _EnergyBar1 = new RectangleShape()
            {
                Position = new Vector2f(list[0].Position.X + list[0].Size.X *0.4f, ( _windowY * 0.115f )),
                Size = new Vector2f(( _windowX * 0.176f ), ( _windowY * 0.025f )),
                FillColor = Color.Blue,
                OutlineColor = Color.Black,
                //Texture = new Texture("../../../../pi.Ui/Resources/Fight_Font/bar1.png"),
            };

            RectangleShape _EnergyBar2 = new RectangleShape(_EnergyBar1)
            {
                Position = new Vector2f(_windowX - _BackEnergyBar1.Position.X , _BackEnergyBar1.Position.Y),
                Scale = new Vector2f(-1f, 1f),
            };

            _EnergyBar.Add(_EnergyBar1);  // Element 0
            _EnergyBar.Add(_EnergyBar2);  // Element 1
            _EnergyBar.Add(_BackEnergyBar1);  // Element 2
            _EnergyBar.Add(_BackEnergyBar2);  // Element 3
            //-------------------------------------------------------------------------------------------------------------------------
        }


        private void UpdateEnergyBar(uint Energy1, uint Energy2)
        {
            _energy1 = Convert.ToSingle(Energy1);
            _energy2 = Convert.ToSingle(Energy2);

            _EnergyBar[0].Size = new Vector2f(_EnergyBar[2].Size.X / 100f * _energy1, _EnergyBar[2].Size.Y);
            _EnergyBar[1].Size = new Vector2f(_EnergyBar[3].Size.X / 100f * _energy2, _EnergyBar[3].Size.Y);
        }

        internal List<RectangleShape> EnergyBar => _EnergyBar;

        internal void Update(Game game, EnergyBars energyBars)
        {
            this.UpdateEnergyBar(game._fighter1.Energy, game._fighter2.Energy);
            blueFlames.UpdateEnergyFlame(game, energyBars);
        }
    }
}
