using System;
using WaterKat.GameAssets.SceneManagement;

namespace WaterKat.DungeonRun
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SceneManager sceneManager = new SceneManager(new Scenes.Title());

            while(sceneManager.IsActive)
            {
                sceneManager.Update();
            }
            sceneManager.Update();  //This runs Quit Logic.

        }
    }
}