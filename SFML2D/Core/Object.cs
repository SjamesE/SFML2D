namespace SFML2D.Core
{
    internal abstract class Object
    {
        public string name;
        public Object? parent;
        public List<Object> children;
        public Transform Transform { get; private set; }
        public bool isActive = true;
        private List<Component> components = new List<Component>();

        public Object(string name, Object? parent = null)
        {
            this.name = name;

            Transform = new Transform(this);
            components.Add(Transform);
            children = new List<Object>();

            if (parent != null)
            {
                parent.children.Add(this);
                this.parent = parent;
            }
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (var component in components)
            {
                if (component is T value)
                    return value;
            }
            throw new NullReferenceException("No component was found of type " + typeof(T));
        }

        public T? LookForComponent<T>() where T : Component
        {
            foreach (var component in components)
            {
                if (component is T value)
                    return value;
            }
            return null;
        }
    }
}
