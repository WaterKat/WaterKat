using WaterKat.DungeonRun.SaveManagement;

namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    internal class LoadGame : Scene
    {
        public override Scene Update()
        {
            if (sceneManager == null)
                return new Quit();

            IO.Println("You wish to load a new adventure?");
            int availableSlot = 0;
            List<int> slots = new List<int>();
            if (SaveManager.SaveFileExists(availableSlot))
            {
                while (SaveManager.SaveFileExists(availableSlot))
                {
                    GameData gameData;
                    bool loadSuccess = SaveManager.LoadData(availableSlot, out gameData);
                    if (loadSuccess)
                    {
                        IO.Println("[" + availableSlot.ToString() + "] " + gameData.WorldName);
                        slots.Add(availableSlot);
                        availableSlot++;
                    }
                }
            }
            else
            {
                IO.Println("You have no save files.");
                IO.Println();
                return previousScene ?? new Menu();
            }

            slots.Add(-1);


            int desiredSlot = IO.AskForInt("Please select a save slot, or enter -1 to cancel load.\nSlot: ", slots.ToArray<int>());
            if (desiredSlot !=-1)
            {
                bool loadSuccess = SaveManager.LoadData(desiredSlot, out sceneManager.GameData);
                if (!loadSuccess)
                {
                    IO.Println("Uh Oh, there was an error loading you save.");
                    IO.Println();
                    return this;
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
                return new Menu();
            }

            IO.Println();

            return  new Introduction();
        }
    }
}