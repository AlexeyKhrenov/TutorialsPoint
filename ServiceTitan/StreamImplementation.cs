using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceTitan
{
    public abstract class StreamBase : Stream
    {
        protected long _position;
        public override bool CanSeek { get; } = false;

        //TODO: implement using of this length
        public override long Length { get; }

        public override long Position
        {
            get => _position;
            set
            {
                if (_position != value) throw new NotSupportedException();
            }
        }

        //TODO: implement
        public override bool CanTimeout => base.CanTimeout;

        public override void Flush() { }

        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();
        public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
    }

    public class PushStreamImpl : StreamBase
    {
        public override bool CanWrite => true;
        public override bool CanRead => false;

        private Stream buffer;

        public PushStreamImpl(Stream buffer)
        {
            this.buffer = buffer;
        }

        public override void Write(byte[] buffer, int offset, int count) =>
            Task.Run(() => WriteAsync(buffer, offset, count, CancellationToken.None)).Wait();

        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            // Implement this method
            throw new NotImplementedException();
        }
    }

    public class PullStreamImpl : StreamBase
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;

        public PullStreamImpl(Stream buffer)
        {

        }

        public override int Read(byte[] buffer, int offset, int count) =>
            Task.Run(() => ReadAsync(buffer, offset, count, CancellationToken.None)).Result;

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count,
            CancellationToken cancellationToken)
        {
            // Implement this method
            throw new NotImplementedException();
        }
    }
}