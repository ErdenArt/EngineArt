namespace EngineArt.Drawings.UI
{
    public class UIBox : UIElement
    {
        public Texture2D Texture = GLOBALS.Pixel;
        public Color BackgroundColor;
        public override void Draw()
        {
            GLOBALS.SpriteBatch.Draw(Texture, FinalBounds, BackgroundColor);
            foreach (var child in Children)
            {
                child.Draw();
            }
        }
        public static void Draw(Alignments alignmet, Rectangle rect, Color color = default)
        {
            if (color == default) color = Color.White;
            Point position = SetAligmentPosition(alignmet, rect).ToPoint();

            GLOBALS.SpriteBatch.Draw(GLOBALS.Pixel, new Rectangle(position.X, position.Y, rect.Width, rect.Height), color);
        }
        public static void Draw(Alignments alignmet, Rectangle rect, Texture2D texture, Color color = default)
        {
            if (color == default) color = Color.White;
            Point position = SetAligmentPosition(alignmet, rect).ToPoint();

            GLOBALS.SpriteBatch.Draw(texture, new Rectangle(position.X, position.Y, rect.Width, rect.Height), color);
        }
    }
}
