using EngineArt.Mathematic;
using System.Diagnostics;

namespace EngineArt.Drawings.UI
{
    public class UINiceSlice : UIElement
    {
        public Atlas textureAtlas;
        Vector2Int cornerSize;
        Vector2Int boxSize;
        public Color BackgroundColor = Color.White;

        public UINiceSlice(Vector2Int position, Vector2Int size, Texture2D texture)
        {
            Bounds = new Rectangle(position, size);
            textureAtlas = new Atlas(texture, (Vector2Int)texture.Bounds.Size / 3);
            boxSize = size;
            cornerSize = (Vector2Int)textureAtlas.FirstTexture().Bounds.Size;
        }

        public override void Draw()
        {
            if (!Visible)
                return;

            GLOBALS.SpriteBatch.Draw(textureAtlas.GetTexture(0), new Rectangle(FinalBounds.X, FinalBounds.Y, cornerSize.X, cornerSize.Y), BackgroundColor);
            GLOBALS.SpriteBatch.Draw(textureAtlas.GetTexture(1), new Rectangle(FinalBounds.X + cornerSize.X, FinalBounds.Y, boxSize.X - cornerSize.X * 2, cornerSize.Y), BackgroundColor);
            GLOBALS.SpriteBatch.Draw(textureAtlas.GetTexture(2), new Rectangle(FinalBounds.X + boxSize.X - cornerSize.X, FinalBounds.Y, cornerSize.X, cornerSize.Y), BackgroundColor);

            GLOBALS.SpriteBatch.Draw(textureAtlas.GetTexture(3), new Rectangle(FinalBounds.X, FinalBounds.Y + cornerSize.Y, cornerSize.X, boxSize.Y - cornerSize.X * 2), BackgroundColor);
            GLOBALS.SpriteBatch.Draw(textureAtlas.GetTexture(4), new Rectangle(FinalBounds.X + cornerSize.X, FinalBounds.Y + cornerSize.Y, boxSize.X, boxSize.Y - cornerSize.X * 2), BackgroundColor);
            GLOBALS.SpriteBatch.Draw(textureAtlas.GetTexture(5), new Rectangle(FinalBounds.X + boxSize.X - cornerSize.X, FinalBounds.Y + cornerSize.Y, cornerSize.X, boxSize.Y - cornerSize.X * 2), BackgroundColor);

            GLOBALS.SpriteBatch.Draw(textureAtlas.GetTexture(6), new Rectangle(FinalBounds.X, FinalBounds.Y + boxSize.Y - cornerSize.Y, cornerSize.X, cornerSize.Y), BackgroundColor);
            GLOBALS.SpriteBatch.Draw(textureAtlas.GetTexture(7), new Rectangle(FinalBounds.X + cornerSize.X, FinalBounds.Y + boxSize.Y - cornerSize.Y, boxSize.X - cornerSize.X * 2, cornerSize.Y), BackgroundColor);
            GLOBALS.SpriteBatch.Draw(textureAtlas.GetTexture(8), new Rectangle(FinalBounds.X + boxSize.X - cornerSize.X, FinalBounds.Y + boxSize.Y - cornerSize.Y, cornerSize.X, cornerSize.Y), BackgroundColor);
            foreach (var child in Children)
            {
                child.Draw();
            }
        }
        public static void Draw(Alignments alignmet, Rectangle rect, Color color = default)
        {
            if (color == default) color = Color.White;
            Point position = SetAligmentPosition(alignmet, new Rectangle(rect.X, rect.Y, GLOBALS.WindowSize.X, GLOBALS.WindowSize.Y)).ToPoint() 
                           - SetAligmentPosition(alignmet, rect).ToPoint()
                           + rect.Location;

            GLOBALS.SpriteBatch.Draw(GLOBALS.Pixel, new Rectangle(position.X, position.Y, rect.Width, rect.Height), color);
        }
        public static void Draw(Alignments alignmet, Rectangle rect, Texture2D texture, Color color = default)
        {
            if (color == default) color = Color.White;
            Point position = SetAligmentPosition(alignmet, new Rectangle(0, 0, GLOBALS.WindowSize.X, GLOBALS.WindowSize.Y)).ToPoint()
                           - SetAligmentPosition(alignmet, new Rectangle(0, 0, rect.Width, rect.Height)).ToPoint()
                           + rect.Location;

            GLOBALS.SpriteBatch.Draw(texture, new Rectangle(position.X, position.Y, rect.Width, rect.Height), color);
        }
    }
}
