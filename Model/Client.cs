using System;
using System.Net.Sockets;
using System.Text;

namespace Model
{
    public class Client
    {
        UdpClient _udpClient = new UdpClient();

        internal static void SendKey(ConsoleKey key)
        {
            while(true)
            {
                //Console.Write("\nAppuyez sur une touche : ");

                //ConsoleKey key = Console.ReadKey().Key;

                byte[] msg = Encoding.Default.GetBytes(key.ToString());
                _udpClient.Send(msg, msg.Length, "10.8.110.207", 5035);

            }
        }
    }
}