using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WaterKat.GameAssets.SceneManagement;
using System.Text;


namespace WaterKat.DungeonRun.Scenes
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
            IO.Println("Pick an option...");

            int optionCount = Enum.GetNames(typeof(MenuOption)).Length;

            for (int i = 0; i < optionCount; i++)
            {
                IO.Print("[" + i + "] ");
                IO.Println(((MenuOption)i).ToString().Replace('_',' '));
            }

            int input = -1;
            bool isValidInput = int.TryParse(IO.GetInput(), out input);

            if (!isValidInput)
            {
                DisplayErrorPrompt(); 
                return this;
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
