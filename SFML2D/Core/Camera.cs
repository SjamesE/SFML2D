using SFML.Graphics;
using SFML2D.Generics;

namespace SFML2D.Core
{
    internal class Camera : Object
    {
        public Transform transform;

        public Camera(RenderWindow window) : base("MainCamera")
        {
            transform = new Transform(this);

            transform.scale = new Vector2(window.Size.X, window.Size.Y);
        }

        public void Draw(RenderWindow window, Scene scene)
        {
            foreach (var go in scene.gameObjects)
            {
                SpriteRenderer? sr = go.LookForComponent<SpriteRenderer>();

                if (sr == null) return;

                if (IsPointInView(go.Transform.pos))
                {
                    sr.Render(window, transform.pos);
                }
            }
        }

        /// <summary>
        /// Check if point lies inside of the viewport +- 10
        /// </summary>
        private bool IsPointInView(Vector2 point)
            => (point.x > transform.pos.x - 10 && point.y > transform.pos.y - 10) &&
               (point.x < transform.pos.x + transform.scale.x + 10 && point.y < transform.pos.y + transform.scale.y + 10);
    }
}
