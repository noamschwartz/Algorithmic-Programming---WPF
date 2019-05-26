using System;
using System.Diagnostics.Tracing;
using System.Net.Sockets;
using System.Text;

namespace FlightSimulator.Model.Server
{
    /// <summary>
    /// this is the commands class. is writes to the server.
    /// </summary>
    public class Commands
    {
     
        public TcpClient client { get; set; }
        private int port;
        private string ip;
/// <summary>
/// getter and setter for ip
/// </summary>
        public string Ip 
        {
            get => ip;
            set => ip = value;
        }
/// <summary>
/// getter and setter for the port.
/// </summary>
        public int Port
        {
            get => port;
            set => port = value;
        }
/// <summary>
/// create the class as a singleton class.
/// </summary>
        private static volatile Commands instance;
        private Commands(){}
/// <summary>
/// get instance function for the singleton class.
/// </summary>
/// <returns></returns>
        public static Commands getInstance()
        {
            if (instance == null)
            {
                instance = new Commands();
            }

            return instance;
        }
        

        public string CreateUpdatedMessage(string message)
        {
            if ((message[message.Length - 2] == '\r') && (message[message.Length - 1] == '\n'))
            {
                return message;
            }
            if (message[message.Length - 1] == '\n')
            {
                message = message.Remove(message.Length - 1);
            }
            message += "\r\n";
            return message;
        }
        /// <summary>
        /// connect to the server.
        /// </summary>
        public void connect() {
            //---create a TCPClient object at the IP and port no.---
            client = new TcpClient(ip, port);
        }
        /// <summary>
        /// write to the server.
        /// </summary>
        /// <param name="message"></param>
        public void write(string message) {
            NetworkStream nwStream = client.GetStream();
            message = CreateUpdatedMessage(message);
      
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(message);
            //---send the text---
            Console.WriteLine("Sending : " + message);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
      
            //---read back the text---
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            Console.ReadLine();
           
        }
    }
}