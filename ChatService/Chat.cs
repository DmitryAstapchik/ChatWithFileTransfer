using System.Linq;
using System.ServiceModel;
using System.Threading;

namespace ChatService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Chat : IChat
    {
        static readonly ChatData data = new ChatData();
        readonly ICallbackContract channel = OperationContext.Current.GetCallbackChannel<ICallbackContract>();
        public void Join(string name)
        {
            data.Users.Add(name, channel);
            foreach (var ch in data.Users.Values.Where(v => v != channel))
            {
                new Thread(() => ch.Add(name, true)).Start();            
            }
            foreach (var n in data.Users.Keys)
            {
                new Thread(() => channel.Add(n, false)).Start();
            }
        }

        public void Leave(string name)
        {
            data.Users.Remove(name);
            foreach (var ch in data.Users.Values)
            {
                new Thread(() => ch.Remove(name, true)).Start();                
            }
            new Thread(() => channel.Remove(name, false)).Start();
        }

        public void SendMessage(string from, string message)
        {
            foreach (var channel in data.Users.Values)
            {
                new Thread(() => channel.PrintMessage(from, message, false)).Start();
            }
        }

        public void SendPrivateMessage(string from, string message, string to)
        {
            new Thread(() => data.Users.First(u => u.Key == to).Value.PrintMessage(from, message, true)).Start();
            if (from != to)
            {
                new Thread(() => channel.PrintMessage(from, message, true)).Start();                
            }
        }

        public string[] GetNames()
        {
            return data.Users.Keys.ToArray();
        }

        public void ReceiveNames(string from, string to)
        {
            data.sender = from;
            data.receiver = to;
            data.Users.First(u => u.Key == to).Value.ReceiveStream();
        }

        public void SendAccepted()
        {
            data.Users.First(u => u.Key == data.sender).Value.ReceiveAccepted();
        }

        public void SendRejected()
        {
            data.Users.First(u => u.Key == data.sender).Value.ReceiveRejected();
        }

        public void BlockFileSending()
        {
            foreach (var user in data.Users)
            {
                user.Value.Block();
            }
        }

        public void UnblockFileSending()
        {
            foreach (var user in data.Users)
            {
                user.Value.Unblock();
            }
        }
    }
}
