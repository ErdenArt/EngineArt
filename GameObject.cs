namespace EngineArt
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

        public void MovePosition(float X, float Y)
        {
            position.X = X;
            position.Y = Y;
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
