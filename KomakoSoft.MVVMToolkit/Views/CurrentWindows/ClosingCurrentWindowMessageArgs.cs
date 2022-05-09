using KomakoSoft.MVVMToolkit.Messengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomakoSoft.MVVMToolkit.Views.CurrentWindows
{
    public class ClosingCurrentWindowMessageArgs : MessageArgs
    {
        public TheMessenger TheMessenger { get; set; }
        public override IMessenger GetDefaultMessenger()
        {
            return DefaultMessenger.Instance;
        }

        class DefaultMessenger : Messenger<ClosingCurrentWindowMessageArgs>
        {
            public static readonly DefaultMessenger Instance = new DefaultMessenger();
            public override void SendI(ClosingCurrentWindowMessageArgs args)
            {
                args.TheMessenger.Send(new GettingCurrentWindowMessageArgs
                {
                    Callback = (w) =>
                    {
                        w.Close();
                    }
                });
            }
        }
    }
}
