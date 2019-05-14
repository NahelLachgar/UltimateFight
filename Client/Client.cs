using System;
using System.Net.Sockets;
using System.Text;

namespace UltimateFight
{
    public class Program
    {
        private static void Main(string[] args)
        {
            bool @continue = true; 

            while (@continue)
            {
                Console.Write("\nAppuyez une touche : ");
                ConsoleKey key = Console.ReadKey().Key;
                //Sérialisation du message en tableau de bytes.
                byte[] msg = Encoding.Default.GetBytes(key.ToString());

                UdpClient udpClient = new UdpClient();

                //La méthode Send envoie un message UDP.
                udpClient.Send(msg, msg.Length, "10.8.110.207", 5035);

                udpClient.Close();
            }
        }
    }
}