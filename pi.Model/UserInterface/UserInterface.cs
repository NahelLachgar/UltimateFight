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
        AnimationsUI animationsUI;

        public UserInterface(RenderWindow window, Game game)
        {
            gameTimer = new GameTimer();
            healthBar = new HealthBar(window, game);
            energyBar = new EnergyBars(window, healthBar, game);
            playerName = new PlayerName(game);
            animationsUI = new AnimationsUI(window, game);
        }

        public void Update(Game game)
        {
            gameTimer.UpdateTimerGame(game);
            healthBar.UpdateBars(game);
            energyBar.Update(game, energyBar);
            animationsUI.Update(game);
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(gameTimer.FontTimer1);
            window.Draw(gameTimer.FontTimer2);
            foreach ( RectangleShape value in healthBar.Bar ) window.Draw(value);
            foreach ( RectangleShape value in energyBar.EnergyBar ) window.Draw(value);
            window.Draw(playerName.NamePlayer1);
            window.Draw(playerName.NamePlayer2);
            window.Draw(energyBar.blueFlames.BlueFlame1);
            window.Draw(energyBar.blueFlames.BlueFlame2);
            window.Draw(animationsUI.Ko.KO);
        }
    }
}
