using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterKat.DungeonRun.SceneManagement
{
    public abstract class Scene
    {
        public SceneManager? sceneManager;
        public Scene? previousScene;

        public virtual Scene Update()
        {
            Console.WriteLine("Unimplemented scene is running.");
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            return previousScene != null ? previousScene : new Scenes.Quit();
        }
    }
}
