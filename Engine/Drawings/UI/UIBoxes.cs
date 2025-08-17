using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Mathematic;
using Engine;

namespace Engine.Drawings.UI
{
    // Main script that is used mainly for UI
    public enum Alignments
    {
        TopLeft,
        Top,
        TopRight,
        Left,
        Center,
        Right,
        BottomLeft,
        Bottom,
        BottomRight
    }
    public static class UIBoxes
    {
        public static void Draw(Alignments alignmet, Rectangle rect, Color color = default)
        {
            if (color == default) color = Color.White;
            Point position = SetAligmentPosition(alignmet, rect);

            GLOBALS.SpriteBatch.Draw(GLOBALS.Pixel, new Rectangle(position.X, position.Y, rect.Width, rect.Height), color);
        }
        public static void Draw(Alignments alignmet, Rectangle rect, Texture2D texture, Color color = default)
        {
            if (color == default) color = Color.White;
            Point position = SetAligmentPosition(alignmet, rect);

            GLOBALS.SpriteBatch.Draw(texture, new Rectangle(position.X, position.Y, rect.Width, rect.Height), color);
        }
        static Point SetAligmentPosition(Alignments alignmet, Rectangle rect)
        {
            Point setAligment = new Point(0, 0);
            switch (alignmet)
            {
                case Alignments.TopLeft:
                    setAligment = new Point(rect.X, rect.Y);
                    break;
                case Alignments.Top:
                    setAligment = new Point(rect.X + GLOBALS.Graphics.PreferredBackBufferWidth / 2 - rect.Width / 2, rect.Y);
                    break;
                case Alignments.TopRight:
                    setAligment = new Point(rect.X + GLOBALS.Graphics.PreferredBackBufferWidth - rect.Width, rect.Y);
                    break;
                case Alignments.Left:
                    setAligment = new Point(rect.X, rect.Y + GLOBALS.Graphics.PreferredBackBufferHeight / 2 - rect.Height / 2);
                    break;
                case Alignments.Center:
                    setAligment = new Point(rect.X + GLOBALS.Graphics.PreferredBackBufferWidth / 2 - rect.Width / 2, rect.Y + GLOBALS.Graphics.PreferredBackBufferHeight / 2 - rect.Height / 2);
                    break;
                case Alignments.Right:
                    setAligment = new Point(rect.X + GLOBALS.Graphics.PreferredBackBufferWidth - rect.Width, rect.Y + GLOBALS.Graphics.PreferredBackBufferHeight / 2 - rect.Height / 2);
                    break;
                case Alignments.BottomLeft:
                    setAligment = new Point(rect.X, rect.Y + GLOBALS.Graphics.PreferredBackBufferHeight - rect.Height);
                    break;
                case Alignments.Bottom:
                    setAligment = new Point(rect.X + GLOBALS.Graphics.PreferredBackBufferWidth / 2 - rect.Width / 2, rect.Y + GLOBALS.Graphics.PreferredBackBufferHeight - rect.Height);
                    break;
                case Alignments.BottomRight:
                    setAligment = new Point(rect.X + GLOBALS.Graphics.PreferredBackBufferWidth - rect.Width, rect.Y + GLOBALS.Graphics.PreferredBackBufferHeight - rect.Height);
                    break;
            }
            return setAligment;
        }
    }
}
