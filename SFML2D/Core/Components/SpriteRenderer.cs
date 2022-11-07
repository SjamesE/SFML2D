using SFML.Graphics;
using SFML.System;
using SFML2D.Generics;

namespace SFML2D.Core
{
    internal class SpriteRenderer : Component
    {
        public Texture texture { get; set; }
        public Sprite Sprite { get; private set; }
        public Color Color { get; set; }

        public SpriteRenderer(GameObject gameObject, Texture texture) : base(gameObject)
        {
            this.texture = texture;

            Sprite = new Sprite(texture);
        }

        public void SetTexture(Texture texture)
        {
            Sprite.Texture = texture;
        }

        public void Render(RenderWindow window, Vector2 offset)
        {
            Sprite.Position = new Vector2f(transform.pos.x - offset.x, transform.pos.y - offset.y);
            Sprite.Scale = new Vector2f(transform.scale.x, transform.scale.y);
            Sprite.Rotation = transform.rotation;
            Sprite.Color = Color;
            window.Draw(Sprite);
        }
    }
}
