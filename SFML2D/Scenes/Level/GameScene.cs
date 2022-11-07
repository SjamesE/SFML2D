using SFML.Graphics;
using SFML2D.Core;

namespace SFML2D.Scenes.Level
{
    internal class GameScene
    {
        public readonly int sceneIndex = 1;

        private Scene gameScene;

        private GameObject player;

        public GameScene(RenderWindow window)
        {
            gameScene = new Scene(window, "GameScene", sceneIndex);

            player = new GameObject("Player");
            SpriteRenderer sr = new SpriteRenderer(player, new Texture(1, 1));
            player.AddComponent(sr);

            // TODO

        }
    }
}
