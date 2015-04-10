using System;
using System.IO;
using System.Net;
using Ionic.Zip;
using ManyConsole;

namespace FindFileInZip
{
    public class FindCommand : ConsoleCommand
    {
        private string dictionaryPath; // Dictionary directory path or zip file path.
        private string pathInZip; // Search path in zip file.

        public FindCommand()
        {
            IsCommand("find", "find file in zip.");
            HasRequiredOption("d|dictionaryPath=", "The dictionary directory path or zip file path", v => dictionaryPath = v);
            HasRequiredOption("p|pathInZip=", "The search path in zip file", v => pathInZip = v);
        }

        public override int Run(string[] remainingArguments)
        {
            var zipFiles = new DirectoryInfo(dictionaryPath).GetFiles("*.zip", SearchOption.TopDirectoryOnly);

            pathInZip = WebUtility.UrlDecode(pathInZip);

            var found = false;
            foreach (var zipFile in zipFiles)
            {
                using (var zip = ZipFile.Read(zipFile.FullName))
                {
                    foreach (var zipEntry in zip.Entries)
                    {
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        var path = zipEntry.FileName.Replace('\\', '/');
                        // Console.WriteLine(path);
                        if (path == pathInZip)
                        {
                            found = true;
                            Console.WriteLine("{0} in {1}", pathInZip, zipFile.FullName);
                            break;
                        }

                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("{0} is not found.", pathInZip);
            }

            Console.WriteLine("Please press some keys.");
            Console.ReadKey();
            return 0;
        }
    }
}