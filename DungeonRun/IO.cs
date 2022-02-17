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
        public static void Print(string _string) => Console.Write(_string);
        public static void Println() => Print("\n");
        public static void Println(string _string) => Print(_string+"\n");

        #endregion

        #region ColorSettings
        public enum Color
        {
            Black,
            DarkBlue,
            DarkGreen,
            DarkCyan,
            DarkRed,
            DarkMagenta,
            DarkYellow,
            Gray,
            DarkGray,
            Blue,
            Green,
            Cyan,
            Red,
            Magenta,
            Yellow,
            White,
        }
        public static string GetIOCommand(this Color _this)
        {
            return "^C" + ((int)_this).ToString("D2") + " " + _this.ToString();
        }

        public static void SetTextColor(Color _color)
        {
            Console.ForegroundColor = (ConsoleColor)(int)_color;
        }
        public static void SetBackgroundColor(Color _color)
        {
            Console.BackgroundColor = (ConsoleColor)(int)_color;
        }

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

        #region AskForEnum

        public static bool AskForEnum<T>(string _prompt, out T? _selection, params T[] _responseOptions) where T : Enum
        {
            if ((_responseOptions == null) || (_responseOptions.Length < 1))
            {
                _selection = default(T);
                return false;
            }


            bool validInput = false;

            while (!validInput)
            {
                List<int> validOptions = new List<int>() { -1 };
                IO.Print(_prompt);
                for (int i = 0; i < _responseOptions.Length; i++)
                {
                    validOptions.Add(i);
                    IO.SetTextColor(Color.Cyan);
                    IO.Print("[" + i.ToString() + "] ");
                    IO.SetTextColor(Color.White);
                    IO.Print(_responseOptions[i].ToString());
                }
                int input;
                validInput = IO.GetInt(out input);
                if (validInput)
                {
                    validInput = validOptions.Contains(input);
                }
            }

            while (!validInput)
            {

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
        public static void Clear()
        {
            Console.Clear();
        }
    }
}
