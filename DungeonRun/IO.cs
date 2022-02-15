using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterKat.DungeonRun
{
    public static class IO
    {
        #region PrintCommands
        public static void Println() => Console.WriteLine();

        public static void Println(string _string) => Console.WriteLine(_string);

        public static void Print(string _string) => Console.Write(_string);
        #endregion

        #region GetCommands

        public static string GetInput()
        {
            return Console.ReadLine() ?? "";
        }
        public static bool GetInt(out int _inputInt)
        {
            string? _input = Console.ReadLine();
            if (_input == null)
            {
                _inputInt = -1;
                return false;
            }
            return int.TryParse(_input, out _inputInt);
        }

        #endregion

        #region AskForCommands

        #region AskForYesOrNo
        public static bool AskForYesOrNo()
        {
            return AskForString(true,"y", "n").Equals("y");
        }
        public static bool AskForYesOrNo(string _prompt)
        {
            return AskForString(_prompt, true, "y", "n").Equals("y");
        }
        #endregion

        #region AskForString
        public static string AskForString(bool _displayOptions, params string[] _responseOptions)
        {
            if (_responseOptions == null || _responseOptions.Length == 0)
            {
                return IO.GetInput();
            }

            string prompt = "";
            if (_displayOptions)
            {
                prompt = "( ";
                for (int i = 0; i < _responseOptions.Length; i++)
                {
                    prompt += _responseOptions[i];
                    if (i != _responseOptions.Length - 1)
                    {
                        prompt += ", ";
                    }
                }
                prompt += " )\n";
            }

            string input = "";
            bool inputValid = false;

            while (!inputValid)
            {
                IO.Print(prompt);
                input = IO.GetInput();

                for (int i = 0; i < _responseOptions.Length; i++)
                {
                    if (input.Equals(_responseOptions[i]))
                    {
                        inputValid = true;
                        break;
                    }
                }
                if (!inputValid)
                    IO.Println("Your input was invalid, please try again");
            }
            return input;
        }

        public static string AskForString(string _prompt, bool _displayOptions, params string[] _responseOptions)
        {
            IO.Print(_prompt);
            return AskForString(_displayOptions, _responseOptions);
        }

        public static string AskForStringWithConfirm(string _prompt, bool _displayOptions, params string[] _responseOptions)
        {
            string input = "";
            bool inputIsCorrect = false;

            while (!inputIsCorrect)
            {
                input = AskForString(_prompt, true, _responseOptions);

                IO.Print("You responded \""+input+"\" is that correct? ");
                inputIsCorrect = AskForYesOrNo();
            }

            return input;
        }
        #endregion

        #region AskForInt
        public static int AskForInt(string _prompt, params int[] _responseOptions)
        {
            int input = -1;
            bool validInput = false;
            while (!validInput)
            {
                IO.Print(_prompt);
                validInput = GetInt(out input);
            }
            return input;
        }
        #endregion

        #endregion

        public static void Pause()
        {
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
