using SFML.Graphics;

namespace SFML2D.Core.UI
{
    internal abstract class UIComponent
    {
        public UIObject parent { get; protected set; }
        public RectTransform transform { get; protected set; }
        public bool drawable { get; protected set; }

        public UIComponent(UIObject parent)
        {
            this.parent = parent;
            transform = parent.transform;
        }

        public abstract void Draw(RenderWindow window);
    }
}
