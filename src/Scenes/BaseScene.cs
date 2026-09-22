using System.Security.AccessControl;

namespace EngineArt.Scenes
{
    public abstract class BaseScene
    {
        public Point _sceneWindowSize;
        public Point _sceneWindowPosition;

        private RenderTarget2D target;
        public BaseScene(Point sceneWindowSize, Point sceneWindowPosition)
        {
            target = GLOBALS.GetNewRenderTarget(sceneWindowSize.X, sceneWindowSize.Y);
            _sceneWindowSize = sceneWindowSize;
            _sceneWindowPosition = sceneWindowPosition;
            Load();
        }
        public void ChangeWindowPropeties(Point sceneWindowSize, Point sceneWindowPosition)
        {
            target = GLOBALS.GetNewRenderTarget(sceneWindowSize.X, sceneWindowSize.Y);
            _sceneWindowSize = sceneWindowSize;
            _sceneWindowPosition = sceneWindowPosition;
        }
        public BaseScene()
        {
            target = GLOBALS.GetNewRenderTarget(GLOBALS.WindowSize.X, GLOBALS.WindowSize.Y);
            Load();
            _sceneWindowSize = GLOBALS.WindowSize;
        }

        protected abstract void Load();
        protected abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        public abstract void Update(GameTime gameTime);
        public abstract void Activate(int enterDoor);
        public virtual RenderTarget2D GetFrame(SpriteBatch spriteBatch, GameTime gameTime)
        {
            GLOBALS.GraphicsDevice.SetRenderTarget(target);
            GLOBALS.GraphicsDevice.Clear(Color.Black);

            Draw(spriteBatch, gameTime);

            GLOBALS.GraphicsDevice.SetRenderTarget(null);
            return target;
        }
        public virtual void ResetScene()
        {
            Load();
        }
    }
}
