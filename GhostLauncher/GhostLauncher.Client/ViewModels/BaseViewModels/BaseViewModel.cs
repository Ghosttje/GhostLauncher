using System;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GhostLauncher.Core;

namespace GhostLauncher.Client.ViewModels.BaseViewModels
{
    public class BaseViewModel : NotifyPropertyChanged
    {
        #region Messaging

        protected void SubscribeForMessage<T>(object token, Action<T> action)
        {
            Messenger.Default.Register(this, token, action);
        }

        protected void PublishMessage<T>(object token, T message)
        {
            Messenger.Default.Send(message, token);
        }

        #endregion

        #region Backing Commands

        protected RelayCommand<T> GetCommand<T>(Action<T> action, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));

            object value;
            if (PropertyBackingDictionary.TryGetValue(propertyName, out value))
            {
                return (RelayCommand<T>)value;
            }
            var newRelayCommand = new RelayCommand<T>(action);
            PropertyBackingDictionary[propertyName] = newRelayCommand;
            return newRelayCommand;
        }

        protected RelayCommand<T> GetCommand<T>(Action<T> action, Func<T, bool> canExecute, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));

            object value;
            if (PropertyBackingDictionary.TryGetValue(propertyName, out value))
            {
                return (RelayCommand<T>)value;
            }
            var newRelayCommand = new RelayCommand<T>(action, canExecute);
            PropertyBackingDictionary[propertyName] = newRelayCommand;
            return newRelayCommand;
        }

        protected RelayCommand GetCommand(Action action, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));

            object value;
            if (PropertyBackingDictionary.TryGetValue(propertyName, out value))
            {
                return (RelayCommand)value;
            }
            var newRelayCommand = new RelayCommand(action);
            PropertyBackingDictionary[propertyName] = newRelayCommand;
            return newRelayCommand;
        }

        protected RelayCommand GetCommand(Action action, Func<bool> canExecute, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));

            object value;
            if (PropertyBackingDictionary.TryGetValue(propertyName, out value))
            {
                return (RelayCommand)value;
            }
            var newRelayCommand = new RelayCommand(action, canExecute);
            PropertyBackingDictionary[propertyName] = newRelayCommand;
            return newRelayCommand;
        }

        #endregion
    }
}
