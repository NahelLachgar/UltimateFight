using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UserInterface
    {
        Timer gameTimer;
        HealthBar healthBar;
        EnergyBars energyBar;
        PlayerName playerName;
        Round round;
        AnimationsUI animationsUI;

        public UserInterface(Game game)
        {
            gameTimer = new Timer();
            healthBar = new HealthBar( game);
            energyBar = new EnergyBars( healthBar, game);
            playerName = new PlayerName(game, healthBar);
            round = new Round(healthBar);
            animationsUI = new AnimationsUI();

        }

        public void Update(Game game)
        {
            healthBar.Update(game);
            energyBar.Update(game, energyBar);
            animationsUI.Update(game);
            round.Update(game);

            if ( animationsUI._ready._start == true )
            {
                gameTimer.UpdateTimer(game);
            }
        }

        public void Draw(RenderWindow window)
        {
            // Timer
            window.Draw(gameTimer.FontTimer1);
            window.Draw(gameTimer.FontTimer2);
            // Health Bar
            foreach ( RectangleShape value in healthBar.Bar ) window.Draw(value);
            // Energy Bar
            foreach ( RectangleShape value in energyBar.EnergyBar ) window.Draw(value);
            // Player's names
            window.Draw(playerName.NamePlayer1);
            window.Draw(playerName.NamePlayer2);
            // Animation blues flames
            window.Draw(energyBar.blueFlames.BlueFlame1);
            window.Draw(energyBar.blueFlames.BlueFlame2);
            // Round win
            window.Draw(round._P1round1);
            window.Draw(round._P1round2);
            window.Draw(round._P2round1);
            window.Draw(round._P2round2);
            // Animation K.O
            window.Draw(animationsUI.KO.KO);

            window.Draw(animationsUI._ready._text);
        }
    }
}
