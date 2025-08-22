namespace Engine.Drawings
{
    public class UICanvas
    {
        List<Action> drawCalls;
        public UICanvas(List<Action> drawCalls)
        {
            this.drawCalls = drawCalls;
        }
        public void Draw()
        {
            if (drawCalls != null)
            {
                foreach (var drawAction in drawCalls)
                {
                    drawAction();
                }
            }
        }
    }
}
