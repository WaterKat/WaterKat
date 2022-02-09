using System;

namespace WaterKat.GameAssets.SceneManagement
{
    public class SceneManager
    {
        private Scene currentScene;

        private bool isActive = true;
        public bool IsActive { get => isActive; }

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
            Scene nextScene = currentScene.Update();
            if (currentScene != nextScene.previousScene)
            {
                nextScene.previousScene = currentScene;
            }
            currentScene = nextScene;
            if (currentScene is Scenes.Quit)
            {
                isActive = false;
            }
        }
    }
}
