using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    internal class AvatarCharacter
    {

        Dictionary<string, Texture> _avatar = new Dictionary<string, Texture>();
        Dictionary<string, Texture> _character = new Dictionary<string, Texture>();

        internal AvatarCharacter()
        {
            _avatar = LoadAvatar();
            _character = LoadCharacter();
        }

        private Dictionary<string, Texture> LoadCharacter()
        {
            Dictionary<string, Texture> load = new Dictionary<string, Texture>();

            load.Add("Chun-li", new Texture("../../../../img/Characters/Avatar/Character/Chun-li.png"));
            load.Add("Balrog", new Texture("../../../../img/Characters/Avatar/Character/Balrog.png"));
            load.Add("Ryu", new Texture("../../../../img/Characters/Avatar/Character/Ryu.png"));
            load.Add("Bison", new Texture("../../../../img/Characters/Avatar/Character/Bison.png"));
            load.Add("Sagat", new Texture("../../../../img/Characters/Avatar/Character/Sagat.png"));
            load.Add("Goku", new Texture("../../../../img/Characters/Avatar/Character/Goku.png"));
            load.Add("16", new Texture("../../../../img/Characters/Avatar/Character/16.png"));
            load.Add("Subzero", new Texture("../../../../img/Characters/Avatar/Character/Subzero.png"));

            return load;
        }

        private Dictionary<string, Texture> LoadAvatar()
        {
            Dictionary<string, Texture> load = new Dictionary<string, Texture>();

            load.Add("Chun-li", new Texture("../../../../img/Characters/Avatar/Avatar/Chun-li.png"));
            load.Add("Balrog", new Texture("../../../../img/Characters/Avatar/Avatar/Balrog.png"));
            load.Add("Ryu", new Texture("../../../../img/Characters/Avatar/Avatar/Ryu.png"));
            load.Add("Bison", new Texture("../../../../img/Characters/Avatar/Avatar/Bison.gif"));
            load.Add("Sagat", new Texture("../../../../img/Characters/Avatar/Avatar/Sagat.png"));
            load.Add("Goku", new Texture("../../../../img/Characters/Avatar/Avatar/Goku.png"));
            load.Add("16", new Texture("../../../../img/Characters/Avatar/Avatar/16.png"));
            load.Add("Subzero", new Texture("../../../../img/Characters/Avatar/Avatar/Subzero.png"));



            return load;
        }

        internal Dictionary<string, Texture> Avatar => _avatar;

        internal Dictionary<string, Texture> Character => _character;

    }
}
