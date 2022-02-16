using WaterKat.DungeonRun.SaveManagement;

namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    internal class SaveMenu : Scene
    {
        private Scene nextScene;

        public SaveMenu(Scene _nextScene)
        {
            nextScene = _nextScene;
            nextScene.previousScene = previousScene;
        }

        public override Scene Update()
        {
            if (sceneManager == null)
                return nextScene;

            /*
            bool shouldSave = IO.AskForYesOrNo("Would you like to save your progress?");
            if (!shouldSave)
                return nextScene;
            */

            bool shouldSaveToSameSlot = IO.AskForYesOrNo("Would you like to save to the same slot? Slot: ["+sceneManager.SaveSlot.ToString()+"]");
            if (shouldSaveToSameSlot)
            {
                SaveManager.SaveData(sceneManager.SaveSlot, sceneManager.GameData);
                return nextScene;
            }

            int availableSlot = 0;
            List<int> slots = new List<int>();
            while (SaveManagement.SaveManager.SaveFileExists(availableSlot))
            {
                GameData gameData;
                bool loadSuccess = SaveManagement.SaveManager.LoadData(availableSlot, out gameData);
                if (loadSuccess)
                {
                    IO.Println("[" + availableSlot.ToString() + "] " + gameData.WorldName);
                    slots.Add(availableSlot);
                    availableSlot++;
                }
            }
            IO.Println("[" + availableSlot.ToString() + "] New Save");
            slots.Add(availableSlot);
            IO.Println();
            IO.Println("[-1] Do not save"); 
            slots.Add(-1);

            int saveSlot = IO.AskForInt("Which slot would you like to save to?");
            if (saveSlot==-1)
            {
                IO.Print("Opted to not save.");
                IO.Println();
                return nextScene;
            }

            sceneManager.SaveSlot = saveSlot;

            IO.Println("Saving world " + sceneManager.GameData.WorldName + " to slot [" + sceneManager.SaveSlot + "]...");
            SaveManager.SaveData(sceneManager.SaveSlot, sceneManager.GameData);
            IO.Println("Sucess!");
            IO.Println();

            return nextScene;
        }
    }
}