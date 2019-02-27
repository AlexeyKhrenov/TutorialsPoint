using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceTitan
{
    class Program
    {
        public static void Main()
        {
            var tester = new PushToPullStreamTester()
            {
                PushToPullFactory = () => new PushToPullStream(100)
            };
            tester.Test();
            Console.WriteLine("Test passed.");
        }

        public static async Task RunAsyncContext()
        {
            await Task.WhenAll(
                Task.Run(() => CopyToAsync()),
                Task.Run(() => UploadFromStreamAsync(null))
            );
        }

        static void UploadFromStreamAsync(Stream pullStream)
        {
            Console.WriteLine("UploadFromStream async");
        }

        static void CopyToAsync()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Copy to async");
        }

        static async void Remain()
        {
            var source = new FileStream(string.Empty, FileMode.Append);

            using (var p2p = new PushToPullStream())
            using (var compressed = new GZipStream(p2p.PushStream, CompressionMode.Compress))
            {
                await Task.WhenAll(
                    Task.Run(() => source
                        .CopyToAsync(compressed) //Asynchronously reads the bytes from the current stream and writes them to another stream.
                        .ContinueWith(x => { //Creates a continuation that receives caller-supplied state information and executes when the target Task completes
                            compressed.Close();
                            p2p.CompleteWrite();
                        })),
                    Task.Run(() => UploadFromStreamAsync(p2p.PullStream))
                );
            }
        }
    }
}
