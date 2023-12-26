using System;
using System.IO;

namespace RandomTraitGenerator
{
    public static class IO
    {
        /// <summary>
        /// Uses dot net Standard File Methods to retrieve a File
        /// 1. Attempt: from parameter
        /// 1. Attempt: from first xml file in current folder
        /// 
        /// needs permitions to current folder and to parameter file
        /// </summary>
        /// <param name="fileloc"></param>
        /// <returns></returns>
        public static string GetFileContent(string fileloc = null)
        {
            string fileName;
            if (fileloc != null)
            {
                fileName = fileloc;
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(".");
                var Files = directoryInfo.GetFiles("*.xml");
                if (Files.Length == 0)
                {
                    Console.WriteLine("There is no xml File in current folder press something to exit");
                    Console.ReadKey();
                    throw new Exception();
                }
                else if (Files.Length > 1)
                {
                    Console.WriteLine($"There are more then one xml File in current folder, taking {Files[0].Name}");
                    fileName = Files[0].FullName;
                }
                else
                {
                    Console.WriteLine($"Taking data from {Files[0].Name}");
                    fileName = Files[0].FullName;
                }
            }
            var F = new FileInfo(fileName);
            if (F.Exists)
            {
                return File.ReadAllText(F.FullName);
            }
            else
            {
                Console.WriteLine("Could not load you file at " + F.FullName);
                throw new Exception();
            }
        }
    }
}
