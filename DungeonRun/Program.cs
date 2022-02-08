using System;
using WaterKat.GameAssets.SceneManagement;

namespace WaterKat.DungeonRun
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SceneManager sceneManager = new SceneManager();
            bool isRunning = true;

            while(isRunning)
            {
                sceneManager.Update();
                isRunning = sceneManager.isActive;
            }
            Console.WriteLine("Quitting...");
        }
    }
}