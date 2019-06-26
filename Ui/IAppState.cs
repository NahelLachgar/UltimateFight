
using SFML.Graphics;


namespace UI
{
    public interface IAppState
    {
        IAppState _nextState { get; set; }

        void Draw(RenderWindow window);

        IAppState Update(RenderWindow window);
    }
}