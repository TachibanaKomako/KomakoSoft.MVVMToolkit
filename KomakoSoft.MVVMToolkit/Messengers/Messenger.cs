using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomakoSoft.MVVMToolkit.Messengers
{
    public abstract class Messenger<T> : IMessenger
        where T : MessageArgs
    {
        public void Send(MessageArgs args)
        {
            SendI((T)args);
        }
        public abstract void SendI(T args);
    }
}
