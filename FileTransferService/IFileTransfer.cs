using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace FileTransferService
{
    [ServiceContract]
    public interface IFileTransfer
    {
        [OperationContract]
        void ReceiveStream(Stream stream);

        [OperationContract]
        Stream SendStream();
    }

    [DataContract]
    public class Data
    {
        [DataMember]
        public Stream stream;
    }
}
