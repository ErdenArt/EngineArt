using EngineArt.Mathematic;
using System.Diagnostics;

namespace EngineArt.Drawings.UI
{
    public class UIBox : UIElement
    {
        public Texture2D Texture = GLOBALS.Pixel;
        public Color BackgroundColor = Color.White;

        public UIBox(Vector2Int position, Vector2Int size)
        {
            Bounds = new Rectangle(position, size);
        }

        public override void Draw()
        {
            if (!Visible)
                return;
            
            GLOBALS.SpriteBatch.Draw(Texture, FinalBounds, BackgroundColor);
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
