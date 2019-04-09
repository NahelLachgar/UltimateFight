using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace pi
{
    public class Factory
    {
        Dictionary<string, Character> _characters;
        Dictionary<string, Stage> _stages;

        public Factory()
        {
            _characters = new Dictionary<string, Character>();
            _stages = new Dictionary<string, Stage>();
        }

        public Character CreateCharacter (string name, Sprite sprite)
        {
            Character character = new Character(name, sprite);
            _characters.Add(name, character);
            return character;
        }

        public Stage CreateStage(string name, Sprite sprite, int groundHeight)
        {
            Stage stage = new Stage(name, sprite, groundHeight);
            _stages.Add(name, stage);
            return stage;
        }


    }
}