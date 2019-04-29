using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFight
{
    public class UserInterface
    {
        GameTimer gameTimer;
        HealthBar healthBar;
        EnergyBars energyBar;
        PlayerName playerName;
        Round round;
        AnimationsUI animationsUI;

        public UserInterface(RenderWindow window, Game game)
        {
            gameTimer = new GameTimer();
            healthBar = new HealthBar(window, game);
            energyBar = new EnergyBars(window, healthBar, game);
            playerName = new PlayerName(game, healthBar);
            round = new Round(healthBar);
            animationsUI = new AnimationsUI(window, game);

        }

        public void Update(Game game)
        {
            if ( game._fighter1._health > 0 && game._fighter2._health > 0 )
            {
                gameTimer.UpdateTimerGame(game);
            }
            healthBar.UpdateBars(game);
            energyBar.Update(game, energyBar);
            animationsUI.Update(game);
            round.Update(game);
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
            window.Draw(animationsUI.Ko.KO);
        }
    }
}
