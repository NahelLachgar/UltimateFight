using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace pi
{
    public class Factory
    {
        public Character CreateCharacter (string name, string img, IntRect rect, Vector2f scale)
        {
            Texture texture = new Texture("../../../../img/characters/" + img);
            texture.Smooth = true;
            Sprite sprite = new Sprite(texture);
            sprite.Scale = scale;
            sprite.TextureRect = new IntRect(rect.Left,rect.Top,rect.Width,rect.Height);
            Character character = new Character(name, sprite);
            return character;
        }

        public Stage CreateStage(string name, string img, int groundHeight, Vector2f scale)
        {
            Texture texture = new Texture("../../../../img/stages/" + img);
            Sprite sprite = new Sprite(texture);
            sprite.Scale = scale;
            Stage stage = new Stage(name, sprite, groundHeight);
            return stage;
        }
        
        public Character NewCharacter (string name)
        {
            switch (name)
            {
                case "balrog":
                    Character character = CreateCharacter("balrog", "balrog.png", new IntRect(220, 15, 40, 100), new Vector2f(5, 5));
                    return character;
                default:
                    return null;
            }
        }
        public Stage NewStage (string name)
        {
            switch(name)
            {
                case "stage1":
                    Stage stage = CreateStage("stage1", "stage1.jpg", 600, new Vector2f(1.25F, 2F));
                    return stage;
                default:
                    return null;
            }
        }

    }
}