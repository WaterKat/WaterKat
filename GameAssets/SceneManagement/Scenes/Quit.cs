using System;

namespace WaterKat.GameAssets.SceneManagement.Scenes
{
    public class Quit : Scene 
    {
        public override Scene Update()
        {
            Console.WriteLine("Unimplemented Quit Sequence...");
            Console.WriteLine("Quitting...");
            return this;
        }
    }
}