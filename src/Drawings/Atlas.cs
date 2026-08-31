using EngineArt.Mathematic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Color[] sourceData = new Color[texture.Width * texture.Height];
            texture.GetData(sourceData);
                        Debug.WriteLine(sourceData.Length);
            foreach (var ele in recs)
            {
                Color[] newColors = new Color[ele.Value.Width * ele.Value.Height];

                for (int i = 0; i < ele.Value.Width; i++)
                {
                    for (int j = 0; j < ele.Value.Height; j++)
                    {
                        int sourceIndex = (ele.Value.X + i) + (ele.Value.Y + j) * texture.Width;
                        int newColorPos = i + j * ele.Value.Width;
                        if (sourceIndex >= sourceData.Length)
                            continue;
                        newColors[newColorPos] = sourceData[sourceIndex];
                    }
                }
                Texture2D croppedTexture = new Texture2D(GLOBALS.GraphicsDevice, ele.Value.Width, ele.Value.Height);
                croppedTexture.SetData(newColors);
                sprites.Add(ele.Key, croppedTexture);
            }
        }
        public Atlas(Texture2D texture, Vector2Int singleFrameSize) : this(texture, BuildRects(texture, singleFrameSize))
        {
        }

        private static Dictionary<string, Rectangle> BuildRects(Texture2D texture, Vector2Int singleFrameSize)
        {
            var dictionary = new Dictionary<string, Rectangle>();
            int name = 0;
            for (int i = 0; i < texture.Height - 1; i += singleFrameSize.Height)
            {
                for (int j = 0; j < texture.Width - 1; j += singleFrameSize.Width)
                {
                    name += 1;
                    dictionary.Add(name.ToString(), new Rectangle(j, i, singleFrameSize.Width, singleFrameSize.Height));
                }
            }
            return dictionary;
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
