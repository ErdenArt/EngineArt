using System.Diagnostics;

namespace Engine.Drawings
{
    public class Animate : SpriteOLD
    {
        //Vector2Int spriteSheetSize;
        int curFrame = 0;
        int endFrame = 0;

        public Animate(Vector2 position, Vector2Int spriteSize) : base(position)
        {
            this.textureSize = spriteSize;
        }
        public Animate(Vector2 position, Vector2Int spriteSize,int endFrame) : base(position)
        {
            this.textureSize = spriteSize;
            this.endFrame = endFrame;
        }
        public void PlayAnimation(int frame, float drawOrder = 0f)
        {
            curFrame = frame % (endFrame - 1);
            int x = (curFrame * textureSize.X) % texture.Width;
            int y = ((curFrame * textureSize.X) / texture.Width) * textureSize.Y;
            Rectangle rectangle = new Rectangle(x,y,textureSize.X,textureSize.Y);
            base.Draw(rectangle, drawOrder: drawOrder);
        }
        public void ChangeCycle(int startFrame, int endFrame)
        {
            this.curFrame = startFrame;
            this.endFrame = endFrame;
        }
    }
}
