using System.Security.AccessControl;

namespace EngineArt.Scenes
{
    public abstract class BaseScene
    {
        protected Vector2 _cursorFrameOffSet => _sceneWindowPosition.ToVector2();
        protected Point _sceneWindowSize;
        protected Point _sceneWindowPosition;
        private readonly RenderTarget2D target;
        public BaseScene(Point sceneWindowSize, Point sceneWindowPosition)
        {
            target = GLOBALS.GetNewRenderTarget(sceneWindowSize.X, sceneWindowSize.Y);
            Load();
            _sceneWindowSize = sceneWindowSize;
            _sceneWindowPosition = sceneWindowPosition;
        }
        public Point GetWindowPosition()
        {
            return _sceneWindowPosition;
        }
        public BaseScene()
        {
            target = GLOBALS.GetNewRenderTarget(GLOBALS.WindowSize.X, GLOBALS.WindowSize.Y);
            Load();
            _sceneWindowSize = GLOBALS.WindowSize;
            _sceneWindowPosition = Point.Zero;
        }
        public void SetCursorFrameOffSet(Vector2 position)
        {
            //_cursorFrameOffSet = position;
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
