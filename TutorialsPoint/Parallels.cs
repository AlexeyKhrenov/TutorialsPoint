using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TutorialsPoint
{
    class Parallels
    {
        public static long DirectoryBytes(String path, String searchPattern, SearchOption searchOption)
        {
            var files = Directory.EnumerateFiles(path, searchPattern, searchOption);

            long masterTotal = 0;

            ParallelLoopResult result = Parallel.ForEach<String, long>(
                files,
                () => { return 0; },
                (file, loopState, IndexOutOfRangeException, taskLocalTotal) =>
                {
                    long filelength = 0;
                    FileStream fs = null;
                    try
                    {
                        fs = File.OpenRead(file);
                        filelength = fs.Length;
                    }
                    catch (IOException ioe)
                    {
                    }
                    finally
                    {
                        if (fs != null) fs.Dispose();
                    }

                    return taskLocalTotal + filelength;
                },
                taskLocalTotal => { Interlocked.Add(ref masterTotal, taskLocalTotal); }
            );
            return masterTotal;
        }
    }
}
