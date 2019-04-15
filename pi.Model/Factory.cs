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
            Character character = new Character(name,texture);
            character.Scale = scale;
            character.TextureRect = new IntRect(rect.Left,rect.Top,rect.Width,rect.Height);
            return character;
        }

        public Stage CreateStage(string name, string img, int groundHeight, RenderWindow window)
        {
            Texture texture = new Texture("../../../../img/stages/" + img);
            //Sprite sprite = new Sprite(texture);
            //sprite.Scale = scale;

            Stage stage = new Stage(name, /*sprite,*/ groundHeight, window, texture);
            return stage;
        }
        
        public Character NewCharacter (string name)
        {
            switch (name)
            {
                case "balrog":
                    Character character = CreateCharacter("balrog", "balrog.png", new IntRect(220, 15, 55, 100), new Vector2f(5, 5));
                    return character;
                default:
                    return null;
            }
        }

        public Stage NewStage(string name, RenderWindow window)
        {
            switch(name)
            {
                case "stage1":
                    Stage stage = CreateStage("stage1", "stage1.jpg", 1300, window);
                    return stage;
                default:
                    return null;
            }
        }

    }
}