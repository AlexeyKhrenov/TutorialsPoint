using System;

namespace HutterPrize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Compression started");
            new CompressorWrapper().Run();
        }
    }
}
