using EngineArt.Engine.Drawings.UI;
using System.Reflection;

namespace Engine.Drawings
{
    public class UICanvas : UIElement
    {
        public UICanvas()
        {
            Bounds = new Rectangle(0,0,GLOBALS.WindowSize.X, GLOBALS.WindowSize.Y);
        }
        public override void Draw()
        {
            foreach (var child in Children)
            {
                child.Draw();
            }
        }
    }
}
