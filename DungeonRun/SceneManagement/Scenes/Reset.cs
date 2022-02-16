using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    public class Reset : Scene
    {
        public override Scene Update()
        {
            IO.Println("Catastrophic failure. Resetting.");
            IO.Println();
            IO.Println();
            IO.Println();
            return this;
        }
    }
}
