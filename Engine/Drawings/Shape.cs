using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloom_Sack.Engine.Drawings
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
        public static void DrawEmptyBox(Rectangle rect, Color color = default)
        {
            if (color == default) color = Color.Red;

            GLOBALS.SpriteBatch.Draw(GLOBALS.Pixel, new Rectangle(rect.X, rect.Y, rect.Width, 1), color);
            GLOBALS.SpriteBatch.Draw(GLOBALS.Pixel, new Rectangle(rect.X, rect.Y + 1, 1, rect.Height), color);
            GLOBALS.SpriteBatch.Draw(GLOBALS.Pixel, new Rectangle(rect.X + rect.Width, rect.Y, 1, rect.Height), color);
            GLOBALS.SpriteBatch.Draw(GLOBALS.Pixel, new Rectangle(rect.X + 1, rect.Y + rect.Height, rect.Width, 1), color);
        }
    }
}
