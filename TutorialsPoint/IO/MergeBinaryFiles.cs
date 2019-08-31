﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TutorialsPoint.IO
{
    public class MergeBinaryFiles
    {
        private const String outputFileName = "autogeneratedFile.blob";
        static void Run(string[] args)
        {
            var arg = args;
            if (args.Length < 2)
            {
                throw new ArgumentException();
            }

            if (args[0] != "--path")
            {
                throw new ArgumentException();
            }

            var path = args[1];

            var files = Directory.EnumerateFiles(path).ToList();

            var outputFile = path + "\\" + outputFileName;

            var buffer = new MemoryStream(10000);

            using (var writeFileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                foreach (var file in files)
                {
                    using (var readFileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        readFileStream.CopyTo(writeFileStream);
                    }
                }
            }

            Console.WriteLine("Success");
        }
    }
}
