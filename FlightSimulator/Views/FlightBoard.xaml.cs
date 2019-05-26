using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class FlightBoard : UserControl
    {
        ObservableDataSource<Point> planeLocations = null;
        private FlightBoardViewModel fbvm;
        /// <summary>
        /// This is the flightboard view constructor.
        /// </summary>
        public FlightBoard()
        {
            InitializeComponent();
            fbvm = FlightBoardViewModel.GetInstance();
            this.DataContext = fbvm;
        }
/// <summary>
/// This is the usercontrol method. It draws the line on the flightboard.
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            planeLocations = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);
            plotter.AddLineGraph(planeLocations, 2, "Route");
            fbvm.PropertyChanged += Vm_PropertyChanged;
        }
/// <summary>
/// this is the view model property changed method. is creates a new point when the lon and lat is changed.
/// </summary>
/// <param name="sender"> is the sender</param>
/// <param name="e">is the event args </param>
        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("Lat") || e.PropertyName.Equals("Lon"))
            {
                Point p1 = new Point(fbvm.Lat,fbvm.Lon);     
                if (p1.X !=0 && p1.Y != 0)
                {
                    planeLocations.AppendAsync(Dispatcher, p1);
                }
            }
        }
    }

}

