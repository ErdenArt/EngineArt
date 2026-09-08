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
        float time = 0;
        float endTime = 0;
        bool finish = false;
        bool pause = false;
        public Timer(float endTime)
        {
            this.endTime = endTime;
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
            return MathF.Min(time, endTime);
        }
        public float GetProgress()
        {
            return MathF.Min(time / endTime, 1);
        }
        public void Update()
        {
            if (pause) return;
            time += (float)GLOBALS.Time.ElapsedGameTime.TotalSeconds;
            if (time >= endTime) finish = true;
        }
        public void ReStart()
        {
            time = 0;
            finish = false;
            pause = false;
        }
        public void Reset()
        {
            time = 0;
            finish = false;
        }
    }
}
