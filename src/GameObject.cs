using System.Collections.Generic;

namespace EngineArt
{
    public class GameObject
    {
        Vector2 position;
        public Vector2 BasePosition { get => position; set => position = value; }
        public Vector2 Position { get => position + Parent.position; set => position = value - Parent.position; }
        
        //Default for every object that doesn't have a parent
        static readonly GameObject emptyObject = new GameObject();
        public GameObject Parent;
        public List<GameObject> Children { get; }
        public bool IsActive = true;
        public GameObject()
        {
            Children = new List<GameObject>();
            Parent = emptyObject;
        }
        /// <summary>
        /// Move's position by adding values
        /// </summary>
        /// <param name="X">Move by X</param>
        /// <param name="Y">Move by Y</param>
        public void MovePosition(float X, float Y)
        {
            position.X += X;
            position.Y += Y;
        }
        /// <summary>
        /// Function you use when object get a new Parent
        /// </summary>
        protected virtual void UpdateForParent() { }
        public void AddChild(GameObject gameObject)
        {
            Children.Add(gameObject);
            gameObject.Parent = this;

            gameObject.UpdateForParent();
        }
    }
}
