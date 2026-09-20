using EngineArt.Mathematic;

namespace EngineArt
{

    public class AnimationManager
    {
        public AnimationManager()
        {
            
        }
        void AddNewClip()
        {
            
        }
        public void Update()
        {
            
        }
    }
    public class AnimationClip
    {
        Timer timer;
        object animatedObject;
        float timeEnd;
        float timeStart;
        float valueToChange;
        float valueStart;
        float valueEnd;

        public AnimationClip(float endTime)
        {
            timer = new Timer(endTime);
        }
        public void AddKeyframe(object a, float timeStart, float timeEnd, ref float valueStart, float valueEnd)
        {
            animatedObject = a;
            this.timeStart = timeStart;
            this.timeEnd = timeEnd;
            valueToChange = valueStart;
            this.valueStart = valueStart;
            this.valueEnd = valueEnd;
        }
        public void Update()
        {
            timer.Update();
            valueToChange = float.Lerp(valueStart, valueEnd, timer.GetProgress());
        }
    }
}