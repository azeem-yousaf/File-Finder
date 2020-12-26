using System;
using System.IO;

namespace File_Finder
{
    class Program
    {
        private static string fileName;
        /// <summary>
        /// This program allows the user to find a file within their pc
        /// </summary>
        /// <param name="args">[0] directory to look in (use / to search entire pc), [1] file name</param>
        static void Main(string[] args)
        {
            if (args == null || args.Length <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Try typing finder <directory> <filename>. If you enter / for directory then it will search all drives.");

                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            string directory = args[0];
            fileName = args[1];
            bool searchEntireSystem = directory == "/" ? true : false;

            if (searchEntireSystem)
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (var drive in drives)
                {
                    var folders = drive.RootDirectory;
                    FindFiles(folders);

                }
            }
            else
            {
                var dir = new DirectoryInfo(directory);
                FindFiles(dir);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }


        private static void FindFiles(DirectoryInfo folder)
        {
            try
            {
                foreach (var file in folder.GetFiles())
                {
                    if (file.Name.ToLower().Contains(fileName.ToLower())) PrintMatchFound(file.FullName);

                }
                foreach (var f in folder.GetDirectories())
                {
                    FindFiles(f);
                }
            }
            catch
            {
            }
        }
        private static void PrintMatchFound(string file)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(file);
        }
    }
}