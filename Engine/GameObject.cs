using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineArt.Engine
{
    public class GameObject
    {
        Vector2 position;
        public Vector2 BasePosition { get => position; set => position = value; }
        public Vector2 Position { get => position + Parent.position; set => position = value - Parent.position; }
        
        //Default for every object that doesnt have parent
        static readonly GameObject emptyObject = new GameObject();
        public GameObject Parent;
        public List<GameObject> Children { get; }
        public bool IsActive = true;
        public GameObject()
        {
            Children = new List<GameObject>();
            Parent = emptyObject;
        }
        protected virtual void UpdateForParent() { }
        public void AddChild(GameObject gameObject)
        {
            Children.Add(gameObject);
            gameObject.Parent = this;

            gameObject.UpdateForParent();
        }
    }
}
