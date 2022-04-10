using System;
using System.IO;

namespace ArquivosAspNet
{
    public class Watcher
    {
        public void monitorar(String path) {
            var fsw = new FileSystemWatcher(path);

            fsw.Created += OnCreated;
            fsw.Deleted += OnDeleted;
            fsw.Renamed += OnRenamed;

            fsw.EnableRaisingEvents = true;
            fsw.IncludeSubdirectories = true;
        }
        //monitorar os arquivos......
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"O Arquivo {e.OldName} foi Renomeado para {e.Name}.");
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"O Arquivo foi Deletado {e.Name}.");
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"O Arquivo {e.Name} foi criado. ");
        }
    }
}
