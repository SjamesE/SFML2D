using SFML.Graphics;

namespace SFML2D.Core
{
    internal static class SceneManager
    {
        public static RenderWindow Window;
        private static List<Scene> scenes;
        public static int ActiveSceneIndex { get; private set; }

        static SceneManager()
        {
            scenes = new List<Scene>();
        }

        public static Scene GetActiveScene()
        {
            if (scenes.Count == 0) throw new InvalidOperationException("No scene exists.");
            return scenes[ActiveSceneIndex];
        }

        public static Scene GetScene(int index)
        {
            if (index > scenes.Count - 1 || index < 0)
                throw new ArgumentException("Scene index out of bounds");
            return scenes.ElementAt(index);
        }

        public static Scene CreateScene(string name)
        {
            scenes.Add(new Scene(Window, name, scenes.Count));
            return scenes.ElementAt(scenes.Count - 1);
        }

        public static void DeleteScene(int index)
        {
            if (index > scenes.Count - 1 || index < 0)
                throw new ArgumentException("Scene index out of bounds");
            scenes.RemoveAt(index);
        }

        public static void ChangeActiveScene(int index)
        {
            if (index > scenes.Count - 1 || index < 0)
                throw new ArgumentException("Scene index out of bounds");

            ActiveSceneIndex = index;
        }
    }
}
