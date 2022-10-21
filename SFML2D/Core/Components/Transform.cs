using SFML2D.Generics;

namespace SFML2D.Core
{
    internal class Transform : Component
    {
        public Vector2 pos { get; set; }
        public float rotation { get; set; }
        public Vector2 scale { get; set; }

        public Transform(Object gameObject) : base(gameObject)
        {
            pos = new Vector2();
            rotation = 0;
            scale = new Vector2();
        }
    }
}
