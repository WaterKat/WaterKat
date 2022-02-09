using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterKat.DungeonRun
{
    public static class IO
    {
        public static void Println(string _string)
        {
            Console.WriteLine(_string);
        }
        public static void Print(string _string)
        {
            Console.Write(_string);
        }
        public static string? GetInput()
        {
            return Console.ReadLine();
        }
        public static void Pause()
        {
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
