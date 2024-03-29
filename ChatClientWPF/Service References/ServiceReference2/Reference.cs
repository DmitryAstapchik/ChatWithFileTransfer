﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatClientWPF.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IChat", CallbackContract=typeof(ChatClientWPF.ServiceReference2.IChatCallback))]
    public interface IChat {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Join")]
        void Join(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Join")]
        System.Threading.Tasks.Task JoinAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Leave")]
        void Leave(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Leave")]
        System.Threading.Tasks.Task LeaveAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/SendMessage")]
        void SendMessage(string from, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/SendMessage")]
        System.Threading.Tasks.Task SendMessageAsync(string from, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/SendPrivateMessage")]
        void SendPrivateMessage(string from, string message, string to);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/SendPrivateMessage")]
        System.Threading.Tasks.Task SendPrivateMessageAsync(string from, string message, string to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/GetNames", ReplyAction="http://tempuri.org/IChat/GetNamesResponse")]
        string[] GetNames();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/GetNames", ReplyAction="http://tempuri.org/IChat/GetNamesResponse")]
        System.Threading.Tasks.Task<string[]> GetNamesAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/ReceiveNames")]
        void ReceiveNames(string from, string to);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/ReceiveNames")]
        System.Threading.Tasks.Task ReceiveNamesAsync(string from, string to);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/SendAccepted")]
        void SendAccepted();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/SendAccepted")]
        System.Threading.Tasks.Task SendAcceptedAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/SendRejected")]
        void SendRejected();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/SendRejected")]
        System.Threading.Tasks.Task SendRejectedAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/BlockFileSending")]
        void BlockFileSending();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/BlockFileSending")]
        System.Threading.Tasks.Task BlockFileSendingAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/UnblockFileSending")]
        void UnblockFileSending();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/UnblockFileSending")]
        System.Threading.Tasks.Task UnblockFileSendingAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Add")]
        void Add(string name, bool showMessage);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Remove")]
        void Remove(string name, bool showMessage);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/PrintMessage")]
        void PrintMessage(string from, string message, bool isPrivate);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/ReceiveStream")]
        void ReceiveStream();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/ReceiveAccepted")]
        void ReceiveAccepted();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/ReceiveRejected")]
        void ReceiveRejected();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Block")]
        void Block();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Unblock")]
        void Unblock();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatChannel : ChatClientWPF.ServiceReference2.IChat, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatClient : System.ServiceModel.DuplexClientBase<ChatClientWPF.ServiceReference2.IChat>, ChatClientWPF.ServiceReference2.IChat {
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Join(string name) {
            base.Channel.Join(name);
        }
        
        public System.Threading.Tasks.Task JoinAsync(string name) {
            return base.Channel.JoinAsync(name);
        }
        
        public void Leave(string name) {
            base.Channel.Leave(name);
        }
        
        public System.Threading.Tasks.Task LeaveAsync(string name) {
            return base.Channel.LeaveAsync(name);
        }
        
        public void SendMessage(string from, string message) {
            base.Channel.SendMessage(from, message);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(string from, string message) {
            return base.Channel.SendMessageAsync(from, message);
        }
        
        public void SendPrivateMessage(string from, string message, string to) {
            base.Channel.SendPrivateMessage(from, message, to);
        }
        
        public System.Threading.Tasks.Task SendPrivateMessageAsync(string from, string message, string to) {
            return base.Channel.SendPrivateMessageAsync(from, message, to);
        }
        
        public string[] GetNames() {
            return base.Channel.GetNames();
        }
        
        public System.Threading.Tasks.Task<string[]> GetNamesAsync() {
            return base.Channel.GetNamesAsync();
        }
        
        public void ReceiveNames(string from, string to) {
            base.Channel.ReceiveNames(from, to);
        }
        
        public System.Threading.Tasks.Task ReceiveNamesAsync(string from, string to) {
            return base.Channel.ReceiveNamesAsync(from, to);
        }
        
        public void SendAccepted() {
            base.Channel.SendAccepted();
        }
        
        public System.Threading.Tasks.Task SendAcceptedAsync() {
            return base.Channel.SendAcceptedAsync();
        }
        
        public void SendRejected() {
            base.Channel.SendRejected();
        }
        
        public System.Threading.Tasks.Task SendRejectedAsync() {
            return base.Channel.SendRejectedAsync();
        }
        
        public void BlockFileSending() {
            base.Channel.BlockFileSending();
        }
        
        public System.Threading.Tasks.Task BlockFileSendingAsync() {
            return base.Channel.BlockFileSendingAsync();
        }
        
        public void UnblockFileSending() {
            base.Channel.UnblockFileSending();
        }
        
        public System.Threading.Tasks.Task UnblockFileSendingAsync() {
            return base.Channel.UnblockFileSendingAsync();
        }
    }
}
