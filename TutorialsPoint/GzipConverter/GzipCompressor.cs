using System.IO;
using System.IO.Compression;

namespace TutorialsPoint
{
    public class GzipCompressor
    {
        private static int arrayOffset = 0;

        public static MemoryStream CompressBytes(byte[] input)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream gz = new GZipStream(ms, CompressionMode.Compress);
            gz.Write(input, arrayOffset, input.Length);

            return ms;
        }
    }
}