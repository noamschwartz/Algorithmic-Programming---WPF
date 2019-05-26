using System.Windows.Controls;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Views
{
    public partial class Manual : UserControl
    {
        private Sliders sl;

        public Manual()
        {
            InitializeComponent();
            sl = new Sliders();
            DataContext = sl;
        }
    }
}