using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace dz1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //parameter check
            try
            {
                if (!System.IO.Directory.Exists(args[0]))
                {
                    throw new Exception("incorrect input");
                }
                using (StreamWriter sw = File.CreateText(args[1])){};
            }
            catch
            {
                Console.WriteLine("incorrect input");
                return;
            } 

            string[] filesPath = Directory.GetFiles(args[0], "*.txt", SearchOption.AllDirectories);
            List<FileInfo> files= new List<FileInfo>();
            foreach (var path in filesPath)
            {
                files.Add(new FileInfo(path));
            }

            var sorted = files.OrderBy(x => x.Name);
            foreach (var path in sorted)
            {
                Console.WriteLine(path);
            }
            MergeFiles(args[1], sorted);
        }

        static void MergeFiles(string writingPath, IOrderedEnumerable<FileInfo> sortedFiles)
        {
            foreach (FileInfo file in sortedFiles)
            {
                var content =File.ReadAllLines(file.ToString());
                File.AppendAllLines(writingPath,content);
            }
        }
    }
}