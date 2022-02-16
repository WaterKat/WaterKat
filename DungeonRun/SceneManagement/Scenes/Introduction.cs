using WaterKat.DungeonRun.SceneManagement;

namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    public class Introduction : Scene
    {
        public override Scene Update()
        {
            if (sceneManager == null)
                return new Reset();

            string input;
            bool inputIsCorrect;

            string worldName = IO.AskForStringWithConfirm("In the a great world named... ", true);
            sceneManager.GameData.WorldName = worldName;

            string characterName = IO.AskForStringWithConfirm("You, a lone adventurer, sit near a campfire. Your name is ... ", true);
            sceneManager.GameData.playerCharacter.MetaData.Name = characterName;
            
            string goalLocationName = IO.AskForStringWithConfirm("And you are making your way to... ", true);
            sceneManager.GameData.GoalLocationName = goalLocationName;

            string goalItemName = IO.AskForStringWithConfirm("Once there you will find your prized... ", true);
            sceneManager.GameData.GoalLocationName = goalItemName;

            return new SaveMenu(new Level_0());
        }
    }
}