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
        public void GetUser()
        {
            Console.WriteLine("Are you a new user?");
            string newUser = UI.GetInput().ToLower();
            if (newUser == "yes" || newUser == "y")
            {
                Console.WriteLine("Please type a user name.");
                byte[] userName = Encoding.ASCII.GetBytes(UI.GetInput()); // TODO: then assign user id on server
                stream.Write(userName, 0, userName.Count()); //send/save to dictionary on server
                // TODO: get userID from server
                Console.WriteLine($"Your user ID is {userID}. Keep this handy to login again. \nPress enter to continue.");
                Console.ReadLine();
            }
            else if (newUser == "no" || newUser == "n")
            {
                Console.WriteLine("Please enter your user ID.");

            }
                        
        }
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
