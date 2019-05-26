using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Server;

namespace FlightSimulator.ViewModels
{
    /// <summary>
    /// This is the flight board viewmodel class.
    /// </summary>
    public class FlightBoardViewModel : BaseNotify
    {
        
        private static volatile FlightBoardViewModel instance;
/// <summary>
/// create this class as a singleton class.
/// </summary>
/// <returns>an instance of flight board viewmodel.</returns>
        public static FlightBoardViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new FlightBoardViewModel();
            }

            return instance;
        }
        
        private double lon;
        /// <summary>
        /// getter and setter for lon/
        /// </summary>
        public double Lon
        {
            get => lon;
            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        private double lat;
/// <summary>
/// getter ans setter for the lat.
/// </summary>
        public double Lat
        {
            get => lat;
            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
        }
    }
}
 