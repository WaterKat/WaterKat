using System;

namespace WaterKat.GameAssets.SceneManagement
{
    public abstract class Scene
    {
        public Scene previousScene;
        public virtual Scene Update()
        {
            Console.WriteLine("Unimplemented scene is running.");
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            return previousScene != null ? previousScene : new Scenes.Quit();
        }
    }
}