using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using Model;


namespace Server
{
    public class Client
    {
        UdpClient _udpClient = new UdpClient();

        public void SendKey(ConsoleKey key, Game game)
        {
            KeyPress keyPress = new KeyPress(key, game);

            string toSend = JsonConvert.SerializeObject(keyPress);

            byte[] msg = Encoding.Default.GetBytes(toSend);

            try
            {
                _udpClient.Send(msg, msg.Length, "10.8.110.207", 5035);
            }
            catch
            {
                _udpClient.Send(msg, msg.Length, "192.168.0.37", 5035);
            }
        }
    }
}