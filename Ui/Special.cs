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
                            character._hitbox.Position = new Vector2f(character._sprite.Position.X , character._sprite.Position.Y);
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
                            character._projectile.isThrown = true;
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile1"];
                            character._projectile.Position = new Vector2f(character.Position.X + character.Width, character._sprite.Position.Y + character._sprite.TextureRect.Height / 2);
                            break;
                        case 450:
                            character._sprite.TextureRect = character._animationRect["special2"];
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile2"];
                            break;
                        case 600:
                            character._sprite.TextureRect = character._animationRect["special1"];
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile3"];
                            break;
                        case 651:
                            _i = -1;
                            return true;
                    }
                    break;
                // Bison
                case "Bison":
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
                            character._sprite.Color = new Color(255, 255, 255, 0);
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile1"];
                            character._projectile.isThrown = true;
                            character._projectile.Position = new Vector2f(character.Position.X, character._sprite.Position.Y + character._sprite.TextureRect.Height / 2);
                            break;
                        case 400:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile2"];
                            break;
                        case 500:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile3"];
                            break;
                        case 600:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile4"];
                            break;
                        case 700:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile5"];
                            break;
                        case 800:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile2"];
                            break;
                        case 900:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile3"];
                            break;
                        case 1000:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile4"];
                            break;
                        case 1100:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile5"];
                            break;
                        case 1200:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile2"];
                            break;
                        case 1300:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile3"];
                            break;
                        case 1400:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile4"];
                            break;
                        case 1500:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile5"];
                            break;
                        case 1600:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile2"];
                            break;
                        case 1700:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile3"];
                            break;
                        case 1800:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile4"];
                            break;
                        case 1900:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile5"];
                            break;
                        case 1902:
                            character._sprite.TextureRect = character._animationRect["special2"];
                            _i = -1;
                            return true;
                    }
                    if (_i >= 600 && character._projectile.isThrown != false) character.Position = new Vector2f(character._projectile.Position.X, 0f);
                    if (_i >= 600 && character._projectile.isThrown == false)
                    {
                        character._sprite.Color = new Color(255, 255, 255, 255);
                        _i = 1901;
                    }
                    break;
                // Ryu
                case "Ryu":
                    _i++;
                    switch (_i)
                    {
                        case 0:
                            character._sprite.TextureRect = character._animationRect["special1"];
                            break;
                        case 200:
                            character._sprite.Color = new Color(255, 255, 255, 0);
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile1"];
                            character._projectile.isThrown = true;
                            character._projectile.Position = new Vector2f(character.Position.X, character._sprite.Position.Y);
                            character._projectile.Position += new Vector2f(0f, character._sprite.TextureRect.Height * character._sprite.Scale.X - character._projectile.Sprite.TextureRect.Height * character._sprite.Scale.X);
                            break;
                        case 300:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile2"];
                            break;
                        case 400:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile3"];
                            break;
                        case 500:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile4"];
                            break;
                        case 600:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile5"];
                            break;
                        case 700:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile1"];
                            break;
                        case 800:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile2"];
                            break;
                        case 900:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile3"];
                            break;
                        case 1000:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile4"];
                            break;
                        case 1100:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile5"];
                            break;
                        case 1200:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile1"];
                            break;
                        case 1300:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile2"];
                            break;
                        case 1400:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile3"];
                            break;
                        case 1500:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile4"];
                            break;
                        case 1600:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile1"];
                            break;
                        case 1700:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile2"];
                            break;
                        case 1800:
                            character._projectile.Sprite.TextureRect = character._animationRect["projectile3"];
                            break;
                        case 1802:
                            character._sprite.TextureRect = character._animationRect["special2"];
                            _i = -1;
                            return true;
                    }
                    if (_i >= 600 && character._projectile.isThrown != false)
                    {
                        character.Position = new Vector2f(character._projectile.Position.X, 0f);
                    }
                    if (_i >= 600 && character._projectile.isThrown == false)
                    {
                        character._sprite.Color = new Color(255, 255, 255, 255);
                        _i = 1801;
                    }
                    break;
                // Android 16
                case "16":
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
                            break;
                        case 450:
                            character._sprite.TextureRect = character._animationRect["special4"];
                            character._projectile.isThrown = true;
                            character._projectile.Position = new Vector2f(character.Position.X + character.Width, character._sprite.Position.Y + character._sprite.TextureRect.Height / 2);
                            break;
                        case 550:
                            character._sprite.TextureRect = character._animationRect["special5"];
                            break;
                        case 700:
                            character._sprite.TextureRect = character._animationRect["special6"];
                            break;
                        case 900:
                            character._sprite.TextureRect = character._animationRect["special7"];
                            break;
                        case 1100:
                            character._sprite.TextureRect = character._animationRect["special8"];
                            break;
                        case 1201:
                            _i = -1;
                            return true;
                    }
                    break;
                // Goku
                case "Goku":
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
                            break;
                        case 450:
                            character._sprite.TextureRect = character._animationRect["special4"];
                            break;
                        case 550:
                            character._sprite.TextureRect = character._animationRect["special5"];
                            break;
                        case 650:
                            character._sprite.TextureRect = character._animationRect["special4"];
                            break;
                        case 750:
                            character._sprite.TextureRect = character._animationRect["special5"];
                            break;
                        case 850:
                            character._sprite.TextureRect = character._animationRect["special4"];
                            break;
                        case 950:
                            character._sprite.TextureRect = character._animationRect["special5"];
                            break;
                        case 1050:
                            character._sprite.TextureRect = character._animationRect["special6"];
                            break;
                        case 1150:
                            character._sprite.TextureRect = character._animationRect["special7"];
                            break;
                        case 1250:
                            character._sprite.TextureRect = character._animationRect["special6"];
                            break;
                        case 1350:
                            character._sprite.TextureRect = character._animationRect["special7"];
                            break;
                        case 1450:
                            character._sprite.TextureRect = character._animationRect["special6"];
                            break;
                        case 1550:
                            character._sprite.TextureRect = character._animationRect["special7"];
                            break;
                        case 1650:
                            character._sprite.TextureRect = character._animationRect["special6"];
                            break;
                        case 1750:
                            character._sprite.TextureRect = character._animationRect["special7"];
                            break;
                        case 1850:
                            character._sprite.TextureRect = character._animationRect["special6"];
                            break;
                        case 1950:
                            character._sprite.TextureRect = character._animationRect["special7"];
                            break;
                        case 2050:
                            character._sprite.TextureRect = character._animationRect["special7"];
                            break;
                        case 2250:
                            character._sprite.TextureRect = character._animationRect["special8"];
                            break;
                        case 2450:
                            character._sprite.TextureRect = character._animationRect["special9"];
                            break;
                        case 2650:
                            character._sprite.TextureRect = character._animationRect["special10"];
                            break;
                        case 2850:
                            character._sprite.TextureRect = character._animationRect["special11"];
                            break;
                        case 3050:
                            character._sprite.TextureRect = character._animationRect["special12"];
                            break;
                        case 3250:
                            character._sprite.TextureRect = character._animationRect["special13"];
                            break;
                        case 3450:
                            character._sprite.TextureRect = character._animationRect["special14"];
                            break;
                        case 3550:
                            character._sprite.TextureRect = character._animationRect["special15"];
                            character._projectile.isThrown = true;
                            character._projectile.Position = new Vector2f(character.Position.X + character.Width, character._sprite.Position.Y + character._sprite.TextureRect.Height / 2);
                            break;
                        case 3850:
                            character._sprite.TextureRect = character._animationRect["special16"];
                            break;

                        case 3951:
                            _i = -1;
                            return true;
                    }
                    break;
            }
            return false;
        }
    }
}
