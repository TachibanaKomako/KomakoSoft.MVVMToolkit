using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomakoSoft.MVVMToolkit.Views.ShowBrowsingPathDialogs.Components.Messengers
{
    public sealed class DefaultShowBrowsingPathDialogMessenger : ShowBrosingPathDialogMessenger
    {
        public override void SendToOpenDirectoryPathDialog(ShowBrowsingPathDialogMessageArgs args)
        {
            throw new NotImplementedException();
        }

        public override void SendToSaveDirectoryPathDialog(ShowBrowsingPathDialogMessageArgs args)
        {
            throw new NotImplementedException();
        }

        public override void SendToOpenFilePathDialog(ShowBrowsingPathDialogMessageArgs args)
        {
            ShowFileDialog(new OpenFileDialog(), args);
        }


        public override void SendToSaveFilePathDialog(ShowBrowsingPathDialogMessageArgs args)
        {
            ShowFileDialog(new SaveFileDialog(), args);
        }

        private void ShowFileDialog(FileDialog fileDialog, ShowBrowsingPathDialogMessageArgs args)
        {
            fileDialog.Filter = args.Filter;
            fileDialog.Title = args.Title;
            fileDialog.FileName = args.DefaultPath;
            switch (fileDialog.ShowDialog())
            {
                case true:
                    args.Callback?.Invoke((true, fileDialog.FileName));
                    break;
                default:
                    args.Callback?.Invoke((false, null));
                    break;
            }
        }
    }
}
