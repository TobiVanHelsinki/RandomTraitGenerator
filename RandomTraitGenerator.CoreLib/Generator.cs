using System;
using System.Linq;

namespace RandomTraitGenerator
{
    public static class Generator
    {
        static string XmlTraitData;
        public static void Setup(string _XmlTraitData)
        {
            XmlTraitData = _XmlTraitData;
            Console.WriteLine("Welcome to the Random Trait Generator! Press Enter to retry, pres anything else to Exit.");
        }

        public static void GeneratePermutation()
        {
            Console.WriteLine();
            foreach (var item in Data.String2Data(XmlTraitData))
            {
                var Traits = item.RandomTrait();
                Console.Write("{0,-15} {1}", item.Name, Traits.First().T.Name);
                if (Traits.Count() == 1)
                {
                    Console.WriteLine("");
                }
                if (Traits.Count() > 1)
                {
                    Console.WriteLine("\n    " + Traits.Skip(1).Aggregate("", (a, c) => a += c.List.Name + " " + c.T.Name));
                }
            }
        }

    }
}
