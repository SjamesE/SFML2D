using SFML.Graphics;
using SFML2D.Core.UI;

namespace SFML2D.Core
{
    internal class Scene
    {
        public string name { get; private set; }
        public int sceneIndex { get; private set; }
        public List<GameObject> gameObjects { get; private set; }
        public List<UIObject> uiObjects { get; set; }
        public Camera mainCamera { get; private set; }

        public Scene(RenderWindow window, string name, int index)
        {
            this.name = name;
            sceneIndex = index;
            gameObjects = new List<GameObject>();
            uiObjects = new List<UIObject>();
            mainCamera = new Camera(window);
        }

        public void AddGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public bool RemoveGameObject(GameObject gameObject)
        {
            return gameObjects.Remove(gameObject);
        }

        public void AddUIObject(UIObject uiObject)
        {
            uiObjects.Add(uiObject);
        }

        public bool RemoveUIObject(UIObject uiObject)
        {
            return uiObjects.Remove(uiObject);
        }
    }
}
