using WaterKat.DungeonRun.SaveManagement;

namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    internal class LoadGame : Scene
    {
        public override Scene Update()
        {
            IO.Println("You wish to load a new adventure?");
            int availableSlot = 0;
            while (SaveManagement.SaveManager.SaveFileExists(availableSlot))
            {
                GameData gameData;
                bool loadSuccess = SaveManagement.SaveManager.LoadData(availableSlot, out gameData);

                IO.Println("[" + availableSlot.ToString() + "] " + gameData.WorldName);
                availableSlot++;
            }


            IO.Println();


            return  new Introduction();
        }
    }
}