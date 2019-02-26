using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceTitan
{
    public class PushToPullStream : IPushToPullStream
    {
        public const int DefaultBufferSize = 8192;

        // You may declare the buffer elsewhere, but the important part about it is:
        // you should design your impl. in such a way this buffer is never exceeded.
        // I.e. if a writer (the code using PushStream) tries to write more data you
        // can actually buffer, it has to wait.
        public Stream PushStream { get; protected set; }
        public Stream PullStream { get; protected set; }

        private MemoryStream buffer = new MemoryStream();

        public PushToPullStream(int bufferSize = DefaultBufferSize)
        {
            buffer = new MemoryStream(bufferSize);

            PushStream = new PushStreamImpl(buffer);
            PullStream = new PullStreamImpl(buffer);
        }

        public virtual void CompleteWrite()
        {
            // Implement this method
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            PushStream?.Dispose();
            PushStream = null;
            PullStream?.Dispose();
            PullStream = null;
        }
    }
}
