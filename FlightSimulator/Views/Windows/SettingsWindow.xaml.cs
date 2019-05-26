using System.Windows.Controls;
using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels.Windows;

namespace FlightSimulator.Views.Windows
{
    public partial class SettingsWindow
    {
        public SettingsWindow()
        {
            InitializeComponent();
            //we create a new model and we will work with this in the settings and connect
            ISettingsModel model = new ApplicationSettingsModel();
            this.DataContext = new SettingsWindowViewModel(model);
        }
    }
}
