using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    /// <summary>
    /// This is the base notify class
    /// </summary>
    public abstract class BaseNotify : INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;
/// <summary>
/// the base notify constructor. it controls when a property has been changed.
/// </summary>
/// <param name="propName"></param>
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

}
