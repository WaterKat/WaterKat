using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    public class Title : Scene
    {
        public override Scene Update()
        {
            IO.Println("WaterKatLLC Apps");
            IO.Println("WaterKatLLC Apps");
            IO.Println("Initializing...");
            IO.Println();
            IO.Println(" Welcome to your adventurous Dungeon Run! ");
            IO.Println("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            IO.Println(@"   /\    /\  /\    /\  /\  /\      /\    ");
            IO.Println(@"  /\/\  /\/\/\/\  /\/\/\/\/\/\    /\/\   ");
            IO.Println(@" /\/\ \/    \/\/\/    \  /    \/\/    \  ");
            IO.Println(@"/    \/      \   \     \/     /  \     \ ");

            return new Menu();   
        }
    }
}
