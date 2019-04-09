using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace pi
{
    public class Character
    {
        readonly internal string _name;
        internal Sprite _sprite;
      // internal Special _special;
        internal uint _health = 100;
        internal Vector2f _position;

        public Character(string name, Sprite sprite)
        {
            _name = name;
            _sprite = sprite;
        }

        internal string Name => _name;

        internal uint Health
        {
            get { return _health; }
            set { _health = value; }
        }

        internal Vector2f Position
        {
            get { return _position; }
        }

        internal void Update()
        {

        }

        internal void Waiting()
        {

        }

        internal void MoveRight(float xToAdd)
        {
        }

        internal void MoveLeft(float xToRemove)
        {
        }

        internal void Jump(float toAdd)
        {
        }
        
        internal void LightPunch()
        {
        }

        internal void HeavyPunch()
        {

        }

        internal void LightKick()
        {

        }

        internal void HeavyKick()
        {
           
        }

        internal void Special()
        {

        }

        internal void TakeDammage()
        {

        }
    }
}
