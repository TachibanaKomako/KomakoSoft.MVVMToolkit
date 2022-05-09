using KomakoSoft.MVVMToolkit.Messengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomakoSoft.MVVMToolkit
{
    public sealed class TheMessenger
    {
        private readonly Dictionary<Type, IMessenger> messengers = new();

        public void Register<T>(Messenger<T> messenger)
            where T : MessageArgs
        {
            if (messengers.TryAdd(typeof(T), messenger) is false)
            {
                messengers[typeof(T)] = messenger;
            }
        }
        public IMessenger GetMessenger<T>(T args)
            where T : MessageArgs
        {
            return messengers.TryGetValue(typeof(T), out var mesenger)
                ? mesenger
                : args.GetDefaultMessenger();
        }
        public void Send<T>(T args)
            where T : MessageArgs
        {
            IMessenger messenger = GetMessenger(args);
            messenger.Send(args);
        }
    }
}
