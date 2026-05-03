using System.Diagnostics;

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
        public static void DrawCircle(Vector2 position, int radius, Color color = default)
        {
            if (color == default) color = Color.Red;
            Texture2D texture2D = CreateCircleTxt(radius);
            GLOBALS.SpriteBatch.Draw(texture2D, position - Vector2.One * radius / 2, color);
        }
        /// <summary>
        /// Draw line between start and end. Use distance to edit length of line or set it to 0 to cover full distance between start and end.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="color"></param>
        /// <param name="distance"></param>
        public static void DrawLine(Vector2 start, Vector2 end, Color color = default, float thickness = 1f, float distance = 0)
        {
            if (color == default) color = Color.Lime;
            var dotProduct = -MathF.Atan2(end.X - start.X, end.Y - start.Y);
            //dotProduct = MathHelper.ToRadians(dotProduct);
            GLOBALS.SpriteBatch.Draw(GLOBALS.Pixel, start, new Rectangle(0, 0, 1, 1), color, dotProduct, new Vector2(0.5f,0), new Vector2(thickness, distance == 0 ? Vector2.Distance(start, end) : distance), SpriteEffects.None, 1f);

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
