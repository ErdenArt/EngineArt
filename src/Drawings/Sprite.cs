using EngineArt.Mathematic;

namespace EngineArt.Drawings
{
    public class Sprite : GameObject
    {
        public Texture2D Texture;
        public Rectangle TextureSource;
        public float Rotation;
        /// <summary>
        /// If you rotate sprite it will rotate around thier position. Changing it moves it from origin(Position)
        /// </summary>
        public Vector2 DrawOffSet { get => Texture.Bounds.Size.ToVector2() / 2; }
        public Vector2 SpriteScale = Vector2.One;

        public Vector2Int SingleFrameSize = Vector2Int.Zero;
        public Color SpriteColor = Color.White;
        public bool IsVisible = true;

        public Sprite(Texture2D texture)
        {
            Texture = texture;
            TextureSource = new Rectangle(0, 0, Texture.Width, Texture.Height);
        }
        public virtual void Draw(float layerDepth = 0)
        {
            if (Texture == null && IsVisible == false) return;

            GLOBALS.SpriteBatch.Draw(
                texture: Texture,
                position: Position,
                sourceRectangle: TextureSource,
                color: SpriteColor,
                rotation: Rotation,
                origin: DrawOffSet,
                scale: SpriteScale,
                effects: SpriteEffects.None,
                layerDepth: LayerDepthHelper(layerDepth));
        }
        public virtual void DrawFrame(Rectangle source ,float layerDepth = 0)
        {
            if (Texture == null && IsVisible == false) return;

            GLOBALS.SpriteBatch.Draw(
                texture: Texture,
                position: Position,
                sourceRectangle: source,
                color: SpriteColor,
                rotation: Rotation,
                origin: source.Size.ToVector2() / 2,
                scale: SpriteScale,
                effects: SpriteEffects.None,
                layerDepth: LayerDepthHelper(layerDepth));
        }


        // Values for LayerDepthHelper
        static float min = -3000f;
        static float max = 3000f;
        public static void ChangeMinMaxDrawRange(float min, float max)
        {
            Sprite.min = min; 
            Sprite.max = max;
        }
        /// <summary>
        /// Calculates the layer depth value based on the specified draw layer, normalized within a defined range.
        /// </summary>
        /// <remarks>The method ensures that the returned value is clamped between 0 and 1, providing a
        /// consistent depth calculation within the range defined by the internal <c>min</c> and <c>max</c>
        /// values.</remarks>
        /// <param name="drawLayer">The draw layer value to normalize. Typically represents the layer's position within the range.</param>
        /// <returns>A normalized layer depth value between 0 and 1, where 0 corresponds to drawing to the bottom and 1 corresponds
        /// to drawing on the top.</returns>
        float LayerDepthHelper(float drawLayer)
        {
            return (1f - Math.Clamp((drawLayer - min) / (max - min), 0f, 1f));
        }
        protected override void UpdateForParent()
        {

        }
    }
}
