﻿using System.Net.Sockets;
using System.Text;


namespace Model
{
    static public class Client
    {

        static public void SendKey(string key)
        {
            UdpClient _udpClient = new UdpClient();
            byte[] msg = Encoding.Default.GetBytes(key);

            _udpClient.Send(msg, msg.Length, "127.0.0.1", 5035);
            _udpClient.Close();
        }
    }
}