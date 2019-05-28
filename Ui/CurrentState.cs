using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;

namespace UI
{
    public class CurrentState : IAppState
    { 
        public IAppState _state;

        public IAppState State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void Draw(RenderWindow window)
        {
            _state.Draw(window);
        }

        public void Update(RenderWindow window)
        {
            _state.Update(window);
        }
    }
}