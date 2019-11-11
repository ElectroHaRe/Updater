using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Updater.Base
{
    //Класс для расширения функционала класса DirectoryInfo
    static class DirectoryInfoExtension
    {
        //Событие завершения копирования файла
        public static event Action FileCopyCompleted;

        //Поле для хранения имён копируемых в данный момент файлов
        public static string CopiedFile = string.Empty;

        //Расширяющий метод Класса DirectoryInfo
        public static void CopyTo(this DirectoryInfo sourceDir, string destinationPath)
        {
            if (!sourceDir.Exists)
                throw new Exception("Directory " + sourceDir.FullName + " does not exist");

            var destinationDir = new DirectoryInfo(destinationPath);

            if (!destinationDir.Exists)
                destinationDir.Create();

            destinationDir = destinationDir.CreateSubdirectory(sourceDir.Name);

            Parallel.ForEach<DirectoryInfo>(sourceDir.GetDirectories(), dir =>
            {
                dir.CopyTo(destinationDir.FullName);
            });

            Parallel.ForEach<FileInfo>(sourceDir.GetFiles(), file =>
            {
                CopiedFile = file.Name;
                file.CopyTo(Path.Combine(destinationDir.FullName, file.Name));
                FileCopyCompleted?.Invoke();
            });
        }
    }
}
