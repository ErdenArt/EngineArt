using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace EngineArt.Engine
{
    public abstract class GameObject
    {
        Vector2 position;
        public float X { get => position.X; set => position.X = value; }
        public float Y { get => position.Y; set => position.Y = value; }
        public Vector2 Position { get => new Vector2(position.X, -position.Y); set => position = value; }
        GameObject parent;
        public GameObject Parent { get => parent; set => parent = value; }
        public List<GameObject> Children { get; }

        public GameObject()
        {
            Children = new List<GameObject>();
        }
        protected abstract void UpdateForParent();
        public void AddChild(GameObject gameObject)
        {
            Children.Add(gameObject);
            gameObject.Parent = this;

            gameObject.UpdateForParent();
        }
    }
}
