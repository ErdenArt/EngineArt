using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineArt.Mathematic
{
    public class Timer
    {
        // Time in seconds
        public float Time = 0;
        float endTime = 0;
        bool finish = false;
        bool pause = false;
        public Timer(float endTime)
        {
            this.endTime = endTime;
        }
        public bool IsFinished()
        {
            return finish;
        }
        public bool IsRunning()
        {
            return finish == false && pause == false;
        }
        public void Pause()
        {
            pause = true;
        }
        public void Start()
        {
            pause = false;
        }
        public float GetTime()
        {
            return MathF.Min(Time, endTime);
        }
        public float GetEndTime()
        {
            return endTime;
        }
        public float GetProgress()
        {
            return MathF.Min(MathF.Max(Time / endTime, 0f), 1);
        }
        public void Update()
        {
            if (pause) return;
            Time += (float)GLOBALS.Time.ElapsedGameTime.TotalSeconds;
            if (Time >= endTime) finish = true;
        }
        public void ReStart(float startTime = 0)
        {
            Time = startTime;
            finish = false;
            pause = false;
        }
        public void Reset(float startTime = 0)
        {
            Time = startTime;
            finish = false;
        }
    }
}
