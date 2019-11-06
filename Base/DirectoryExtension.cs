using System;
using System.IO;
using System.Threading.Tasks;

namespace Updater.Base
{
    static class DirectoryExtension
    {
        public static void CopyTo(this DirectoryInfo sourceDir, string destinationPath)
        {
            if (!sourceDir.Exists)
                throw new Exception("Directory " + sourceDir.FullName + " does not exist");

            var destinationDir = new DirectoryInfo(destinationPath);

            if (!destinationDir.Exists)
                destinationDir.Create();

            destinationDir.CreateSubdirectory(sourceDir.Name);

            Parallel.ForEach<DirectoryInfo>(sourceDir.GetDirectories(), dir =>
            {
                dir.CopyTo(destinationDir.FullName);
            });

            Parallel.ForEach<FileInfo>(sourceDir.GetFiles(), file =>
            {
                file.CopyTo(destinationDir.FullName);
            });
        }
    }
}
