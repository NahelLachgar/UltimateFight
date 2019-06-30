using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Model
{
    static public class Client
    {
        static public void SendKey(string key)
        {
            TcpClient tcpclnt = new TcpClient();

            tcpclnt.Connect("127.0.0.1", 8001);

            // use the ipaddress as in the server program

            Stream stm = tcpclnt.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(key);

            stm.Write(ba, 0, ba.Length);


            tcpclnt.Close();
        }

       /* static internal void ReceiveFromServer()
        {
            Stream stm = tcpclnt.GetStream();

            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);

            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(bb[i]));
        }*/
    }
}