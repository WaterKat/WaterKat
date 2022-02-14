using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterKat.GameAssets.SceneManagement;
using WaterKat.DungeonRun.SaveManagement;

namespace WaterKat.DungeonRun.SceneManagement
{
    public class DRSceneManager : SceneManager
    {
        public GameData GameData;
        public int SaveSlot;

        public DRSceneManager(Scene _scene) : base(_scene) { }
    }
}
