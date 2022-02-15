using WaterKat.DungeonRun.SaveManagement;

namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    internal class LoadGame : Scene
    {
        public override Scene Update()
        {
            IO.Println("You wish to load a new adventure?");
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
            slots.Add(-1);

            int desiredSlot = IO.AskForInt("Please select a save slot.\nSlot: ", slots.ToArray<int>());
            if (desiredSlot !=-1)
            {
                bool loadSuccess = SaveManager.LoadData(desiredSlot, out sceneManager.GameData);
                if (!loadSuccess)
                {
                    IO.Println("Uh Oh, there was an error loading you save.");
                    IO.Println();
                    return previousScene ?? new Title();
                }
                else
                {
                    IO.Println("Your game was successfully loaded");
                    IO.Println();
                }
            }
            else
            {
                IO.Println("Canceling load, going back to Menu");
                return previousScene ?? new Title();
            }

            IO.Println();

            return  new Introduction();
        }
    }
}