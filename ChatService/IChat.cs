using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ChatService
{
    [ServiceContract(CallbackContract = typeof(ICallbackContract))]
    public interface IChat
    {
        [OperationContract(IsOneWay = true)]
        void Join(string name);

        [OperationContract(IsOneWay = true)]
        void Leave(string name);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string from, string message);

        [OperationContract(IsOneWay = true)]
        void SendPrivateMessage(string from, string message, string to);

        [OperationContract]
        string[] GetNames();

        [OperationContract(IsOneWay = true)]
        void ReceiveNames(string from, string to);

        [OperationContract(IsOneWay = true)]
        void SendAccepted();

        [OperationContract(IsOneWay = true)]
        void SendRejected();

        [OperationContract(IsOneWay = true)]
        void BlockFileSending();

        [OperationContract(IsOneWay = true)]
        void UnblockFileSending();
    }

    public interface ICallbackContract
    {
        [OperationContract(IsOneWay = true)]
        void Add(string name, bool showMessage);

        [OperationContract(IsOneWay = true)]
        void Remove(string name, bool showMessage);

        [OperationContract(IsOneWay = true)]
        void PrintMessage(string from, string message, bool isPrivate);

        [OperationContract(IsOneWay = true)]
        void ReceiveStream();

        [OperationContract(IsOneWay = true)]
        void ReceiveAccepted();

        [OperationContract(IsOneWay = true)]
        void ReceiveRejected();

        [OperationContract(IsOneWay = true)]
        void Block();

        [OperationContract(IsOneWay = true)]
        void Unblock();
    }

    [DataContract]
    public class ChatData
    {
        [DataMember]
        public string receiver;

        [DataMember]
        public string sender;

        [DataMember]
        public IDictionary<string, ICallbackContract> Users { get; set; } = new Dictionary<string, ICallbackContract>();
    }
}
