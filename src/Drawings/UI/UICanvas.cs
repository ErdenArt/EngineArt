using System.Diagnostics;

namespace EngineArt.Drawings.UI
{
    public class UICanvas : UIElement
    {
        bool onResizeTrigger = true;
        public UICanvas(bool onResizeTrigger = true, bool dynamicResizing = false)
        {
            Bounds = new Rectangle(0, 0, GLOBALS.WindowSize.X, GLOBALS.WindowSize.Y);
            this.onResizeTrigger = onResizeTrigger;
            GLOBALS.Game.Window.ClientSizeChanged += Window_ClientSizeChanged!;
        }
        public UICanvas(Rectangle bounds)
        {
            Bounds = bounds;
            onResizeTrigger = false;
        }
        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            if (onResizeTrigger == false) return;
            
            Bounds = new Rectangle(0, 0, GLOBALS.WindowSize.X, GLOBALS.WindowSize.Y);
        }

        public override void Draw()
        {
            foreach (var child in Children)
            {
                child.Draw();
            }
        }
        public override void Update()
        {
            foreach (var child in Children)
            {
                child.Update();
            }
        }        
    }
}
