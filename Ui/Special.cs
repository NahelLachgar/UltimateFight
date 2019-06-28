using SFML.Graphics;
using SFML.System;
using System;


namespace Model
{
    public class Special
    {
        int _i = -1;
        bool _isFinished = false;

        public bool SpecialMove(Character character)
        {
            
            switch (character.Name)
            {
                // BALROG
                case "Balrog":
                    _i++;
                    switch (_i)
                    {
                        case 0:
                            character._sprite.TextureRect = character._animationRect["special1"];
                            character._sprite.Position += new Vector2f(80f, 0f);
                            break;
                        case 100:
                            character._sprite.TextureRect = character._animationRect["special2"];
                            character._sprite.Position += new Vector2f(80f, 0f);
                            break;
                        case 200:
                            character._sprite.TextureRect = character._animationRect["special3"];
                            character._hitbox.Size = new Vector2f(character._sprite.TextureRect.Width, character._sprite.TextureRect.Height);
                            character._sprite.Position += new Vector2f(80f, 0f);
                            break;
                        case 300:
                            character._sprite.TextureRect = character._animationRect["special4"];
                            character._hitbox.Size = new Vector2f(0, 0);
                            character._sprite.Position += new Vector2f(80f, 0f);
                            break;
                        case 401:
                            character._sprite.TextureRect = character._animationRect["special5"];
                            _i = -1;
                            return true;
                    }
                    break;
                // Sagat
                case "Sagat":
                    _i++;
                    switch (_i)
                    {
                        case 0:
                            character._sprite.TextureRect = character._animationRect["special1"];
                            break;
                        case 150:
                            character._sprite.TextureRect = character._animationRect["special2"];
                            break;
                        case 300:
                            character._sprite.TextureRect = character._animationRect["special3"];
                            character._projectileThrown = true;
                            character._projectile.Position = new Vector2f(character._sprite.Position.X + character._sprite.TextureRect.Width * character._sprite.Scale.X, character._sprite.Position.Y + character._sprite.TextureRect.Height / 2);
                            break;
                        case 351:
                            _i = -1;
                            return true;
                    }
                    break;
            }
            return false;
        }
    }
}
