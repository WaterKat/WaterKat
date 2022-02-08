using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterKat.GameAssets.SceneManagement;

namespace WaterKat.DungeonRun.Scenes
{
    public class Title : Scene
    {
        public override Scene Update()
        {
            Console.WriteLine("WaterKatLLC Apps");
            Console.WriteLine("Initializing...");
            Console.WriteLine();
            Console.WriteLine("Welcome to your adventurous Dungeon Run!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine(
        "   /\\    /\\        /\\  /\\  /\\      /\\   \n" +
        "  /\\/\\  /\\/\\  /\\  /\\/\\/\\/\\/\\/\\    /\\/\\  \n" +
        " /\\/\\ \\/    \\/\\/\\/    \\  /    \\/\\/    \\ \n" +
        "/    \\/      \\   \\     \\/     /  \\     \\ \n");

            return new Menu();   
        }
    }
}
