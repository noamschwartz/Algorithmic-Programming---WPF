using System.IO;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;
using FlightSimulator.Model;
using FlightSimulator.Model.Server;

namespace FlightSimulator.ViewModels
{
    /// <summary>
    /// This is the autopilot class.
    /// </summary>
    public class AutoPilot : BaseNotify
    {
        private string commandBox;
        private ICommand clearCommand;
        private ICommand clickCommand;
        private Brush changeBackground;
        /**
         * constructor
         * change the background to red
         */
        public AutoPilot()
        {
            ChangeBackground = (Brush) (new BrushConverter()).ConvertFrom("#FFFFBBBB");
        }
        
        /**
         * the string of the command box.
         */
        public string CommandBox
        {
            get { return commandBox; }
            set
            {
                commandBox = value;
                NotifyPropertyChanged("commandBox");
            }
        }
        /**
         * change the member of the background,
         * use : binding of Background in FlightBoardView.
         */
        public Brush ChangeBackground
        {
            get => changeBackground;
            set
            {
                changeBackground = value;
                NotifyPropertyChanged("ChangeBackground");
            }
        }
        /**
         * command of the clear.
         * start the clear() function.
         */
        public ICommand ClearCommand
        {
            get
            {
                
                return clearCommand ?? (clearCommand = new CommandHandler(() => Clear()));
            }
        }
        /**
         * clear the text box. (turn the string to "".)
         * and change the background to pink
         */
        public void Clear()
        {
            CommandBox = "";
            ChangeBackground = (Brush) (new BrushConverter()).ConvertFrom("#FFFFBBBB");
        }
        
        /**
         * hand the click command.
         * start the OnClick function when the user click ok.
         */
        public ICommand ClickCommand
        {
            get
            {
                return clickCommand ?? (clickCommand = new CommandHandler(() => OnClick()));
            }
        }
        /**
         * takes the text in auto pilot , connect to the model and execute it.
         */
        private void OnClick()
        {
            string ip = Properties.Settings.Default.FlightServerIP;
            int commandPort = Properties.Settings.Default.FlightCommandPort;
            //get commands instance
            Commands commands = Commands.getInstance();
            commands.Ip = ip;
            commands.Port = commandPort;
            
            var reader = new StringReader(CommandBox);
            string line = null;
            int numOfLines = CommandBox.Split('\n').Length;
            int currentLineNumber = 0;
            line = reader.ReadLine();
            //go through all of the lines in the textbox and execute them.
            while ((line != null) && (currentLineNumber < numOfLines))
            {
                {
                    currentLineNumber += 1;
                    commands.connect();
                    commands.write(line);
                    Thread.Sleep(2000);
                    line = reader.ReadLine();

                }
            }
            //change the background of the auto pilot to white
            ChangeBackground = (Brush) (new BrushConverter()).ConvertFrom("White");
        }

    }
}