using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    public class Quit : Scene
    {
        public override Scene Update()
        {
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Quitting...");
            return this;
        }
    }
}
