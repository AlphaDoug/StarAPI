using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarApiTool
{
    public class FileWatcher
    {
        string watchPath;
        FileSystemWatcher watcher;
        public FileWatcher(string path)
        {
            watchPath = path;
            StartWatch();
        }
        ~FileWatcher()
        {
            EndWatch();
        }

        void StartWatch()
        {
            watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = watchPath;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            //设置监视文件的哪些修改行为
            watcher.NotifyFilter = NotifyFilters.LastAccess
                | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;


            watcher.Filter = "*.md";

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;
        }

        void EndWatch()
        {
            if (watcher != null)
            {
                watcher.Dispose();
            }
        }

        void OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.Name != null && !e.Name.StartsWith(".~"))
            {
                Debug.WriteLine("File：{0} {1}！", e.FullPath, e.ChangeType);
            }
            
        }

        void OnRenamed(object source, RenamedEventArgs e)
        {
            Debug.WriteLine("File：{0} renamed to\n{1}", e.OldFullPath, e.FullPath);
        }

    }
}
