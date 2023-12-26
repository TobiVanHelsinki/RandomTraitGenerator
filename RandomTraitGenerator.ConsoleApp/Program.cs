using System;

namespace RandomTraitGenerator.NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string Data = IO.GetFileContent(args.Length > 0 ? args[0] : null);
                Generator.Setup(Data);
            }
            catch (Exception)
            {
                return;
            }
            ConsoleKeyInfo Key;
            do
            {
                Generator.GeneratePermutation();
                Key = Console.ReadKey(true);
            }
            while (Key.Key == ConsoleKey.Enter);
        }
    }
}
