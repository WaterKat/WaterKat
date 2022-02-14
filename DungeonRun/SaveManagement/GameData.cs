using WaterKat.GameAssets.EntityElements.PlayerElements;

namespace WaterKat.DungeonRun.SaveManagement
{
    [System.Serializable]
    public struct GameData
    {
        public string WorldName = "Aeliroth";
        public PlayerCharacter playerCharacter = new PlayerCharacter();
        public int valueA;
        public int valueB;
    }
}
