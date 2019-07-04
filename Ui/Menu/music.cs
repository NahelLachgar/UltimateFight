using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Model;
using SFML.Audio;

namespace UI
{
    public class Sound
    {

        public Music _musicMenu = new Music("../../../../img/Menu/music1.wav");
        public Music _musicGame = new Music("../../../../img/Menu/music2.wav");
        public Music _goku = new Music("../../../../img/Menu/kamehameha.wav");

        public Music _currentSound;
        public Music _currentMusic = new Music("../../../../img/Menu/music2.wav");

        public Sound()
        {
            _currentMusic.Loop = true;
            _currentMusic.Volume = 100;
        }


    }
}
