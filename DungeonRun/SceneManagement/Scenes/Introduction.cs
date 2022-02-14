using WaterKat.GameAssets.SceneManagement;

namespace WaterKat.DungeonRun.SceneManagement.Scenes
{
    public class Introduction : Scene
    {
        public override Scene Update()
        {
            string input;
            bool inputIsCorrect;

            input = IO.GetResponse("You, a lone adventurer, sit near a campfire, your name is ... ", true);

            /*
            input = "";
            inputIsCorrect = false;
            while (!inputIsCorrect)
            {
                input = IO.GetInput();
                IO.Println("");
                IO.Println("Your name is " + input + " right?");
                inputIsCorrect = IO.GetYOrN();
            }
            */



            return this;
        }
    }
}