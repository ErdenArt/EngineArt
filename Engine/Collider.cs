using Bloom_Sack.Engine.Drawings;
using EngineArt.Engine.Drawings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineArt.Engine
{
    public class Collider : GameObject
    {
        private float x;
        private float endX;
        private float y;
        private float endY;
        private float width;
        private float height;
        public float Width { get => width; set => width = value; }
        public float Height { get => height; set => height = value; }


        //public float Top { get => y; }
        //public float Right { get => x + Width; }
        //public float Left { get => x; }
        //public float Bottom { get => y + height; }
        public void Update(Vector2 pos, Vector2 size)
        {
            Position = pos;
            Width = size.X;
            Height = size.Y;

            x = Position.X - Width / 2;
            y = Position.Y - Height / 2;
            endX = x + Width;
            endY = y + Height;
        }
        public void UpdatePerSprite(Sprite sprite, Vector2 addictionalPos = default, Vector2 addictionalSize = default)
        {
            Position = sprite.Position + addictionalPos;
            Width = sprite.Texture.Width * sprite.SpriteScale.X + addictionalSize.X;
            Height = sprite.Texture.Height * sprite.SpriteScale.Y + addictionalSize.Y;

            x = Position.X - Width / 2;
            y = Position.Y - Height / 2;
            endX = x + Width;
            endY = y + Height;

            Debug.WriteLine(sprite.Texture.Height);
        }
        public bool Contains(Vector2 point)
        {
            return x <= point.X &&
                   y <= point.Y &&
                   x + width >= point.X &&
                   y + height >= point.Y;
        }
        static public bool Contains(Collider collider, Vector2 point)
        {
            return collider.Contains(point);
        }
        public bool Intersection(Collider collider)
        {
            return IsIntersecting1D(this.x, endX, collider.x, collider.endX)
                && IsIntersecting1D(this.y, this.endY, collider.endY, collider.endY);
        }
        bool IsIntersecting1D(float xmin1, float xmax1, float xmin2, float xmax2)
        {
            return xmax1 >= xmin2 && xmax2 >= xmin1;
        }
        protected override void UpdateForParent()
        {
            
        }
        public Rectangle ToRectangle()
        {
            return new Rectangle((int)Math.Round(x), (int)Math.Round(y), (int)Math.Round(width), (int)Math.Round(height));
        }
        public void DrawCollider(Color color = default, int width = 1)
        {
            if (color == default) color = Color.Red;

            Shape.DrawEmptyBox(this.ToRectangle(), color, width);
        }
        public Collider()
        {

        }
    }
}
