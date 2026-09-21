using System.Diagnostics;
using EngineArt.Mathematic;

namespace EngineArt
{

    public class AnimationManager
    {
        KeyFrame[] keyFrames;
        AnimationManager runAnotherSetOfAnimation;
        int frameIndex = 0;
        bool finished = false;
        public AnimationManager(KeyFrame[] keyFrames, AnimationManager? runAnotherSetOfAnimation = null)
        {
            this.keyFrames = keyFrames;
            this.runAnotherSetOfAnimation = runAnotherSetOfAnimation;
        }
        
        public void Update()
        {
            foreach (var key in keyFrames)
            {
                key.Update();
            }
            return;
            if (finished == true)
            {
                if (runAnotherSetOfAnimation != null) runAnotherSetOfAnimation.Update();
                return;
            }
            if (frameIndex < keyFrames.Length)
            {
                keyFrames[frameIndex].Update();
                if (keyFrames[frameIndex].IsFinished())
                {
                    frameIndex++;
                }
            }
            else
            {
                finished = true;
            }
        }
    }
    public class KeyFrame
    {
        Mathematic.Timer timer;
        Func<float> getValue;
        Action<float> setValue;
        float valueEnd;

        public KeyFrame(float timeStart, float timeLength, Func<float> getValue, float valueEnd, Action<float> setValue)
        {
            timer = new Mathematic.Timer(timeLength);
            timer.Time = -timeStart;
            this.getValue = getValue;
            this.valueEnd = valueEnd;
            this.setValue = setValue;
        }
        public void Update()
        {
            timer.Update();
            setValue(float.Lerp(getValue(), valueEnd, timer.GetProgress()));
        }
        public bool IsFinished()
        {
            return timer.IsFinished();
        }
    }
}