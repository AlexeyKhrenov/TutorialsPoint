using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Threading;

namespace TutorialsPoint
{
    class FileReader
    {
        private static string fileLocation = @"C:\dev\fileTrash\downloads.rar";
        private static int blockSize = 1048576; //1MB

        private static int LogicalProcessorsNumber = 0;

        public static void Run()
        {
            //determing physical constants:
            LogicalProcessorsNumber = Environment.ProcessorCount;


            Console.WriteLine("Number of logical processors: "+LogicalProcessorsNumber);

            //for(var i = 0; i<10; i++)

            //FineTuneGarbageCollection(GCLatencyMode.LowLatency);
            //ReadSplitted();

            FineTuneGarbageCollection(GCLatencyMode.Interactive);
            ReadSplitted();

            FineTuneGarbageCollection(GCLatencyMode.SustainedLowLatency);
            ReadSplitted();

            FineTuneGarbageCollection(GCLatencyMode.Batch);
            ReadSplitted();

            FineTuneGarbageCollection(GCLatencyMode.NoGCRegion);
            ReadSplitted();

            Console.ReadLine();
        }

        public static void FineTuneGarbageCollection(GCLatencyMode mode)
        {
            GCSettings.LatencyMode = mode;

            var currentMode = GCSettings.LatencyMode;
            Console.WriteLine("Current GC mode: " + currentMode);
        }

        public static void ReadSingleThreadSplittedNumberCpu()
        {
            Stopwatch sw = new Stopwatch();
            List<byte[]> blocks = new List<byte[]>();

            using (FileStream source = new FileStream(fileLocation, FileMode.Open, FileAccess.Read))
            {
                blockSize = (int)source.Length / LogicalProcessorsNumber;
                sw.Start();

                int offset = 0;
                int i = 0;

                

                while (offset < source.Length)
                {
                    var block = Readblock(source, blockSize);
                    blocks.Add(block);
                    offset += blockSize;
                }

                sw.Stop();
            }
            Console.WriteLine("To read file " + sw.ElapsedMilliseconds);
            //Console.ReadKey();
        }

        public static void ReadWithTasksMegabyte()
        {
            Stopwatch sw = new Stopwatch();
            List<byte[]> blocks = new List<byte[]>();

            using (FileStream source = new FileStream(fileLocation, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous))
            {
                List<Action> actions = new List<Action>();

                int offset = 0;
                int tasks = 0;

                while (offset < source.Length)
                {
                    actions.Add(()=>
                    {
                        Interlocked.Increment(ref tasks);
                        Readblock(source, blockSize);
                    });
                    offset += blockSize;
                }
                sw.Start();


                Parallel.Invoke(actions.ToArray());

                sw.Stop();
                Console.WriteLine("To read file " + sw.ElapsedMilliseconds);
                //Console.ReadKey();
            }
        }

        private static byte[] Readblock(FileStream source, int length)
        {
            byte[] result = new byte[length];

            int arrayOffset = 0;

            //source.Seek(length, SeekOrigin.Current);
            source.Read(result, arrayOffset, length);
            return result;
        }
        private static void ReadSplitted()
        {
            Stopwatch sw = new Stopwatch();
            List<byte[]> blocks = new List<byte[]>();

            using (FileStream source = new FileStream(fileLocation, FileMode.Open, FileAccess.Read))
            {
                sw.Start();

                long offset = 0;

                int i = 0;
                Stopwatch ticker = new Stopwatch();
                ticker.Start();

                while (offset < source.Length)
                {
                    //if (i % 1000 == 0)
                    //{
                    //    ticker.Stop();
                    //    Console.WriteLine("Tick: " + ticker.ElapsedMilliseconds+" "+i);
                    //    ticker.Reset();
                    //    ticker.Start();
                    //}
                    //i++;

                    Readblock(source, blockSize);
                    //blocks.Add(block);
                    offset += blockSize;
                }

                sw.Stop();
            }
            Console.WriteLine("To read file " + sw.ElapsedMilliseconds);
        }
        private static void ReadAllAtOnceSingleThreaded()
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            using (FileStream fileSource = new FileStream(fileLocation, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fileSource.Length];
                int bytesBeginning = 0;
                long numberBytesToRead = fileSource.Length;
                fileSource.Read(bytes, bytesBeginning, (int)numberBytesToRead);
            }
            sw.Stop();
            Console.WriteLine("To read file " + sw.ElapsedMilliseconds);
        }

        public static byte[] ReadSingleThreaded(string fileLocation)
        {
            using (FileStream fileSource = new FileStream(fileLocation, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fileSource.Length];
                int bytesBeginning = 0;
                long numberBytesToRead = fileSource.Length;
                fileSource.Read(bytes, bytesBeginning, (int)numberBytesToRead);

                return bytes;
            }
        }
    }
}
