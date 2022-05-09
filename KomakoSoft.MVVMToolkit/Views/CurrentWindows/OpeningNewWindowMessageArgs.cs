using KomakoSoft.MVVMToolkit.Messengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KomakoSoft.MVVMToolkit.Views.CurrentWindows
{
    public sealed class OpeningNewWindowMessageArgs : MessageArgs
    {
        public TheMessenger TheMessenger { get; set; }
        public Window NewWindow { get; set; }

        public override IMessenger GetDefaultMessenger()
        {
            return DefaultMessenger.Instance;
        }

        class DefaultMessenger : Messenger<OpeningNewWindowMessageArgs>
        {
            public static readonly DefaultMessenger Instance = new();

            private readonly List<(Window parent, Window child)> infos = new();
            public override void SendI(OpeningNewWindowMessageArgs args)
            {
                args.TheMessenger.Send(new GettingCurrentWindowMessageArgs()
                {
                    Callback = (w) =>
                    {
                        OpenChildWindow(w, args.NewWindow);
                    }
                });
            }
            private void OpenChildWindow(Window parent, Window child)
            {
                infos.Add((parent, child));
                parent.Visibility = Visibility.Hidden;
                child.Closed += Child_Closed;
                child.Show();
            }

            private void Child_Closed(object sender, EventArgs e)
            {
                var items = infos.Where(f => f.child == sender).ToArray();
                foreach (var item in items)
                {
                    item.child.Closed -= Child_Closed;
                    item.parent.Visibility = Visibility.Visible;
                    infos.Remove(item);
                }
            }
        }
    }
}
