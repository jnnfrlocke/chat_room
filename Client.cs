using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatRoom
{
    class Client
    {
        //    TcpClient clientSocket;
        NetworkStream stream;
        int userID;
        //login
        
                        
        
        public void Send()
        {
            string messageString = UI.GetInput();
            byte[] message = Encoding.ASCII.GetBytes(messageString);
            stream.Write(message, 0, message.Count());
        }

        //public Client(string IP, int port)
        //{
        //    clientSocket = new TcpClient();
        //    clientSocket.Connect(IPAddress.Parse(IP), port);
        //    stream = clientSocket.GetStream();
        //}

        //send notification to server, server sends notification to users
    }
}
