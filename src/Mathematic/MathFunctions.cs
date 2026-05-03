using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineArt.src.Mathematic
{
    public class MathFunctions
    {
        // Returns the angle (in radians). Start point will face the end point
        public static float LookAtAngle(Vector2 start, Vector2 end)
        {
            Vector2 dir = start - end;
            dir = Vector2.Normalize(dir);

            float angle = MathF.Atan2(dir.Y, dir.X);
            return angle;
        }
    }
}
