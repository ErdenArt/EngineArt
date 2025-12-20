namespace EngineArt.Scenes
{
    public class SceneManager
    {
        private int _sceneCounter = 0;
        public void AddNewScene(Scene scene, string name)
        {
            _scenes.Add(_sceneCounter, scene);
            _sceneName.Add(name, _sceneCounter++);
        }
        public int ActiveScene { get; private set; }

        private readonly Dictionary<int, Scene> _scenes = new Dictionary<int, Scene>();
        private readonly Dictionary<string, int> _sceneName = new Dictionary<string, int>();

        public SceneManager(Scene startScene, string startSceneName)
        {
            _scenes.Add(_sceneCounter, startScene);
            _sceneName.Add(startSceneName, _sceneCounter++);
            ActiveScene = 0;
            _scenes[ActiveScene].Activate(0);
        }
        public void SwitchScene(int sceneID, int enterDoor = 0)
        {
            ActiveScene = sceneID;
            _scenes[ActiveScene].Activate(enterDoor);
        }
        public void SwitchScene(string sceneName, int enterDoor = 0)
        {
            ActiveScene = _sceneName[sceneName];
            _scenes[ActiveScene].Activate(enterDoor);
        }
        public void Update()
        {
            _scenes[ActiveScene].Update();
        }
        public RenderTarget2D GetFrame()
        {
            return _scenes[ActiveScene].GetFrame();
        }
    }
}
