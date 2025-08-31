using Bloom_Sack.Engine.Drawings;
using Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineArt.Engine.Drawings
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
        public Color SpriteColor = Color.White;

        public Sprite(Texture2D texture)
        {
            Texture = texture;
            TextureSource = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Debug.WriteLine(Texture.Bounds.Location);
        }
        public void Draw(float layerDepth = 0)
        {
            if (Texture == null) return;

            GLOBALS.SpriteBatch.Draw(
                texture: Texture,
                position: Position,
                sourceRectangle: TextureSource,
                color: SpriteColor,
                rotation: Rotation,
                origin: DrawOffSet,
                scale: SpriteScale,
                effects: SpriteEffects.None,
                layerDepth: layerDepth);
        }
        protected override void UpdateForParent()
        {
            
        }
    }
}
