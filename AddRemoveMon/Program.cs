using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddRemoveMon
{
    class Program
    {
        static void Main(string[] args)
        {
            String path;
            try
            {
                Console.WriteLine("Please enter a path to watch: ");
                path = Console.ReadLine();

                MonitorDirectory(path);
                Console.ReadKey();
            }
            catch (IOException)
            {
                Console.WriteLine("An error occured , please try again !");
            }

        }

        private static void MonitorDirectory(string path)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

            fileSystemWatcher.Path = path;
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private static void FileSystemWatcher_Renamed(object sender, FileSystemEventArgs e)

        {
            Console.WriteLine("File renamed: {0}", e.Name);
        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)

        {
            Console.WriteLine("File created: {0}", e.Name);
        }
        private static void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)

        {
            Console.WriteLine("File deleted: {0}", e.Name);
        }

    }
}
