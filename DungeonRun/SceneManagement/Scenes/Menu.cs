using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text;


namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    public class Menu : Scene
    {
        public enum MenuOption
        {
            New_Game = 0,
            Load_Game = 1,
            Options = 2,
            Credits = 3,
            Quit = 4,
        }

        public override Scene Update()
        {
            IO.SetTextColor(IO.Color.Blue);
            IO.Println(" Welcome to your adventurous Dungeon Run! ");
            IO.Println("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            IO.SetTextColor(IO.Color.DarkGreen);
            IO.Println(@"   /\    /\  /\    /\  /\  /\      /\    ");
            IO.Println(@"  /\/\  /\/\/\/\  /\/\/\/\/\/\    /\/\   ");
            IO.Println(@" /\/\ \/    \/\/\/    \  /    \/\/    \  ");
            IO.Println(@"/    \/      \   \     \/     /  \     \ ");
            IO.SetTextColor(IO.Color.White);
            IO.Println("Pick an option...");

            int input = -1;
            bool isValidInput = false;
            while (!isValidInput)
            {
                isValidInput = IO.AskForChoice("Please select a menu option...", out input, Enum.GetNames(typeof(MenuOption)));
            }
            switch ((MenuOption)input)
            {
                case MenuOption.New_Game:
                    return new NewGame();
                case MenuOption.Load_Game:
                    return new LoadGame();
                case MenuOption.Options:
                    return new Options();
                case MenuOption.Credits:
                    return new Credits();
                case MenuOption.Quit:
                    return new Quit();
                default:
                    DisplayErrorPrompt();
                    return this;
            }
        }

        private void DisplayErrorPrompt()
        {
            IO.Println("\nInput was not valid, please enter a valid integer option\n");
        }
    }
}
