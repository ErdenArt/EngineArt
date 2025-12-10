namespace EngineArt.Drawings
{
    public class Shape
    {
        // Got this from: https://stackoverflow.com/a/20351357
        public static Texture2D CreateCircleTxt(int radius)
        {
            Texture2D texture = new Texture2D(GLOBALS.GraphicsDevice, radius, radius);
            Color[] colorData = new Color[radius * radius];

            float diam = radius / 2f;
            float diamsq = diam * diam;

            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    int index = x * radius + y;
                    Vector2 pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq)
                    {
                        colorData[index] = Color.White;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;
        }
        public static void DrawEmptyBox(Rectangle rect, Color color = default, int lineWidth = 1)
        {
            if (color == default) color = Color.Red;
            lineWidth -= 1;

            GLOBALS.SpriteBatch.Draw(GLOBALS.Pixel,
                new Rectangle(rect.X - lineWidth,
                              rect.Y - lineWidth,
                              rect.Width + lineWidth,
                              1 + lineWidth), color);

            GLOBALS.SpriteBatch.Draw(GLOBALS.Pixel,
                new Rectangle(rect.X - lineWidth,
                              rect.Y + 1 - lineWidth,
                              1 + lineWidth,
                              rect.Height + lineWidth), color);

            GLOBALS.SpriteBatch.Draw(GLOBALS.Pixel,
                new Rectangle(rect.X + rect.Width - lineWidth,
                              rect.Y - lineWidth,
                              1 + lineWidth,
                              rect.Height + lineWidth), color);

            GLOBALS.SpriteBatch.Draw(GLOBALS.Pixel,
                new Rectangle(rect.X + 1 - lineWidth,
                              rect.Y + rect.Height - lineWidth,
                              rect.Width + lineWidth,
                              1 + lineWidth), color);
        }
    }
}
