using System;
using System.ServiceModel;
using ChatService;
using FileTransferService;

namespace ChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host1 = new ServiceHost(typeof(Chat));
            host1.Open();
            Console.WriteLine("Служба Chat запущена.");
            ServiceHost host2 = new ServiceHost(typeof(FileTransfer));
            host2.Open();
            Console.WriteLine("Служба FileTransfer запущена.");
            Console.WriteLine("Для выхода нажмите ENTER.");
            Console.Read();
            host1.Close();
            host2.Close();
        }
    }
}
