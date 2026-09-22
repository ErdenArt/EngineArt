using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineArt.Rendering
{
    public class ObjectModel
    {
        Model model;
        Vector3 Position;
        Vector3 Rotation;
        Vector3 Scale;
        Texture2D texture;

        Matrix world;

        public ObjectModel(string fileName, Vector3 position, Vector3 rotation = default, Vector3? scale = null, Texture2D? texture = null)
        {
            model = GLOBALS.Content.Load<Model>(fileName);
            this.Rotation = rotation;
            this.Scale = scale ?? Vector3.One;
            this.texture = texture ?? GLOBALS.MISSING_TEXTURE;
            SetPosition(position);
        }
        public void SetPosition(Vector3 newPosition)
        {
            Position = newPosition;
            world = Matrix.CreateScale(this.Scale) *
                    Matrix.CreateTranslation(newPosition) * 
                    Matrix.CreateRotationX(Rotation.X) * 
                    Matrix.CreateRotationY(Rotation.Y) * 
                    Matrix.CreateRotationZ(Rotation.Z);
        }
        public void Draw(Effect effect)
        {
            effect.Parameters["World"].SetValue(world);
            effect.Parameters["Texture"].SetValue(this.texture);

            ((BasicEffect)effect).World = world;
            //effect.Parameters["LightDirection"].SetValue(new Vector3(-0.5f, -1f, -0.5f));

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    ((BasicEffect)effect).World = (mesh.ParentBone.Transform * world);
                    ((BasicEffect)effect).CurrentTechnique.Passes[0].Apply();
                    part.Effect = effect;
                }
                mesh.Draw();
            }
        }
    }
}
