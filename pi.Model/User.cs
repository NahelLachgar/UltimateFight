using System;
using System.Collections.Generic;
using System.Text;

namespace pi
{
    public class User
    {
        uint _wins;
        uint _loses;
        string _name;

        internal User(string name)
        {
            _wins = 0;
            _loses = 0;
            _name = name;
        }

        internal string Name => _name;

        internal uint Wins
        {
            get { return _wins; }
            set { _wins = value; }
        }
    }
}
