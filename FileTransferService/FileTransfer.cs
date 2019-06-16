using System.IO;

namespace FileTransferService
{
    public class FileTransfer : IFileTransfer
    {
        static readonly Data data = new Data();
        public void ReceiveStream(Stream stream)
        {
            var memory = new MemoryStream();
            stream.CopyTo(memory);
            memory.Position = 0;
            data.stream = memory;
        }

        public Stream SendStream()
        {
            return data.stream;
        }
    }
}
