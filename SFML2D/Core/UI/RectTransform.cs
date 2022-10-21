using SFML.Graphics;
using SFML2D.Generics;

namespace SFML2D.Core.UI
{
    internal class RectTransform
    {
        public enum HAlign
        {
            none,
            left,
            center,
            right
        }
        public enum VAlign
        {
            none,
            top,
            center,
            bottom
        }

        public Vector2i pos;
        public Vector2i size;
        public HAlign hAlign;
        public VAlign vAlign;
        public Vector2i center;

        private RenderWindow window;

        public RectTransform(RenderWindow window, Vector2i size, HAlign ha = HAlign.center, VAlign va = VAlign.center)
        {
            this.size = size;
            this.window = window;
            hAlign = ha;
            vAlign = va;
            UpdatePos();
            center = new Vector2i(pos.x + size.x / 2, pos.y + size.y / 2);
        }

        public RectTransform(RenderWindow window, Vector2i pos, Vector2i size)
        {
            this.size = size;
            this.window = window;
            hAlign = HAlign.none;
            vAlign = VAlign.none;
            center = new Vector2i(pos.x + size.x / 2, pos.y + size.y / 2);
            this.pos = pos;
        }

        private void UpdatePos()
        {
            switch (hAlign)
            {
                case HAlign.none:
                    break;
                case HAlign.left:
                    pos.x = 0;
                    break;
                case HAlign.center:
                    pos.x = (int)window.Size.X / 2 - size.x / 2;
                    break;
                case HAlign.right:
                    pos.x = (int)window.Size.X - size.x;
                    break;
                default:
                    break;
            }
            switch (vAlign)
            {
                case VAlign.none:
                    break;
                case VAlign.top:
                    pos.y = 0;
                    break;
                case VAlign.center:
                    pos.y = (int)window.Size.Y / 2 - size.y / 2;
                    break;
                case VAlign.bottom:
                    pos.y = (int)window.Size.Y - size.y;
                    break;
                default:
                    break;
            }
        }
    }
}
