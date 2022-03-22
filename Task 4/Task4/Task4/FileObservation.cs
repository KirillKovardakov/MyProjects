using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Wacther
{
    public static class FileObservation
    {
        #region Observation
        public static void Observation()
        {
            using var watcher = new FileSystemWatcher(@"\\Mac\Home\Desktop\MyProjectsEPAM\Task 4\SomeFolder");

            watcher.NotifyFilter = NotifyFilters.Attributes
                                         | NotifyFilters.CreationTime
                                         | NotifyFilters.DirectoryName
                                         | NotifyFilters.FileName
                                         | NotifyFilters.LastAccess
                                         | NotifyFilters.LastWrite
                                         | NotifyFilters.Security
                                         | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;

            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.ReadKey(true);
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            var streamRead = File.ReadAllText(e.FullPath);
            using var file = new FileStream($@"\\Mac\Home\Desktop\MyProjectsEPAM\Task 4\ChangesFolder\{e.Name}", FileMode.Append);
            var streamWriter = new StreamWriter(file);
            streamWriter.WriteLine(DateTime.Now + Environment.NewLine + streamRead + Environment.NewLine);
            Console.WriteLine($"{DateTime.Now} Changed: {e.FullPath}"); //Отчёт, который просто так оставил
        }
        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            using var file = new FileStream($@"\\Mac\Home\Desktop\MyProjectsEPAM\Task 4\ChangesFolder\{e.Name}", FileMode.CreateNew);
            var streamWriter = new StreamWriter(file);
            streamWriter.WriteLine(DateTime.Now + Environment.NewLine);
            Console.WriteLine($"{DateTime.Now} Created: {e.FullPath}");
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            var path = $@"\\Mac\Home\Desktop\MyProjectsEPAM\Task 4\ChangesFolder\{e.Name}";
            FileInfo myFile = new(path);
            if (myFile.Exists)
                myFile.Delete();
            Console.WriteLine($"{DateTime.Now} Deleted: {e.FullPath}");
        }
        #endregion Observation
        public static void RollBackChanges(DateTime date)
        {
            var path = @"\\Mac\Home\Desktop\MyProjectsEPAM\Task 4\ChangesFolder";
            DirectoryInfo directoryInfo = new(path);
            foreach (var item in directoryInfo.GetFiles())
            {
                using var file = new FileStream($@"\\Mac\Home\Desktop\MyProjectsEPAM\Task 4\SomeFolder\{item.Name}", FileMode.Create);
                var streamWriter = new StreamWriter(file);
                using var fileChanges = new FileStream($@"\\Mac\Home\Desktop\MyProjectsEPAM\Task 4\ChangesFolder\{item.Name}", FileMode.Open);
                var streamReader = new StreamReader(fileChanges);
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line == date.ToString())
                    {
                        while (DateTime.TryParse(line, out DateTime d) && (line = streamReader.ReadLine()) != null)
                        {
                            streamWriter.WriteLine(line);
                        }
                    }
                }
                streamWriter.Close();
            }

        }
    }
}

