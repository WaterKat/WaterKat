using System;

namespace WaterKat.GameAssets.SceneManagement
{
    public class SceneManager
    {
        private Scene currentScene;

        public SceneManager()
        {
            currentScene = new Scene.Start();
        }

        public void Update()
        {
            currentScene = currentScene.Update();
        }
    }
}
