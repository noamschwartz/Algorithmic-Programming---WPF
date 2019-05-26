using System.Threading;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using FlightSimulator.Model;
using FlightSimulator.Model.Server;

namespace FlightSimulator.ViewModels
{
    /// <summary>
    /// this is the connect settings viewmodel class.
    /// </summary>
    public class ConnectSettingsViewModels : BaseNotify
    {
        private ICommand clickComand;
/// <summary>
/// getter and setter for click command
/// </summary>
        public ICommand ClickCommand
        {
            get
            {
                return clickComand ?? (clickComand = new CommandHandler(() => OnClick()));
            }
        }
/// <summary>
/// This method contains a thread of the connect button functioning.
/// </summary>
        private void OnClick()
        {
            Thread t = new Thread(TOnClick);
            t.Start();
        }
/// <summary>
/// This is the functioning of the connect button when is clicked.
/// </summary>
        private void TOnClick()
        {
            string ip = Properties.Settings.Default.FlightServerIP;
            int port = Properties.Settings.Default.FlightInfoPort;
            int commandPort = Properties.Settings.Default.FlightCommandPort;
            //get instance of info class.
            Info info = Info.GetInstance();
            info.Ip = ip;
            info.Port = port;
            info.StartServer();
            //control thread of listening.
            Thread t = new Thread(info.StartListening);
            t.Start();
            Commands cmnds = Commands.getInstance();
            cmnds.Ip = ip;
            cmnds.Port = commandPort;
            cmnds.connect();
        }
        private ICommand disconnect;
/// <summary>
/// getter and setter of the disconnect button.
/// </summary>
        public ICommand Disconnect
        {
            get
            {
                return disconnect ?? (disconnect = new CommandHandler(() => dis()));
            }
        }
/// <summary>
/// this disconnects the program elegantly.
/// </summary>
        private void dis()
        {
            //get the info class instance.
            Info info = Info.GetInstance();
            //close socket and server.
            info.clientSocket.Close();
            info.serverSocket.Server.Close();
            Commands commands = Commands.getInstance();
            //close client port.
            commands.client.Close();
        }
    }
}