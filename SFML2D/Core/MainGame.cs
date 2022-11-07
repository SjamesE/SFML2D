using SFML.Graphics;
using SFML2D.Scenes.Menu;

namespace SFML2D.Core
{
    internal class MainGame : Game
    {
        public override void Initialize(RenderWindow window)
        {
            MainMenu mainMenu = new MainMenu(window);
            SceneManager.Window = window;
            SceneManager.ChangeActiveScene(mainMenu.sceneIndex);
        }

        public override void Update()
        {
            //throw new NotImplementedException();
        }
    }
}
