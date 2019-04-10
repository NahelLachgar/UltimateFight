using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using System.Text;

namespace pi
{
    public class Stage
    {
        string _name;
        public Sprite _sprite;
        int _groundHeight;  

        public Stage(string name, Sprite sprite, int groundHeight)
        {
            _name = name;
            _sprite = sprite;
            _groundHeight = groundHeight;
        }
    }
}
