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
        //public static GameTime gameTime = new GameTime();
        //public static float deltaTime => (float)gameTime.ElapsedGameTime.TotalSeconds;
        public bool isActive = true;
        public float timerCount;
        float resetToTime;
        public bool endless = false;
        public event EventHandler handler;
        public Timer(float timerCount)
        {
            this.timerCount = timerCount;
        }
        public Timer(float timerCount, bool endless)
        {
            this.timerCount = timerCount;
            this.resetToTime = timerCount;
            this.endless = endless;
        }
        public void Update(GameTime gameTime) // Fitted to real time
        {
            if (this.isActive == false)
                return;

            timerCount -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timerCount < 0)
            {
                handler?.Invoke(this, EventArgs.Empty);
                if (endless)
                    timerCount = resetToTime;
                else
                    isActive = false;
            }
        }
        public void FixedUpdate(float speed) // Fitted to framerate
        {
            if (this.isActive == false)
                return;

            timerCount -= speed;
            if (timerCount < 0)
            {
                handler?.Invoke(this, EventArgs.Empty);
                if (endless)
                    timerCount = resetToTime;
                else
                    isActive = false;
            }
            
        }
        public override string ToString()
        {
            return $"Timer:{timerCount}, Endless:{endless}";
        }
    }
}
