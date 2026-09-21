using System;
using System.Collections.Generic;

namespace EngineArt.Scenes
{
    public class SceneManager
    {
        private Vector2 _cursorFrameOffSet;
        private int _sceneCounter = 0;
        public void AddNewScene(BaseScene scene, string name)
        {
            if (_sceneName.ContainsKey(name))
            {
                throw new Exception("Can't have two scenes with the same name");
            }
            _scenes.Add(_sceneCounter, scene);
            _sceneName.Add(name, _sceneCounter++);
        }
        public int ActiveSceneID { get; private set; }
        public BaseScene CurrentScene { get => _scenes[ActiveSceneID]; }

        private readonly Dictionary<int, BaseScene> _scenes = new Dictionary<int, BaseScene>();
        private readonly Dictionary<string, int> _sceneName = new Dictionary<string, int>();

        public SceneManager(BaseScene startScene, string startSceneName)
        {
            _scenes.Add(_sceneCounter, startScene);
            _sceneName.Add(startSceneName, _sceneCounter++);
            ActiveSceneID = 0;
            _scenes[ActiveSceneID].Activate(0);
        }
        public void SwitchScene(int sceneID, int enterDoor = 0)
        {
            ActiveSceneID = sceneID;
            _scenes[ActiveSceneID].Activate(enterDoor);
        }
        public void SwitchScene(string sceneName, int enterDoor = 0)
        {
            ActiveSceneID = _sceneName[sceneName];
            _scenes[ActiveSceneID].Activate(enterDoor);
        }
        public void Update(GameTime gameTime)
        {
            _scenes[ActiveSceneID].Update(gameTime);
        }
        public RenderTarget2D GetFrame(SpriteBatch spriteBatch, GameTime gameTime)
        {
            return _scenes[ActiveSceneID].GetFrame(spriteBatch, gameTime);
        }
        public void SetCursorFrameOffSet(Vector2 position)
        {
            foreach (var scene in _scenes)
            {
                scene.Value.SetCursorFrameOffSet(position);
            }
        }
    }
}
