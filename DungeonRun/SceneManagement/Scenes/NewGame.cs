
using WaterKat.DungeonRun.SaveManagement;

namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    internal class NewGame : Scene
    {
        public override Scene Update()
        {
            if (sceneManager == null)
                return new Reset();

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

            bool shouldCreateSave = IO.AskForYesOrNo("Would you like to create a new save?");

            if (shouldCreateSave)
            {
                sceneManager.GameData = new GameData();
                SaveManager.SaveData(availableSlot, sceneManager.GameData);
                return new Introduction();
            }
            else
            {
                return previousScene ?? new Menu();
            }
        }
    }
}