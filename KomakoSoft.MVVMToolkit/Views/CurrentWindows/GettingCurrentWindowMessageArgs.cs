using KomakoSoft.MVVMToolkit.Messengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KomakoSoft.MVVMToolkit.Views.CurrentWindows
{
    public sealed class GettingCurrentWindowMessageArgs : MessageArgs
    {
        public Action<Window> Callback { get; set; }
        public override IMessenger GetDefaultMessenger()
        {
            return DefaultMessenger.Instance;
        }
        class DefaultMessenger : Messenger<GettingCurrentWindowMessageArgs>
        {
            public static readonly DefaultMessenger Instance = new();
            public override void SendI(GettingCurrentWindowMessageArgs args)
            {
                Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                args.Callback?.Invoke(window);
            }
        }
    }
}
