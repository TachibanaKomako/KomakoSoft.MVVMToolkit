using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomakoSoft.MVVMToolkit.Messengers
{
    public interface IMessenger
    {
        void Send(MessageArgs args);
    }
}
