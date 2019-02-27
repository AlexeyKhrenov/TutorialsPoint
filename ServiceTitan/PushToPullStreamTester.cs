using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitan
{
    public class PushToPullStreamTester
    {
        public Func<IPushToPullStream> PushToPullFactory { get; set; }
        public Random Random1 { get; set; } = new Random(12345);
        public Random Random2 { get; set; } = new Random(54321);

        public void Test()
        {
            for (var l = 0; l < 100; l++)
                for (var s = 1; s <= 8; s <<= 1)
                    TestOne(l, s);
            TestOne(20000000, 8192, 0.001, 0);
            TestOne(20000000, 8192, 0, 0.001);
        }

        private void TestOne(long length, int maxChunkLength = 1024,
            double pushDelayProbability = 0,
            double pullDelayProbability = 0,
            int delayDurationInMilliseconds = 50)
        {
            using (var p2p = PushToPullFactory.Invoke())
            {
                long inputCrc = 0;
                long outputCrc = 0;

                var writerTask = Task.Run(async () => {
                    var buffer = new byte[maxChunkLength];
                    while (p2p.PushStream.Position < length)
                    {
                        var chunkSize = (int)Math.Min(
                            Random1.Next(1 + maxChunkLength),
                            length - p2p.PushStream.Position);
                        Random1.NextBytes(buffer);
                        AccumulateCrc(buffer, buffer.Length, ref inputCrc);
                        if (Random1.NextDouble() < pushDelayProbability)
                            await Task.Delay(delayDurationInMilliseconds);
                        await p2p.PushStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    p2p.CompleteWrite();
                });
                var readerTask = Task.Run(async () => {
                    var buffer = new byte[maxChunkLength];
                    var readLength = 1;
                    while (readLength > 0)
                    {
                        var chunkSize = 1 + Random2.Next(maxChunkLength);
                        if (Random1.NextDouble() < pullDelayProbability)
                            await Task.Delay(delayDurationInMilliseconds);
                        readLength = await p2p.PullStream.ReadAsync(buffer, 0, buffer.Length);
                        AccumulateCrc(buffer, readLength, ref outputCrc);
                    }
                });

                Task.WaitAll(writerTask, readerTask);
                if (inputCrc != outputCrc)
                    throw new InvalidOperationException("CRC check failed.");
            }
        }

        private void AccumulateCrc(byte[] buffer, int length, ref long crc)
        {
            unchecked
            {
                var c = crc;
                for (var i = 0; i < length; i++)
                {
                    var x = buffer[i];
                    c = 271 * c + x;
                }

                crc = c;
            }
        }
    }
}
