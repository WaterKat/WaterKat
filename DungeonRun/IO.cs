using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterKat.DungeonRun
{
    public static class IO
    {
        public static void Println() => Console.WriteLine();

        public static void Println(string _string) => Console.WriteLine(_string);

        public static void Print(string _string) => Console.Write(_string);

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

        internal static bool GetYOrN()
        {
            return GetResponse("(y/n)\n", new string[] { "y", "n" }).Equals("y");
        }

        public static string GetResponse(string _prompt, params string[] _responseOptions)
        {
            string input = "";
            bool inputValid = false;

            if ((_responseOptions == null)||(_responseOptions.Length==0))
            {
                IO.Print(_prompt);
                return IO.GetInput();
            }

            while (!inputValid)
            {
                IO.Print(_prompt);
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

        public static string GetResponse(string _prompt,bool _withConfirmation,params string[] _responseOptions)
        {
            if (!_withConfirmation)
                return GetResponse(_prompt, _responseOptions);

            string input = "";
            bool inputIsCorrect = false;

            while (!inputIsCorrect)
            {
                input = GetResponse(_prompt, _responseOptions);

                IO.Print("You responded \""+input+"\" is that correct? ");
                inputIsCorrect = GetYOrN();
            }

            return input;
        }


        public static string GetInput()
        {
            return Console.ReadLine() ?? "";
        }

        public static void Pause()
        {
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
