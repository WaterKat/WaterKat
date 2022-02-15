using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterKat.DungeonRun.SceneManagement
{
    public abstract class Scene : WaterKat.GameAssets.SceneManagement.Scene
    {
        public new DRSceneManager? sceneManager = null;
        public new Scene? previousScene = null;
    }
}
