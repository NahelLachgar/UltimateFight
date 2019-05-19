using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Model;

namespace Server
{
    public class Server
    {
        internal static Thread _ListenTh;
        internal static bool _isListening = true;

        internal static void StartServer()
        {
            //Préparation et démarrage du thread en charge d'écouter.
            _ListenTh = new Thread(new ThreadStart(Listen));
            _ListenTh.Start();
        }

        internal static void Listen()
        {
            //Console.WriteLine("Préparation à l'écoute...");

            //On crée le serveur en lui spécifiant le port sur lequel il devra écouter.
            UdpClient server = new UdpClient(5035);

            //Création d'une boucle infinie qui aura pour tâche d'écouter.
            while (_isListening)
            {
                //Création d'un objet IPEndPoint qui recevra les données du Socket distant.
                IPEndPoint client = null;

                //On écoute jusqu'à recevoir un message.
                byte[] data = server.Receive(ref client);
                string message = Encoding.Default.GetString(data);
                KeyPress key = JsonConvert.DeserializeObject<KeyPress>(message);
            }
        }
    }
}