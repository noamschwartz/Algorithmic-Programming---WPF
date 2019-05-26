using System.Windows;
using System.Windows.Controls;
using FlightSimulator.ViewModels;
using FlightSimulator.Views.Windows;

namespace FlightSimulator.Views
{
    /// <summary>
    /// This is the connect and settings view class.
    /// 
    /// </summary>
    public partial class ConnectAndSettings : UserControl
    {
        private ConnectSettingsViewModels cs;
        /// <summary>
        /// This is the connect and settings constructor.
        /// It creates an instance of connect settings view model.
        /// </summary>
        public ConnectAndSettings()
        {
            InitializeComponent();
            cs = new ConnectSettingsViewModels();
            this.DataContext = cs;

        }
        /// <summary>
        /// This is the settings button code behind.
        /// </summary>
        /// <param name="server"> is the server</param>
        /// <param name="eventArgs"> is the event args clicked</param>
        protected void Settings_button(object server, RoutedEventArgs eventArgs)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
            
        }
    }
}
