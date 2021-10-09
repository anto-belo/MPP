using System;
using System.IO;
using System.Threading;
using MPP_1;

namespace MPP_2
{
    internal class Program
    {
        private static TaskQueue _copyQueue;
        private static int _copiedFilesAmount;

        public static void Main(string[] args)
        {
            _copyQueue = new TaskQueue(3);
            // if (args.Length != 2)
            // {
            //     Console.WriteLine("src and out paths required.");
            //     return;
            // }
            //
            // args[0] = args[0].Replace("\\", "\\\\");
            // args[1] = args[1].Replace("\\", "\\\\");
            //
            // CopyDirectory(args[0], args[1]);
            
            CopyDirectory("D:\\7-Zip","C:\\Users\\anton\\Desktop\\7-Zip");

            while (!_copyQueue.IsReadyToStop())
            {
            }

            Console.WriteLine("Copied " + _copiedFilesAmount + " files.");
        }

        private static void CopyDirectory(string srcPath, string destPath)
        {
            DirectoryInfo srcDir = new DirectoryInfo(srcPath);
            DirectoryInfo destDir = new DirectoryInfo(destPath);
            destPath += "\\";
            if (!srcDir.Exists)
            {
                Console.WriteLine("Src dir does not exists!");
                return;
            }

            if (!destDir.Exists)
            {
                destDir.Create();
            }

            foreach (FileInfo file in srcDir.GetFiles())
            {
                string curDest = destPath;
                _copyQueue.EnqueueTaskDelegate(() => { file.CopyTo(curDest + file.Name, true); });
                _copiedFilesAmount++;
            }

            foreach (DirectoryInfo directory in srcDir.GetDirectories())
            {
                CopyDirectory(directory.FullName, destPath + directory.Name);
            }
        }
    }
}