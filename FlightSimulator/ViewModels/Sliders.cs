using System;
using System.Windows;
using System.Windows.Input;
using FlightSimulator.Model;
using FlightSimulator.Model.Server;

namespace FlightSimulator.ViewModels
{
    /// <summary>
    /// This is the Slider view model class.
    /// </summary>
    public class Sliders : BaseNotify
    
    {
        private double throttleValue;   
        /// <summary>
        /// getter and setter for throttle value.
        /// </summary>
        public double ThrottleValue
        {
            get  => this.throttleValue;
            set
            {
                    
                    this.throttleValue = value;
                    string IP = Properties.Settings.Default.FlightServerIP;
                    int commandPort = Properties.Settings.Default.FlightCommandPort;
                   
                    Commands cmd = Commands.getInstance();
                    cmd.Ip = IP;
                    cmd.Port = commandPort;
                    //cmd.connect();
                
                    string lineToWrite = "set controls/engines/current-engine/throttle " + throttleValue;
                    cmd.write(lineToWrite);
                  
          
               }
        }
        private double rudderValue;  
        /// <summary>
        /// getter and setter for rudder value.
        /// </summary>
        public double RudderValue
        {
            get  => this.rudderValue;
            set
            {
                    
                this.rudderValue = value;
                string IP = Properties.Settings.Default.FlightServerIP;
                int commandPort = Properties.Settings.Default.FlightCommandPort;
                Commands cmd = Commands.getInstance();
                cmd.Ip = IP;
                cmd.Port = commandPort;
                string lineToWrite = "set controls/flight/rudder " + rudderValue;
                cmd.write(lineToWrite);
              }
        }
    }

}