using System;

namespace WaterKat.GameAssets.SceneManagement
{
    public class SceneManager
    {
        public bool isActive;
        private Scene currentScene;

        public SceneManager()
        {
            currentScene = new Scenes.Start();
        }
        public SceneManager(Scene _scene)
        {
            currentScene = _scene;
        }

        public void Update()
        {
            currentScene = currentScene.Update();
        }
    }
}
