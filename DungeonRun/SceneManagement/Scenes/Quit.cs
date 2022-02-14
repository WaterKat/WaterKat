using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterKat.GameAssets.SceneManagement;

namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    public class Quit : WaterKat.GameAssets.SceneManagement.Scenes.Quit
    {
        public override Scene Update()
        {
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Quitting...");
            return this;
        }
    }
}
