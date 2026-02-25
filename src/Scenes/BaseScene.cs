namespace EngineArt.Scenes
{
    public abstract class BaseScene
    {
        protected readonly RenderTarget2D target;
        public BaseScene()
        {
            target = GLOBALS.GetNewRenderTarget();
            Load();
        }

        protected abstract void Load();
        protected abstract void Draw();
        public abstract void Update();
        public abstract void Activate(int enterDoor);
        public virtual RenderTarget2D GetFrame()
        {
            GLOBALS.GraphicsDevice.SetRenderTarget(target);
            GLOBALS.GraphicsDevice.Clear(Color.Black);

            Draw();

            GLOBALS.GraphicsDevice.SetRenderTarget(null);
            return target;
        }
        public virtual void ResetScene()
        {
            Load();
        }
    }
}
