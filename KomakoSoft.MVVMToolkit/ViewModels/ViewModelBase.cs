using KomakoSoft.MVVMToolkit.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KomakoSoft.MVVMToolkit.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public TheMessenger TheMessanger { get; set; } = new();
        private readonly Dictionary<string, ICommand> _commands = new();
        private readonly Dictionary<string, object> _relations = new();

        public event PropertyChangedEventHandler PropertyChanged;
        public ICollection<string> PropertyNames => _relations.Keys;
        public object GetValue(object defaultValue = null, [CallerMemberName] string propertyName = "")
        {
            return _relations.TryGetValue(propertyName, out var value) ? value : defaultValue;
        }
        public void SetValue(object value, [CallerMemberName] string propertyName = "")
        {
            if (_relations.TryAdd(propertyName, value) is false)
            {
                _relations[propertyName] = value;
            }
        }
        public ICommand GetCommand(Action action, [CallerMemberName] string propertyName = "")
        {
            return GetCommand(() => new ActionCommand() { Action = action }, propertyName);
        }
        public ICommand GetCommand(Func<ICommand> getCommand, [CallerMemberName] string propertyName = "")
        {

            if (_commands.ContainsKey(propertyName) is false)
            {
                _commands.Add(propertyName, getCommand.Invoke());
            }
            return _commands[propertyName];
        }
        public void Pause()
        {
            isPause = true;
        }
        public void Restart()
        {
            isPause = false;
            foreach (string propertyName in PropertyNames)
            {
                OnPropertyChanged(propertyName);
            }
        }
        private bool isPause = false;
        public virtual void OnPropertyChanged(string propertyName)
        {
            if (isPause is true)
            {
                return;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
