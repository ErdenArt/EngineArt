using System;
using EngineArt.Drawings;

namespace EngineArt
{
    /// <summary>
    /// Represents a rectangular collision boundary used to detect intersections and containment with points or other
    /// colliders.
    /// </summary>
    /// <remarks>The <see cref="Collider"/> class provides methods and properties for defining and
    /// manipulating axis-aligned bounding boxes (AABBs) in 2D space. It is used
    /// for collision detection between objects or for determining whether a point lies within a specified area. <para>
    /// Colliders can be updated to match the position and size of game objects or sprites, and provide utility methods
    /// for intersection and containment checks. </para></remarks>
    public class Collider : GameObject
    {
        /// <summary>
        /// Collider with no propeties
        /// </summary>
        public static Collider Empty = new Collider();

        private float endX;
        private float endY;
        private float width;
        private float height;
        
        public float Rotation;
        /// <summary>X position of center of Position</summary>
        public float X;
        /// <summary>Y position of center of Position</summary>
        public float Y;
        /// <summary>Width of collider </summary>
        public float Width { get => width; set => width = value; }
        /// <summary>Height of collider</summary>
        public float Height { get => height; set => height = value; }


        /// <summary>Gets the Y-coordinate of the top edge of the rectangle.</summary>
        public float Top { get => Y - Height / 2; }
        /// <summary> Gets the X-coordinate of the right edge of the rectangle.</summary>
        public float Right { get => X + Width / 2; }
        /// <summary>Gets the X-coordinate of the left edge of the rectangle.</summary>
        public float Left { get => X - Width / 2; }
        /// <summary> Gets the Y-coordinate of the bottom edge of the rectangle. </summary>
        public float Bottom { get => Y + Height / 2; }
        /// <summary>
        /// Updates the position and size of the object based on the specified coordinates and dimensions.
        /// </summary>
        /// <param name="pos">The new center position of the object as a <see cref="Vector2"/>.</param>
        /// <param name="size">The new size of the object as a <see cref="Vector2"/>.</param>
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
        /// <summary>
        /// Updates the position and size of the bounding box based on the specified sprite and optional additional
        /// position and size offsets.
        /// </summary>
        /// <param name="sprite">The <see cref="Sprite"/> whose position, texture size, and scale are used to calculate the bounding box.
        /// Cannot be <c>null</c>.</param>
        /// <param name="addictionalPos">An optional offset to add to the sprite's position when determining the bounding box location. The default
        /// is <see cref="Vector2.Zero"/>.</param>
        /// <param name="addictionalSize">An optional offset to add to the calculated width and height of the bounding box. The default is <see
        /// cref="Vector2.Zero"/>.</param>
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
        /// <summary>
        /// Determines whether the specified point is contained within the bounds of this rectangle.
        /// </summary>
        /// <param name="point">The point to test for containment within the rectangle.</param>
        /// <returns>— <see langword="true"/> if the specified point lies within or on the edges of the rectangle; otherwise,
        /// <see langword="false"/>.</returns>
        public bool Contains(Vector2 point)
        {
            return X <= point.X &&
                   Y <= point.Y &&
                   X + width >= point.X &&
                   Y + height >= point.Y;
        }
        /// <summary>
        /// Determines whether the specified point is contained within the given collider's bounds.
        /// </summary>
        /// <param name="collider">The collider to test for containment. Cannot be <see langword="null"/>.</param>
        /// <param name="point">The point, in world coordinates, to test for inclusion within the collider.</param>
        /// <returns><see langword="true"/> if the specified point is inside the collider's bounds; otherwise, <see
        /// langword="false"/>.</returns>
        static public bool Contains(Collider collider, Vector2 point)
        {
            return collider.Contains(point);
        }
        /// <summary>
        /// Determines whether this collider intersects with the specified collider.
        /// </summary>
        /// <param name="collider">The collider to test for intersection with this instance. Cannot be <c>null</c>.</param>
        /// <returns><see langword="true"/> if this collider intersects with the specified <paramref name="collider"/>;
        /// otherwise, <see langword="false"/>.</returns>
        public bool Intersects(Collider collider)
        {
            return IsIntersecting1D(this.X, this.X + Width, collider.X, collider.X + collider.Width) &&
                   IsIntersecting1D(this.Y, this.Y + Height, collider.Y, collider.Y + collider.Height);
        }
        bool IsIntersecting1D(float xmin1, float xmax1, float xmin2, float xmax2)
        {
            return xmax1 > xmin2 && xmax2 > xmin1;
        }
        /// <summary>
        /// Converts the current instance to a <see cref="Rectangle"/> by rounding the position and size values to the
        /// nearest integers.
        /// </summary>
        /// <returns>A <see cref="Rectangle"/> whose location and size correspond to the rounded values of this instance's
        /// coordinates and dimensions.</returns>
        public Rectangle ToRectangle()
        {
            return new Rectangle((int)Math.Round(X), (int)Math.Round(Y), (int)Math.Round(width), (int)Math.Round(height));
        }
        /// <summary>
        /// Draws the outline of the collider using the specified color and line width.
        /// </summary>
        /// <remarks>This method visually represents the collider's bounds by drawing an empty rectangle.
        /// It is typically used for debugging or visualization purposes.</remarks>
        /// <param name="color">The color to use for the collider outline. If not specified, <see cref="Color.Red"/> is used.</param>
        /// <param name="width">The width, in pixels, of the outline. Must be greater than 0. The default value is 1.</param>
        public void DrawCollider(Color color = default, int width = 1)
        {
            if (color == default) color = Color.Red;

            Shape.DrawEmptyBox(this.ToRectangle(), color, width);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Collider"/> class.
        /// </summary>
        /// <remarks>Use this constructor to create a new collider for use in physics simulations or
        /// collision detection systems.</remarks>
        public Collider()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Collider"/> class with already seted up variabels.
        /// </summary>
        /// <param name="x">Position X of center</param>
        /// <param name="y">Position Y of center</param>
        /// <param name="width">Width of collider</param>
        /// <param name="height">Height of collider</param>
        public Collider(float x, float y, float width, float height)
        {
            this.X = x;
            this.Y = y;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Displays position and size of <see cref="Collider"/> 
        /// </summary>
        /// <returns>In order: X position, Y position, Width, Height</returns>
        public override string ToString()
        {
            return $"({X}, {Y}, {Width}, {Height})";
        }
    }
}