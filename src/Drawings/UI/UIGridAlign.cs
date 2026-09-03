using EngineArt.Drawings.UI;
using EngineArt.Mathematic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineArt.Drawings.UI
{
    public class UIGridAlign : UIElement
    {
        Vector2Int gapBetweenElements;
        int elementCountPerRow;
        bool changeRowToColumn = false;
        public UIGridAlign(Vector2Int gapBetweenElements, int elementCountPerRow, bool changeRowToColumn = false)
        {
            this.gapBetweenElements = gapBetweenElements;
            this.elementCountPerRow = elementCountPerRow;
            this.changeRowToColumn = changeRowToColumn;
        }
        public new void AddChild(UIElement child)
        {
            child.Parent = this;
            var newGap = new Vector2Int(gapBetweenElements.X * (Children.Count % elementCountPerRow), 
                                        gapBetweenElements.Y * (Children.Count / elementCountPerRow));
            if (changeRowToColumn)
                newGap = new Vector2Int(gapBetweenElements.X * (Children.Count / elementCountPerRow),
                                        gapBetweenElements.Y * (Children.Count % elementCountPerRow));
            child.PositionOffSet = newGap;
            Children.Add(child);
        }
        public override void Draw()
        {
            if (!Visible) 
                return;
            foreach (var child in Children)
            {
                child.Draw();
            }
        }
    }
}
