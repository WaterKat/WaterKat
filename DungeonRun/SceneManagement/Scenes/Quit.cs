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
            IO.Println("Thanks for playing!");
            IO.SetTextColor(IO.Color.Red);
            IO.Println("Quitting...");
            IO.Pause();
            return this;
        }
    }
}
