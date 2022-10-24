using SFML.Graphics;
using SFML2D.Generics;
using static SFML2D.Core.UI.RectTransform;

namespace SFML2D.Core.UI
{
    internal class UIObject
    {
        public string name { get; private set; }
        public bool isActive { get; private set; }
        public RectTransform transform { get; private set; }

        private List<UIComponent> components = new List<UIComponent>();

        public UIObject(RenderWindow window, string name, Vector2i size, HAlign hAlign = HAlign.center, VAlign vAlign = VAlign.center)
        {
            this.name = name;
            isActive = true;
            transform = new RectTransform(window, size, hAlign, vAlign);
        }

        public UIObject(RenderWindow window, string name, Vector2i pos, Vector2i size)
        {
            this.name = name;
            isActive = true;
            transform = new RectTransform(window, pos, size);
        }

        public void Draw(RenderWindow window)
        {
            foreach (UIComponent component in components)
            {
                if (component.drawable)
                {
                    component.Draw(window);
                }
            }
        }
        
        public void AddComponent(UIComponent component)
        {
            components.Add(component);
        }

        /// <summary>
        /// Get UI Component of Type T 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>UI Component</returns>
        /// <exception cref="NullReferenceException"></exception>
        public T GetComponent<T>() where T : UIComponent
        {
            foreach (var component in components)
            {
                if (component is T value)
                    return value;
            }
            throw new NullReferenceException("Component of type " + typeof(T) + " was not found.");
        }
    }
}
