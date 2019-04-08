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

        public Fighter(string name, Sprite sprite, Vector2f position)
        {
            _name = name;
            _sprite = sprite;
            _health = 100;
            _position = position;
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
