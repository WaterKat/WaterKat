using System;
using WaterKat.GameAssets.SceneManagement;
using WaterKat.DungeonRun.SceneManagement;
using WaterKat.DungeonRun.SceneManagement.Scenes;


namespace WaterKat.DungeonRun
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SceneManager sceneManager = new DRSceneManager(new Title());

            while(sceneManager.IsActive)
            {
                sceneManager.Update();
            }
            sceneManager.Update();  //This runs Quit Logic.
        }
    }
}