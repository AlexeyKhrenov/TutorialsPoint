using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.GzipConverter
{
    class FileWriter
    {
        private static string filePath = @"C:\dev\fileTrash\outputFile.kzp";

        //todo - change method signature in future
        public static void WriteBlock(MemoryStream input)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                input.WriteTo(fileStream);
            }
        }
    }
}
