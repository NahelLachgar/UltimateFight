using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UltimateFight
{
    public class Program
    {
        private static Thread _thListen;

        private static void Main(string[] args)
        {
            //Préparation et démarrage du thread en charge d'écouter.
            _thListen = new Thread(new ThreadStart(Listen));
            _thListen.Start();
        }

        private static void Listen()
        {

            //On crée le serveur en lui spécifiant le port sur lequel il devra écouter.
            UdpClient server = new UdpClient(5035);

            //Création d'une boucle infinie qui aura pour tâche d'écouter.
            while (true)
            {
                //Création d'un objet IPEndPoint qui recevra les données du Socket distant.
                IPEndPoint client = null;
                Console.WriteLine("ÉCOUTE...");

                //On écoute jusqu'à recevoir un message.
                byte[] data = server.Receive(ref client);
                Console.WriteLine("Données reçues en provenance de {0}:{1}.", client.Address, client.Port);

                //Décryptage et affichage du message.
                string message = Encoding.Default.GetString(data);
                Console.WriteLine("CONTENU DU MESSAGE : {0}\n", message);
            }
        }
    }
}