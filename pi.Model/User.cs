using System;
using System.Collections.Generic;
using System.Text;

namespace pi.Model
{
    public class User
    {
        Fighter _fighter;
        string _name;

        internal User(Fighter fighter, string name)
        {
            _fighter = fighter;
            _name = name;
        }
    }
}
