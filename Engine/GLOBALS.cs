using Microsoft.Xna.Framework.Content;

namespace Engine
{
    public static class GLOBALS
    {
        public static ContentManager Content { get; set; } = default!;
        public static GraphicsDevice GraphicsDevice { get; set; } = default!;
        public static GraphicsDeviceManager Graphics { get; set; } = default!;
        public static SpriteBatch SpriteBatch { get; set; } = default!;
        public static Game Game { get; set; } = default!;
        public static GameTime Time { get; set; } = default!;
        public static float DeltaTime { get; set; }
        public static Texture2D Pixel = default!;
        public static SpriteFont Font = default!;


        static Point _windowSize = new Point(1280,720);
        public static Point WindowSize => _windowSize;
        public static void ChangeWindowSize(Point newSize)
        {
            _windowSize = newSize;
            Graphics.PreferredBackBufferWidth = newSize.X;
            Graphics.PreferredBackBufferHeight = newSize.Y;
        }
        public static void Update(GameTime gameTime)
        {
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        // Got this from: https://stackoverflow.com/a/20351357
        public static Texture2D CreateCircleTxt(int radius)
        {
            Texture2D texture = new Texture2D(GraphicsDevice, radius, radius);
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
        public static Texture2D CreateWhitePixel(GraphicsDevice graphicsDevice)
        {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
            return texture;
        }
        public static RenderTarget2D GetNewRenderTarget()
        {
            return new RenderTarget2D(GraphicsDevice, WindowSize.X, WindowSize.Y);
        }
    }
}
