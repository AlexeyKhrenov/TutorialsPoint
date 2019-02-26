using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceTitan
{
    public interface IPushToPullStream : IDisposable
    {
        Stream PushStream { get; } //will be used by GZipStream for example
        Stream PullStream { get; } //will be used by UploadFromStreamAsync (Azure)
        void CompleteWrite();
    }
}
