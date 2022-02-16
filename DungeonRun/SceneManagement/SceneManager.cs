using WaterKat.DungeonRun.SaveManagement;

namespace WaterKat.DungeonRun.SceneManagement
{
    public class SceneManager
    {
        public GameData GameData = new GameData();
        public int SaveSlot = -1;

        private Scene currentScene;

        private bool isActive = true;
        public bool IsActive { get => isActive; }

        public SceneManager()
        {
            currentScene = new Scenes.Title();
        }
        public SceneManager(Scene _scene)
        {
            currentScene = _scene;
        }

        public void Update()
        {
            Scene nextScene = currentScene.Update();

            if (currentScene != nextScene)
            {
                if (nextScene.previousScene == null)
                {
                    nextScene.previousScene = currentScene;
                    nextScene.sceneManager = this;
                }
            }

            currentScene = nextScene;

            if (currentScene is Scenes.Quit)
            {
                isActive = false;
            }
        }
    }
}
