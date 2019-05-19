using Model;
using Newtonsoft.Json;
using SFML.Window;
using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;


namespace Model
{
    static public class Client
    {

        static public void SendKey(Keyboard.Key key, Game game)
        {
            UdpClient _udpClient = new UdpClient();
            KeyPress keyPress = new KeyPress(game, key);

            string toSend = JsonConvert.SerializeObject(keyPress);

            byte[] msg = Encoding.Default.GetBytes(toSend);

            _udpClient.Send(msg, msg.Length, "192.168.0.37", 5035);
            _udpClient.Close();
        }   
    }
}