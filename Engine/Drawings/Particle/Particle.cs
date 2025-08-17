using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Engine.Mathematic;
using System;
using System.Diagnostics;

namespace Engine.Drawings.Particle
{
    public class Trajectory
    {
        public float initialSpeed;        // How fast the particle is ejected  
        public Vector2 direction;         // Direction of ejection (Vector2)
        public float angle;               // Direction of ejection (get in degrees)
                                          // Direction example values: 0 => Top, 90 => Right, 180 => Down, 270 => Left
        public float gravity;             // How strong the gravity effect is
        public float gravityDir;          // Direction on where gravity will drag (in degrees)
        public Vector2 gravityDirVector;  // Direction on where gravity will drag (in Vector2)
        public float drag;                // Slows down the movement over time  
        //public bool colideWithFloor;      // True: will colide with some wall
        //public float bounceStrength;      // Power of bouncing of floor. If zero it will instantly stop
        public float floorY;              // Positive will collide with upper floor. Negative or zero will collide with bottom floor



        public Trajectory(float initialSpeed = 1, float angle = 0, float gravity = 0, float gravityDir = 180, float drag = 1, float wind = 0)
        {
            this.initialSpeed = initialSpeed;
            //Setting direction
            this.angle = angle;
            float radiansDirection = (angle - 90) * (float)MathF.PI / 180.0f;
            this.direction = new Vector2((float)MathF.Cos(radiansDirection), (float)MathF.Sin(radiansDirection));
            this.drag = drag;
            //Setting direction again
            float radiansGravity = (gravityDir - 90) * (float)MathF.PI / 180.0f;
            this.gravityDir = gravityDir;
            this.gravityDirVector = new Vector2((float)MathF.Cos(radiansGravity), (float)MathF.Sin(radiansGravity));
            this.gravity = gravity;

        }
    }
    public class Particle : Sprite
    {
        public bool isActive = true;
        public Trajectory trajectory;
        public Mathematic.Timer lifeTime;
        public Particle(Particle particle, Trajectory trajectory)
        {
            this.texture = particle.texture;
            this.position = particle.position;
            //this.trajectory.floorY = trajectory.floorY + position.Y;
            this.trajectory = trajectory;
            this.lifeTime = new Mathematic.Timer(10);
            this.lifeTime.handler += RemoveParticle;
        }
        public Particle(Particle particle, Trajectory trajectory, float lifeTime)
        {
            this.texture = particle.texture;
            this.position = particle.position;
            this.trajectory.floorY = trajectory.floorY + particle.position.Y;
            this.trajectory = trajectory;
            this.lifeTime = new Mathematic.Timer(lifeTime);
            this.lifeTime.handler += RemoveParticle;
        }
        public Particle(Texture2D texture, Vector2 position) : base(texture, position)
        {
            this.lifeTime = new Mathematic.Timer(2);
            this.lifeTime.handler += RemoveParticle;
        }
        public Particle(Texture2D texture, Vector2 position, Trajectory trajectory) : base(texture, position)
        {
            //Debug.WriteLine("selks");
            this.trajectory = trajectory;
            this.trajectory.floorY = this.trajectory.floorY + this.position.Y;
            this.lifeTime = new Mathematic.Timer(2);
            //Debug.WriteLine("siema");
            this.lifeTime.handler += RemoveParticle;
        }
        public void Update(GameTime gameTime)
        {
            if (isActive == false)
                return;
            lifeTime.Update(gameTime);
            //Debug.WriteLine(lifeTime.ToString());
            MoveParticle(gameTime);
        }
        void RemoveParticle(object sender, EventArgs e)
        {
            isActive = false;
        }
        void MoveParticle(GameTime gameTime)
        {
            //Debug.WriteLine(position);
            this.position += trajectory.direction * trajectory.initialSpeed +
                        trajectory.gravityDirVector * trajectory.gravity;
            //Debug.WriteLine(position);
            this.trajectory.initialSpeed *= trajectory.drag;
            //Debug.WriteLine($"{position.Y} and this {trajectory.floorY}");
            //Debug.WriteLine(trajectory.colideWithFloor);

        }
        public override void Draw()
        {
            if (isActive == false)
                return;
            base.Draw();
        }
    }
}
