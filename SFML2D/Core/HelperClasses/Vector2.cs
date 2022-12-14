using SFML.System;

namespace SFML2D.Generics
{
    internal struct Vector2
    {
        public static readonly Vector2 zero = new Vector2(0, 0);
        public static readonly Vector2 one = new Vector2(1, 1);
        public float x { get; set; }
        public float y { get; set; }
        public Vector2f ToSFMLVector2
        {
            get
            {
                return new Vector2f(x, y);
            }
        }
        public Vector2i ToSFMLVector2i
        {
            get
            {
                return new Vector2i((int)x, (int)y);
            }
        }

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator +(Vector2 left) => left;

        public static Vector2 operator -(Vector2 left) => new Vector2(-left.x, -left.y);

        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x + right.x, left.y + right.y);
        }

        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x - right.x, left.y - right.y);
        }

        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x * right.x, left.y * right.y);
        }
        
        public static Vector2 operator *(Vector2 left, float right)
        {
            return new Vector2(left.x * right, left.y * right);
        }

        public static Vector2 operator /(Vector2 left, Vector2 right)
        {
            if (right.x == 0 || right.y == 0)
            {
                throw new DivideByZeroException();
            }
            return new Vector2(left.x / right.x, left.y / right.y);
        }

        public static Vector2 operator /(Vector2 left, float right)
        {
            return new Vector2(left.x / right, left.y / right);
        }

        public override string ToString() => $"X: {x}, Y: {y}";
    }
}
