using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineArt.Engine.Drawings.UI
{
    internal class UIElement
    {
        Vector2 position;
        Vector2 size;

        List<UIElement> children = new List<UIElement>();
    }
}
