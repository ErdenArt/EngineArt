using EngineArt.Drawings;

namespace EngineArt
{
    public class Collider : GameObject
    {
        public static Collider Empty = new Collider();

        public float X;
        private float endX;
        public float Y;
        private float endY;
        private float width;
        private float height;
        public float Width { get => width; set => width = value; }
        public float Height { get => height; set => height = value; }


        public float Top { get => Y - Height / 2; }
        public float Right { get => X + Width / 2; }
        public float Left { get => X - Width / 2; }
        public float Bottom { get => Y + Height / 2; }
        public void Update(Vector2 pos, Vector2 size)
        {
            Position = pos;
            Width = size.X;
            Height = size.Y;

            X = Position.X - Width / 2;
            Y = Position.Y - Height / 2;
            endX = X + Width;
            endY = Y + Height;
        }
        public void UpdatePerSprite(Sprite sprite, Vector2 addictionalPos = default, Vector2 addictionalSize = default)
        {
            Position = sprite.Position + addictionalPos;
            Width = sprite.Texture.Width * sprite.SpriteScale.X + addictionalSize.X;
            Height = sprite.Texture.Height * sprite.SpriteScale.Y + addictionalSize.Y;

            X = Position.X - Width / 2;
            Y = Position.Y - Height / 2;
            endX = X + Width;
            endY = Y + Height;

        }
        public bool Contains(Vector2 point)
        {
            return X <= point.X &&
                   Y <= point.Y &&
                   X + width >= point.X &&
                   Y + height >= point.Y;
        }
        static public bool Contains(Collider collider, Vector2 point)
        {
            return collider.Contains(point);
        }
        public bool Intersects(Collider collider)
        {
            return IsIntersecting1D(this.X, this.X + Width, collider.X, collider.X + collider.Width) &&
                   IsIntersecting1D(this.Y, this.Y + Height, collider.Y, collider.Y + collider.Height);
        }
        bool IsIntersecting1D(float xmin1, float xmax1, float xmin2, float xmax2)
        {
            return xmax1 > xmin2 && xmax2 > xmin1;
        }
        protected override void UpdateForParent()
        {
            
        }
        public Rectangle ToRectangle()
        {
            return new Rectangle((int)Math.Round(X), (int)Math.Round(Y), (int)Math.Round(width), (int)Math.Round(height));
        }
        public void DrawCollider(Color color = default, int width = 1)
        {
            if (color == default) color = Color.Red;

            Shape.DrawEmptyBox(this.ToRectangle(), color, width);
        }
        public Collider()
        {

        }
        public Collider(float x, float y, float width, float height)
        {
            
            this.X = x;
            this.Y = y;
            this.width = width;
            this.height = height;
        }
        public override string ToString()
        {
            return $"({X}, {Y}, {Width}, {Height})";
        }
    }
}
