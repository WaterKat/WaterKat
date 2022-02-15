using WaterKat.DungeonRun.SceneManagement;

namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    public class Introduction : Scene
    {
        public override Scene Update()
        {
            string input;
            bool inputIsCorrect;

            input = IO.AskForStringWithConfirm("You, a lone adventurer, sit near a campfire, your name is ... ", true);
            sceneManager.GameData.playerCharacter.MetaData.Name = input;



            return this;
        }
    }
}