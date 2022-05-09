using KomakoSoft.MVVMToolkit.Messengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomakoSoft.MVVMToolkit.Views.ShowBrowsingPathDialogs.Components.Messengers
{
    public abstract class ShowBrosingPathDialogMessenger : Messenger<ShowBrowsingPathDialogMessageArgs>
    {
        public override void SendI(ShowBrowsingPathDialogMessageArgs args)
        {
            switch (args.PathType)
            {
                case PathType.File:
                    switch (args.BrowsingType)
                    {
                        case BrowsingType.Open:
                            SendToOpenFilePathDialog(args);
                            break;
                        default:
                            SendToSaveFilePathDialog(args);
                            break;
                    }
                    break;
                default:
                    switch (args.BrowsingType)
                    {
                        case BrowsingType.Open:
                            SendToOpenDirectoryPathDialog(args);
                            break;
                        default:
                            SendToSaveDirectoryPathDialog(args);
                            break;
                    }
                    break;

            }
        }
        public abstract void SendToSaveFilePathDialog(ShowBrowsingPathDialogMessageArgs args);
        public abstract void SendToOpenFilePathDialog(ShowBrowsingPathDialogMessageArgs args);
        public abstract void SendToSaveDirectoryPathDialog(ShowBrowsingPathDialogMessageArgs args);
        public abstract void SendToOpenDirectoryPathDialog(ShowBrowsingPathDialogMessageArgs args);
    }
}
