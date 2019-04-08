using System;
using System.Threading;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace pi
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();



            SFML.GraphicsNative.Load();
            SFML.WindowNative.Load();

            Sprite stage = new Sprite();
            Texture image = new Texture("../../../../img/stages/stage1.png");
            stage.Texture = image;
            stage.Scale = new Vector2f(1.25F, 2.2F);

            Sprite fighter = new Sprite();
            Texture fighterImage = new Texture("../../../../img/characters/winnie.png");
            fighter.Texture = fighterImage;
            fighter.Scale = new Vector2f(2f, 2.5f);
            fighter.TextureRect = new IntRect(0, 50, 150, 200);
            fighter.Position = new Vector2f(10, 1300);

            Clock clock = new Clock();

            using (RenderWindow window = new RenderWindow(VideoMode.DesktopMode, "Test window"))
            {
                while (window.IsOpen)
                {
                    game.Update();


                    window.WaitAndDispatchEvents();

                    window.KeyPressed += buttonPressed;
                    void buttonPressed(object sender, KeyEventArgs e)
                    {
                        OnKeyPress(e);
                    }


                    void OnKeyPress(KeyEventArgs e)
                    {
                        if (e.Code == Keyboard.Key.Right)
                        {
                            fighter.Position += new Vector2f(0.1f, 0);
                        }
                        else if (e.Code == Keyboard.Key.Left)
                        {
                            fighter.Position -= new Vector2f(0.1f, 0);
                        }
                        else if (e.Code == Keyboard.Key.Up || e.Code == Keyboard.Key.Space)
                        {
                            fighter.Position -= new Vector2f(0, 2.5f);
                        }
                        else if (e.Code == Keyboard.Key.Down)
                        {
                            fighter.Position += new Vector2f(0, 0.1f);
                        }
                        else if (e.Code == Keyboard.Key.A)
                        {
                            if (fighter.TextureRect == new IntRect(0, 50, 150, 200))
                                fighter.TextureRect = new IntRect(100, 60, 10, 200);
                            else
                                fighter.TextureRect = new IntRect(0, 50, 150, 200);
                        }
                    }
                    window.Clear();

                    window.Draw(stage);
                    window.Draw(fighter);
                    window.Display();

                }
            }
        }
    }
}