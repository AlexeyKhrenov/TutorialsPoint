using System;

namespace HutterPrize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Compression started");
            new CompressorWrapper(ReportProgress, 100).Run();
            Console.ReadKey();
        }

        static void ReportProgress(double percent)
        {
            Console.Write("\r{0}%               ", percent);
        }
    }
}
