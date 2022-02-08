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

        private StringBuilder stringBuilder = new StringBuilder();

        private void OutputString(string _output)
        {
            Console.WriteLine(_output);
        }
        private string? GetInput()
        {
            return Console.ReadLine();
        }

        public override Scene Update()
        {
            stringBuilder.AppendLine("Pick an option...");

            int optionCount = Enum.GetNames(typeof(MenuOption)).Length;

            for (int i = 0; i < optionCount; i++)
            {
                stringBuilder.Append("[" + i + "] ");
                stringBuilder.AppendLine(((MenuOption)i).ToString().Replace('_',' '));
            }

            OutputString(stringBuilder.ToString());
            stringBuilder.Clear();

            int input = -1;
            bool isValidInput = int.TryParse(GetInput(), out input);

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
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Input was not valid, please enter a valid integer option");
            stringBuilder.AppendLine();
            OutputString(stringBuilder.ToString());
            stringBuilder.Clear();
        }
    }
}
