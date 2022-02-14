using WaterKat.GameAssets.SceneManagement;
using WaterKat.DungeonRun.SaveManagement;

namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    internal class NewGame : Scene
    {
        public override Scene Update()
        {
            IO.Println("You wish to create a new adventure?");
            int availableSlot = 0;
            while (SaveManagement.SaveManager.SaveFileExists(availableSlot))
            {
                GameData gameData;
                bool loadSuccess = SaveManagement.SaveManager.LoadData(availableSlot, out gameData);

                IO.Println("[" + availableSlot.ToString() + "] " + gameData.WorldName);
                availableSlot++;
            }
            IO.Println("Slot: " + availableSlot + " is available");

            string prompt = "Would you like to create a new save? (y/n)";
            IO.Print(prompt);
            bool shouldCreateSave = IO.GetYOrN();
            
            string[] responses = new string[] { "y", "n" };
            string input = "";
            {
                bool isValidInput = false;
                while (!isValidInput)
                {
                    IO.Println(prompt);
                    input = IO.GetInput();
                    for (int i = 0; i < responses.Length; i++)
                    {
                        if (responses[i].Equals(input))
                        {
                            isValidInput = true;
                        }
                    }
                }
            }

            if (input.Equals("y"))
            {
                SaveManagement.SaveManager.SaveData(availableSlot, new GameData());
                return new Introduction();
            }
            else
            {
                return previousScene;
            }
        }
    }
}