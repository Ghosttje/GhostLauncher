using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using GhostLauncher.WPF.Core.Attributes;

namespace GhostLauncher.WPF.Core
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Backing Dictionary

        protected readonly Dictionary<string, object> PropertyBackingDictionary = new Dictionary<string, object>();

        protected T GetPropertyValue<T>([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));

            object value;
            if (PropertyBackingDictionary.TryGetValue(propertyName, out value))
            {
                return (T)value;
            }

            return default(T);
        }

        protected bool SetPropertyValue<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));
            var propertyChanged = !EqualityComparer<T>.Default.Equals(newValue, GetPropertyValue<T>(propertyName));


            PropertyBackingDictionary[propertyName] = newValue;
            if (propertyChanged)
                RaisePropertyChanged(propertyName);
            return propertyChanged;
        }

        #endregion Backing Dictionary

        #region Dependent Notifications

        private ILookup<string, string> _dependentLookup;

        private ILookup<string, string> DependentLookup
        {
            get
            {
                return _dependentLookup ?? (_dependentLookup = (from p in GetType().GetProperties()
                                                                let attrs = p.GetCustomAttributes(typeof(NotifiesOnAttribute), false)
                                                                from NotifiesOnAttribute a in attrs
                                                                select new { Independent = a.Name, Dependent = p.Name }).ToLookup(i => i.Independent, d => d.Dependent));
            }
        }

        #endregion Dependent Notifications

        #region INotifyPropertyChanged

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));

            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            foreach (var dependentPropertyName in DependentLookup[propertyName])
            {
                RaisePropertyChanged(dependentPropertyName);
            }
        }

        #endregion INotifyPropertyChanged
    }
}
