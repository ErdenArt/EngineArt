using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Scenes
{
    public abstract class Scene
    {
        protected readonly RenderTarget2D target;
        public Scene()
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
