using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace pi.Model
{
    public class Fighter
    {
        string _name;
        Sprite _sprite;
        Special _special;
        uint _health;
        Vector2f _position;
        public Fighter(string name, Sprite sprite, Special special, float x, float y)
        {
            _name = name;
            _sprite = sprite;
            _special = special;
            _health = 100;
            _position = new Vector2f(x, y);
        }

        internal void Update()
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
