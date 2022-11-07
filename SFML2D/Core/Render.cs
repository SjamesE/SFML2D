using SFML.Graphics;
using SFML2D.Core.UI;

namespace SFML2D.Core
{
    internal class Render
    {
        RenderWindow window;

        public Render(RenderWindow window)
        {
            this.window = window;
        }

        public void Draw(Scene scene)
        {
            window.Clear();

            scene.mainCamera.Draw(window, scene);

            foreach (UIObject obj in scene.uiObjects)
            {
                obj.Draw(window);
            }

            window.Display();
        }
    }
}
