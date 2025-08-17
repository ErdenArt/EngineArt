using Bloom_Sack;
using System.Diagnostics;

namespace Engine.Mathematic
{
    public class Camera
    {
        Matrix matrixPos = new Matrix();
        Vector2 vectorPos = new Vector2();
        public float Zoom = 1f;
        public Camera()
        {
            vectorPos = new Vector2(GLOBALS.Graphics.PreferredBackBufferWidth / 2, GLOBALS.Graphics.PreferredBackBufferHeight / 2);
            previusLookPos = vectorPos;
        }
        public void Update(Vector2 lookPos, float zPos)
        {
            Vector2 offSetVector = new Vector2(GLOBALS.Graphics.PreferredBackBufferWidth / 2, GLOBALS.Graphics.PreferredBackBufferHeight / 2);
            lookPos = lookPos * zPos;
            previusLookPos = lookPos;
            var offSet = Matrix.CreateTranslation(offSetVector.X, offSetVector.Y, 0);
            var position = Matrix.CreateTranslation(-lookPos.X, -lookPos.Y, 0);
            matrixPos = Matrix.CreateScale(new Vector3(zPos, zPos, 1f)) *
                        offSet * position;
            Zoom = zPos;
            vectorPos = lookPos - offSetVector;
        }
        Vector2 previusLookPos = Vector2.Zero;
        public void InputUpdate()
        {
            Vector2 lookPos = previusLookPos;
            if (Input.GetKey(Keys.LeftShift)) lookPos += Input.LeftStickDirection;
            lookPos += Input.LeftStickDirection;
            previusLookPos = lookPos;
            float zPos = Zoom;
            zPos += Input.MouseScrollIsGointUp() ? 0.1f : 0;
            zPos -= Input.MouseScrollIsGointDown() ? 0.1f : 0;
            zPos = Math.Max(zPos, 0.1f);

            Vector2 offSetVector = new Vector2(GLOBALS.Graphics.PreferredBackBufferWidth / 2, GLOBALS.Graphics.PreferredBackBufferHeight / 2);
            lookPos = lookPos * zPos;
            var offSet = Matrix.CreateTranslation(offSetVector.X, offSetVector.Y, 0);
            var position = Matrix.CreateTranslation(-lookPos.X, -lookPos.Y, 0);
            matrixPos = Matrix.CreateScale(new Vector3(zPos, zPos, 1f)) *
                        offSet * position;
            Zoom = zPos;
            vectorPos = lookPos - offSetVector;
        }
        public Matrix GetMatrix()
        {
            return matrixPos;
        }
        public Vector2 GetPosition()
        {
            return vectorPos;
        }
    }
}
