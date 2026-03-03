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
        Dictionary<string, Texture2D> sprites;
        public Atlas(Texture2D texture, Dictionary<string, Rectangle> recs)
        {
            this.texture = texture;
            sprites = new Dictionary<string, Texture2D>();

            foreach (var ele in recs)
            {
                Color[] sourceData = new Color[texture.Width * texture.Height];
                texture.GetData(sourceData);
                Color[] newColors = new Color[ele.Value.Width * ele.Value.Height];

                for (int i = 0; i < ele.Value.Width; i++)
                {
                    for (int j = 0; j < ele.Value.Height; j++)
                    {
                        int sourceIndex = (ele.Value.X + i) + (ele.Value.Y + j) * texture.Width;
                        int newColorPos = i + j * ele.Value.Width;
                        newColors[newColorPos] = sourceData[sourceIndex];
                    }
                }
                Texture2D croppedTexture = new Texture2D(GLOBALS.GraphicsDevice, ele.Value.Width, ele.Value.Height);
                croppedTexture.SetData(newColors);
                sprites.Add(ele.Key, croppedTexture);
            }
        }
        public Texture2D GetTexture(string name)
        {
            if (sprites.ContainsKey(name)) 
                return sprites[name];

            throw new Exception("Texture does not exsists");
        }
        public Texture2D FirstTexture()
        {
            var first = sprites.First();
            return GetTexture(first.Key);
        }
        public Texture2D GetTexture(int value)
        {
            if (sprites.Count <= value || value < 0)
            {
                throw new Exception("Atlas index is out of range!");
            }
            return GetTexture(sprites.ElementAt(value).Key);
        }
    }
}
