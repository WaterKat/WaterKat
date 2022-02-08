using System;

namespace WaterKat.GameAssets.SceneManagement.Scenes
{
    public class Start : Scene
    {
        public override Scene Update()
        {
            Console.WriteLine("WaterKatLLC Apps");
            Console.WriteLine("Initializing...");
            Console.WriteLine();
            Console.WriteLine("Hello World!");
            Console.WriteLine("Press enter to quit");
            Console.ReadLine();
            return new Quit();
        }
    }
}
