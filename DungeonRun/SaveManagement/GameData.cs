using WaterKat.DungeonRun.EntityElements.PlayerElements;

namespace WaterKat.DungeonRun.SaveManagement
{
    [System.Serializable]
    public struct GameData
    {
        public string version = "0.0.1";

        public string WorldName = "Aeliroth";
        public string GoalLocationName = "Vandel";
        public string GoalItemName = "Ring";

        public PlayerCharacter playerCharacter = new PlayerCharacter();
        public int valueA;
        public int valueB;
    }
}
