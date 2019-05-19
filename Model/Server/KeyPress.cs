using Model;
using SFML.Window;
using System;
using System.Runtime.Serialization;

namespace Model
{
    public class KeyPress
    {

        public Game _game;

        public Keyboard.Key _key;

        public KeyPress(Game game = null, Keyboard.Key key = Keyboard.Key.Unknown)
        {
            _game = game;
            _key = key;
        }
    }
}
