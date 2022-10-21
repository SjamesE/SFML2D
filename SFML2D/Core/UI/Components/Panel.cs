using SFML.Graphics;
using SFML2D.Generics;

namespace SFML2D.Core.UI
{
    internal class Panel : UIComponent
    {
        public Texture texture { get; private set; }
        public Vector2i center { get; private set; }

        private Sprite sprite;
        private Color _color;
        private int _rounding;
        private int _borderSize;
        private Color _borderColor;
        public Color color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                update = true;
            }
        }
        public int rounding
        {
            get => _rounding;
            set
            {
                _rounding = value;
                update = true;
            }
        }
        public int borderSize
        {
            get => _borderSize;
            set
            {
                _borderSize = value;
                update = true;
            }
        }
        public Color borderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                update = true;
            }
        }
        private Color[,] pixels = new Color[0,0];
        private Image image = new Image(0,0);

        private bool update = false;

        public Panel(UIObject parent) : this(parent, Color.White, 0, new Color(155, 155, 155, 255), 0) { }
        public Panel(UIObject parent, Color color) : this(parent, color, 0, new Color(155, 155, 155, 255), 0) { }
        public Panel(UIObject parent, Color color, int rounding) : this(parent, color, rounding, new Color(155, 155, 155, 255), 0) { }
        public Panel(UIObject parent, int rounding, int borderSize) : this(parent, Color.White, rounding, new Color(155, 155, 155, 255), borderSize) { }

        public Panel(UIObject parent, Color color, int rounding, Color borderColor, int borderSize) : base(parent)
        {
            parent.AddComponent(this);
            sprite = new Sprite();
            texture = new Texture((uint)transform.size.x, (uint)transform.size.y);

            this.color = color;
            this.rounding = rounding;
            this.borderSize = borderSize;
            this.borderColor = borderColor;
        }

        private void Update()
        {
            if (transform.size.x <= 0 || transform.size.y <= 0) return;
            Vector2i size = parent.transform.size;
            int maxX = size.x;
            int maxY = size.y;

            // Update each pixel in the Panel
            pixels = new Color[maxX, maxY];
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    // BORDER AND ROUNDING
                    if (rounding == 0)
                    {
                        if (x < borderSize || x > size.x - borderSize - 1 || y < borderSize || y >= size.y - borderSize)
                            pixels[x, y] = new Color(150, 150, 150, 255);
                        else pixels[x, y] = color;
                    }
                    else
                    {
                        int b_r = borderSize + rounding;

                        if (x  <          borderSize && y >= b_r && y <= size.y - b_r ||
                            x >= size.x - borderSize && y >= b_r && y <= size.y - b_r ||
                            y  <          borderSize && x >= b_r && x <= size.x - b_r ||
                            y >= size.y - borderSize && x >= b_r && x <= size.x - b_r )
                            pixels[x, y] = borderColor;
                        else
                        {
                            float distance = GetDistanceFromEdge(x, y);

                            if (distance > b_r)
                                pixels[x, y] = new Color(0, 0, 0, 0);
                            else if (distance <= b_r && distance >= rounding - 1)
                            {
                                if (borderSize == 0)
                                {
                                    float distanceR = distance - rounding + 1;

                                    distanceR = Maths.Clamp(distanceR, 1);
                                    byte alpha = (byte)Maths.Lerp(0, 255, 1 - distanceR);
                                    pixels[x, y] = new Color(color.R, color.G, color.B, alpha);
                                }
                                else
                                {
                                    float distanceL = b_r - distance;
                                    float distanceR = distance - rounding + 1;

                                    if (distanceL < distanceR)
                                    {
                                        distanceL = Maths.Clamp(distanceL, 1);
                                        byte alpha = (byte)Maths.Lerp(0, 255, distanceL);
                                        pixels[x, y] = new Color(borderColor.R, borderColor.G, borderColor.B, alpha);
                                    }
                                    else
                                    {
                                        distanceR = Maths.Clamp(distanceR, 1);
                                        byte r = (byte)Maths.Lerp(borderColor.R, color.R, 1 - distanceR);
                                        byte g = (byte)Maths.Lerp(borderColor.G, color.G, 1 - distanceR);
                                        byte b = (byte)Maths.Lerp(borderColor.B, color.B, 1 - distanceR);
                                        pixels[x, y] = new Color(r, g, b, 255);
                                    }
                                }
                            }
                            else
                                pixels[x, y] = color;
                        }
                    }
                }
            }

            // Update the texture from the Pixels
            image = new Image(pixels);
            texture.Dispose();
            texture = new Texture(image);
            sprite.Texture = texture;

            // Update pos
            Vector2i pos = new Vector2i(parent.transform.pos.x, parent.transform.pos.y);
            sprite.Position = new SFML.System.Vector2f(pos.x, pos.y);
            center = new Vector2i(pos.x + size.x / 2, pos.y + size.y / 2);

            update = false;
        }

        public void Draw(RenderWindow window)
        {
            if (update) Update();

            window.Draw(sprite);
        }

        private float GetDistanceFromEdge(int x, int y)
        {
            Vector2i size = parent.transform.size;
            if (rounding == 0) return -1;
            int minSize = (size.x > size.y) ? size.y / 2 : size.x / 2;
            if (rounding > minSize)
                rounding = minSize;


            // TOP LEFT
            if (x < rounding + borderSize && y < rounding + borderSize)
            {
                return GetDistance(new Vector2(x, y), new Vector2(rounding + borderSize, rounding + borderSize)) - 1;
            }
            // BOTTOM LEFT
            if (x < rounding + borderSize && y > size.y - rounding - borderSize)
            {
                return GetDistance(new Vector2(x + 1, y), new Vector2(rounding + borderSize, size.y - (rounding + borderSize)));
            }
            // TOP RIGHT
            if (x > size.x - rounding - borderSize && y < rounding + borderSize)
            {
                return GetDistance(new Vector2(x, y + 1), new Vector2(size.x - (rounding + borderSize), rounding + borderSize));
            }
            // BOTTOM RIGHT
            if (x > size.x - rounding - borderSize && y > size.y - rounding - borderSize)
            {
                return GetDistance(new Vector2(x, y), new Vector2(size.x - (rounding + borderSize), size.y - (rounding + borderSize)));
            }

            return 0;
        }

        private float GetDistance(Vector2 left, Vector2 right)
        {
            float h = MathF.Abs(right.y - left.y);
            float v = MathF.Abs(right.x - left.x);
            return MathF.Sqrt((h * h) + (v * v));
        }
    }
}
