using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{ 
    public class User
    {
        internal string _name;
        internal string _ip;

        internal User(string name, string ip)
        {
            _name = name;
            _ip = ip;
        }

        internal string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        internal string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
    }
}
