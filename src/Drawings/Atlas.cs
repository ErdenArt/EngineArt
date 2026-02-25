using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineArt.Drawings
{
    public class Atlas
    {
        Texture2D texture;
        Dictionary<string, Rectangle> sprites;
        public Atlas(Texture2D texture, Dictionary<string, Rectangle> sprites)
        {
            this.texture = texture;
            this.sprites = sprites;
        }
        public Texture2D GetTexture(string name)
        {
            if (sprites.ContainsKey(name) == false)
                throw new Exception("Texture name in atlas does NOT exists");

            Rectangle rectangle = sprites[name];
            Color[] sourceData = new Color[texture.Width * texture.Height];
            texture.GetData(sourceData);
            Color[] newColors = new Color[rectangle.Height * rectangle.Width];

            for (int i = 0; i < rectangle.Width; i++)
            {
                for (int j = 0; j < rectangle.Height; j++)
                {
                    int sourceIndex = (rectangle.X + i) + (rectangle.Y + j) * texture.Width;
                    int newColorPos = i + j * rectangle.Width;
                    newColors[newColorPos] = sourceData[sourceIndex];
                }
            }

            Texture2D newTexture = new Texture2D(GLOBALS.GraphicsDevice, rectangle.Width, rectangle.Height);
            newTexture.SetData(newColors);
            return newTexture;
        }
    }
}
