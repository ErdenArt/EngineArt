
namespace EngineArt.Drawings.Particle
{
    internal class ParticleSpawner
    {
        //Add isContinuoslySpawning function so it will constantly spawn
        //Make it more spread

        //public Vector2 position;
        //bool isContinuouslySpawning = false;
        //bool isActive = true;
        //List<Particle> particle = new List<Particle>();
        //Timer timer;

        //int spawnCount;
        //Trajectory particleTrajectory;
        //float randomAngle;
        //Texture2D particleTexture;
        //public ParticleSpawner(Vector2 position, Texture2D texture, float lifeTime, int count, Trajectory trajectory, float randomAngle, bool isContinuouslySpawning)
        //{
        //    this.position = position;
        //    spawnCount = count;
        //    particleTrajectory = trajectory;
        //    particleTexture = texture;
        //    this.randomAngle = randomAngle;
        //    this.isContinuouslySpawning = isContinuouslySpawning;
        //    SpawnNewParticles(position, EventArgs.Empty);
        //    timer = new Timer(lifeTime, isContinuouslySpawning);
        //    if (isContinuouslySpawning == false)
        //        timer.handler += RemoveParticleSpawner;
        //    else
        //        timer.handler += SpawnNewParticles;
        //}
        //public ParticleSpawner(Vector2 position, Particle particle, float lifeTime, float randomLifeRange, int count, Trajectory trajectory, bool isContinuouslySpawning)
        //{
        //    for (int i = 0; i < count; i++)
        //    {
        //        Random rand = new Random();
        //        this.particle[i] = new Particle(particle, trajectory, lifeTime - (float)rand.NextDouble() * randomLifeRange);
        //        this.particle[i].position += position;
        //    }
        //    this.isContinuouslySpawning = isContinuouslySpawning;
        //    timer = new Timer(lifeTime, isContinuouslySpawning);
        //    if (isContinuouslySpawning == false)
        //        timer.handler += RemoveParticleSpawner;
        //    else
        //        timer.handler += SpawnNewParticles;
        //}
        //List<Particle> particleToRemove;
        //public void Update(GameTime gameTime)
        //{
        //    if (!isActive)
        //        return;
        //    particleToRemove = new List<Particle>();
        //    foreach (Particle particle in this.particle)
        //    {
        //        particle.Update(gameTime);
        //        if (particle.isActive == false)
        //            particleToRemove.Add(particle);
        //    }
        //    foreach (Particle particle in this.particleToRemove)
        //    {
        //        this.particle.Remove(particle);
        //    }
        //    timer.Update(gameTime);
        //    //Debug.WriteLine(particle.Count);
        //}
        //public void RemoveParticleSpawner(object sender, EventArgs e)
        //{
        //    isActive = false;
        //}
        //public void SpawnNewParticles(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < spawnCount; i++)
        //    {
        //        Random rand = new Random();
        //        Trajectory trajectory1 = new Trajectory(initialSpeed: particleTrajectory.initialSpeed,
        //                                                angle: particleTrajectory.angle + ((float)rand.NextDouble() * randomAngle - randomAngle / 2),
        //                                                gravity: particleTrajectory.gravity,
        //                                                gravityDir: particleTrajectory.gravityDir,
        //                                                drag: particleTrajectory.drag);

        //        this.particle.Add( new Particle(particleTexture, position, trajectory1));

        //        //Debug.WriteLine($"{rand.NextDouble()}");
        //        //this.particle[i].position += position;
        //    }
        //}
        //public void Draw()
        //{
        //    if (!isActive)
        //        return;
        //    foreach (Particle particle in particle)
        //    {
        //        particle.Draw();
        //    }
        //}
    }
}
