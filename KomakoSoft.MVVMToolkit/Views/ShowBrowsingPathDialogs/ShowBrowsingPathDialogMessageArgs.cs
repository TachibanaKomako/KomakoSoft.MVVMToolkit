using KomakoSoft.MVVMToolkit.Messengers;
using KomakoSoft.MVVMToolkit.Views.ShowBrowsingPathDialogs.Components.Messengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomakoSoft.MVVMToolkit.Views.ShowBrowsingPathDialogs
{
    public sealed class ShowBrowsingPathDialogMessageArgs : MessageArgs
    {
        public string Title { get; set; }
        public string DefaultPath { get; set; }
        public string Filter { get; set; }
        public BrowsingType BrowsingType { get; set; }
        public PathType PathType { get; set; }
        public Action<(bool successed, string browsedPath)> Callback { get; set; }
        public override IMessenger GetDefaultMessenger()
        {
            return new DefaultShowBrowsingPathDialogMessenger();
        }
    }
}
