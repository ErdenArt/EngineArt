using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Mathematic;
using System.Diagnostics;

namespace Engine.Drawings
{
    public class SpriteOLD
    {
        public Texture2D texture;
        public Vector2 position = Vector2.Zero;
        public Vector2 offSet = Vector2.Zero;
        public Vector2Int textureSize = Vector2Int.Zero;
        public float spriteSizeScale = 1f;
        public bool isVisible = true;
        public Point drawPosition => position.ToPoint();

        public Color spriteColor = Color.White;
        public Rectangle spriteBounds { get => new Rectangle(drawPosition.X - textureSize.X / 2, drawPosition.Y - textureSize.Y / 2, textureSize.Width, textureSize.Height); }
        public SpriteOLD()
        {
        }
        public SpriteOLD(Texture2D texture)
        {
            this.texture = texture;
            this.position = Vector2.Zero;
            textureSize = (Vector2Int)texture.Bounds.Size;
        }
        public SpriteOLD(Texture2D texture, Vector2 position, Vector2 offSet = default)
        {
            this.texture = texture;
            this.position = position;
            textureSize = (Vector2Int)texture.Bounds.Size;
            this.offSet = offSet;
        }
        public SpriteOLD(Texture2D texture, Point position)
        {
            this.texture = texture;
            this.position = position.ToVector2();
            textureSize = (Vector2Int)texture.Bounds.Size;
        }
        public SpriteOLD(Vector2 position)
        {
            this.position = position;
        }
        public virtual void DrawFromTopLeft()
        {
            //From Top-Left corner of position
            //For me it's easier to draw things from center
            //So it will probably will never be used
            //But it't good to have it
            if (isVisible == false)
                return;
            GLOBALS.SpriteBatch.Draw(texture,
                             new Rectangle(drawPosition.X,
                                           drawPosition.Y,
                                           textureSize.X,
                                           textureSize.Y),
                             spriteColor);
        }
        public virtual void Draw()
        {
            if (isVisible == false)
                return;
            //From Center of position
            GLOBALS.SpriteBatch.Draw(
                              texture,
                              new Vector2(position.X - textureSize.X / 2,
                                           position.Y - textureSize.Y / 2),
                              new Rectangle(0, 0, textureSize.X, textureSize.Y),
                              spriteColor);
        }
        public virtual void DrawVector()
        {
            if (isVisible == false)
                return;
            //From Center of position
            GLOBALS.SpriteBatch.Draw(texture,
                             new Vector2(drawPosition.X - textureSize.X / 2 + offSet.X,
                                           drawPosition.Y - textureSize.Y / 2 + offSet.Y),
                             spriteColor);
        }
        public virtual void Draw(Texture2D texture)
        {
            if (isVisible == false)
                return;
            //From Center of position
            GLOBALS.SpriteBatch.Draw(texture,
                             new Rectangle(drawPosition.X - textureSize.X / 2,
                                           drawPosition.Y - textureSize.Y / 2,
                                           textureSize.X,
                                           textureSize.Y),
                             spriteColor);
        }


        float minZ = -1000f;
        float maxZ = 1000f;
        public virtual void Draw(Rectangle source, Color color = default, float drawOrder = 0)
        {
            if (isVisible == false)
                return;
            if (color == default)
                color = spriteColor;
            //if (source == default)
            //    source = new Rectangle(0, 0, texture.Width, texture.Height);

            // layerDepth musi być od 0f do 1f
            float layerDepth = 1f - Math.Clamp((drawOrder - minZ) / (maxZ - minZ), 0f, 1f);
            //From Center of position
            GLOBALS.SpriteBatch.Draw(
                             texture,
                             new Vector2((position.X + offSet.X - textureSize.X / 2), (position.Y + offSet.Y - textureSize.Y / 2)),
                             source,
                             color,
                             0f,
                             Vector2.Zero,
                             spriteSizeScale,
                             SpriteEffects.None,
                             layerDepth);
        }
        public static void Draw(Texture2D texture, Vector2 position, Color color)
        {
            Point spriteSize = texture.Bounds.Size;
            GLOBALS.SpriteBatch.Draw(texture,
                             new Vector2(position.X - spriteSize.X / 2,
                                         position.Y - spriteSize.Y / 2),
                             color);
        }
    }
}
