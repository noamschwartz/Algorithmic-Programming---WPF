using System.Windows.Controls;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Views
{
    /// <summary>
    /// This is the AutoPilot view code behind class.
    /// </summary>
    public partial class Auto : UserControl
    {
        private AutoPilot ap;
        /// <summary>
        ///
        /// This is the class constructor.
        /// </summary>
        public Auto()
        {
            InitializeComponent();
            ap = new AutoPilot();
            this.DataContext = ap;
        }
    }
}
