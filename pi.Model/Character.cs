using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace pi
{
    public class Character //:Sprite
    {
        readonly internal string _name;
        public  Sprite _sprite;
        // internal Special _special;
        internal uint _health;
        internal Vector2f _position;
        Dictionary<string, IntRect> _rects;
        //Animation _animation;

        public Character(string name, Sprite sprite)
        {
            _name = name;
            _health = 100;
            _sprite = sprite;
           // _animation = new Animation(this);
        }

        internal string Name => _name;

        internal bool IsAlive => Health != 0;

        public uint Health => _health;


        internal Vector2f Position
        {
            get { return _position; }
            set { _position = value; }
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

        internal void TakeDammage(uint Hit)
        {
            _health = _health - Hit;
            if(_health > 100)
            {
                _health = 0;
            }
        }
    }
}
