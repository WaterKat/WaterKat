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
            currentScene = currentScene.Update();
            if (currentScene is Scenes.Quit)
            {
                isActive = false;
            }
        }
    }
}
