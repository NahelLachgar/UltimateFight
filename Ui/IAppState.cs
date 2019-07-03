
using SFML.Graphics;


namespace UI
{
    public interface IAppState
    {
        void Draw(RenderWindow window);

        IAppState Update(RenderWindow window);
    }
}