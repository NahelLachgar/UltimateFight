using System;
using System.Collections.Generic;
using System.Text;
using Model;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Model
{
    public class Input
    {

        public string WriteAdressIP(RenderWindow window)
        {
            string letter = "";
            window.KeyReleased += (sender, e) => Write(e);

            void Write(KeyEventArgs e)
            {
                Console.WriteLine("Touche selectionnée : " + e.Code);
                letter = e.Code.ToString();
            }
            return letter;
        }



    }
}
