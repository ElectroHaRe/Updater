using System;
using System.IO;
using System.Threading.Tasks;

namespace Updater.Base
{
    static class DirectoryInfoExtension
    {
        public async static Task CopyTo(this DirectoryInfo Source, string Destination, Action<string> OnFileCopyCompleted = null)
        {
            if (!Source.Exists)
                throw new Exception("Directory " + Source.FullName + " does not exist");

            if (!Directory.Exists(Destination))
                Directory.CreateDirectory(Destination);

            Destination = Path.Combine(Destination, Source.Name);

            string filePath = string.Empty;

            foreach (string filename in Directory.EnumerateFiles(Source.FullName, "*", SearchOption.AllDirectories))
            {
                filePath = filename.Replace(Source.FullName, Destination);

                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (FileStream SourceStream = File.Open(filename, FileMode.Open))
                {
                    using (FileStream DestinationStream = File.Create(filePath))
                    {
                        await SourceStream.CopyToAsync(DestinationStream);
                        OnFileCopyCompleted?.Invoke(filename);
                    }
                }
            }
        }
    }
}
