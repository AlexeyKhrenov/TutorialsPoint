using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.GzipConverter
{
    class MainClass
    {
        private static string fileToCompress = @"C:\dev\fileTrash\fileToCompress.txt";

        public static void Run()
        {
            var readResult = FileReader.ReadSingleThreaded(fileToCompress);

            var compressedResult = GzipCompressor.CompressBytes(readResult);

            FileWriter.WriteBlock(compressedResult);
        }
    }
}
