<<<<<<< HEAD
﻿using System.Net.Sockets;
=======
﻿using Model;
using Newtonsoft.Json;
using SFML.Window;
using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
>>>>>>> c024e1faa1940fad830c75c797bfc6323258e1b0
using System.Text;


namespace Model
{
    static public class Client
    {

        static public void SendKey(string key)
        {
            UdpClient _udpClient = new UdpClient();
            byte[] msg = Encoding.Default.GetBytes(key);

<<<<<<< HEAD
            _udpClient.Send(msg, msg.Length, "192.168.230.129", 5035);
            _udpClient.Close();
        }
=======
            _udpClient.Send(msg, msg.Length, "127.0.0.1", 5035);
            _udpClient.Close();
        }   
>>>>>>> c024e1faa1940fad830c75c797bfc6323258e1b0
    }
}