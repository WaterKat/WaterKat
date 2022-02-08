using System;

namespace WaterKat.GameAssets.SceneManagement
{
    public abstract class Scene
    {
        public virtual Scene Update()
        {
            Console.WriteLine("Unimplemented scene is running.");
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            return this;
        }
    }
}