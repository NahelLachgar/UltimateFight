using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
<<<<<<< HEAD
=======
using Model;
using Newtonsoft.Json;
>>>>>>> c024e1faa1940fad830c75c797bfc6323258e1b0

namespace Model
{
    public class Server
    {
        public Game _game;
        internal static Thread _ListenTh;
        internal static bool _isListening = true;

<<<<<<< HEAD
        public Server(Game game)
        {
            _game = game;
        }
        internal void StartServer()
=======
        public Server (Game game) {
            _game = game;
        }
        internal void StartServer()       
>>>>>>> c024e1faa1940fad830c75c797bfc6323258e1b0
        {
            //Préparation et démarrage du thread en charge d'écouter.
            _ListenTh = new Thread(new ThreadStart(Listen));
            _ListenTh.Start();
        }

<<<<<<< HEAD
        internal void Listen()
=======
        internal  void Listen()
>>>>>>> c024e1faa1940fad830c75c797bfc6323258e1b0
        {
            UdpClient server = new UdpClient(5035);


            //Création d'une boucle infinie qui aura pour tâche d'écouter.
            while (_isListening)
            {
                //On crée le serveur en lui spécifiant le port sur lequel il devra écouter.

                //Création d'un objet IPEndPoint qui recevra les données du Socket distant.
                IPEndPoint client = null;
                //On écoute jusqu'à recevoir un message.
                byte[] data = server.Receive(ref client);
                string key = Encoding.Default.GetString(data);
                Send(key);
            }
        }
<<<<<<< HEAD
        internal void Send(string key)
        {
=======
        internal void Send(string key) {
>>>>>>> c024e1faa1940fad830c75c797bfc6323258e1b0

            _game._controls.Update(key);
            //Console.WriteLine(key);
        }
    }
}