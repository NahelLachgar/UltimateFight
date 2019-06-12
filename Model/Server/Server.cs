using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Model
{
    public class Server
    {
        public Game _game;
        internal static Thread _ListenTh;
        internal static bool _isListening = true;
        IPAddress _ipAd;
        TcpListener _server;
        Socket _s;


        public Server(Game game, string hostIP)
        {
            _game = game;
            _ipAd = IPAddress.Parse(hostIP);
            _server = new TcpListener(_ipAd, 8001);

            //_server = new UdpClient(5035);

        }
        internal void Start()
        {
            _server.Start();
            //s.RemoteEndPoint)
        }


        internal void Receive()
        {

            _s = _server.AcceptSocket();


            byte[] b = new byte[100];

            int k = _s.Receive(b);
                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(b[i]));

                ASCIIEncoding asen = new ASCIIEncoding();



            //Send a message to the client
            _s.Send(asen.GetBytes("The string was recieved by the server."));
            _game._controls.Update("Q");
            
        }

        internal void Stop()
        {
            /* clean up */
            _s.Close();
            _server.Stop();
        }

    }
}