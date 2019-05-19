using System;
using System.Runtime.Serialization;

namespace Server
{
    [DataContract]
    public class KeyPress
    {

        [DataMember]
        public string _game;

        [DataMember]
        public ConsoleKey _key;

        public KeyPress(string game = null, ConsoleKey key = ConsoleKey.A)
        {
            _game = game;
            _key = key;
        }
    }
}
