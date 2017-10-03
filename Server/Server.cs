using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Server
{
    class Server
    {
        Client client = new Client(); 
        TcpListener server;
        NetworkStream stream;

        public Server()
        {
            int port = 9999;
            server = new TcpListener(IPAddress.Any, port);
            server.Start();

        }

        public void Run()
        {
            AcceptClient();
            client.GetUser();
            //string message = client.ReceiveMessage(); //Server - Client, get message
            
            //Respond(message);
        }

        public void AcceptClient()
        {
            TcpClient clientSocket = default(TcpClient); 
            clientSocket = server.AcceptTcpClient();
            VerifyConnection(clientSocket);
            //KeepConnectionOpen();
            //while (true)
            //{
            //    clientSocket = server.AcceptTcpClient();
            //    byte[] input = new byte[256];
            //    //string usrInput = stream.Read(input, 0, input.Length).ToString();
            //    string inputCommand = Encoding.ASCII.GetString(input);
            //    if (inputCommand.Equals("exit"))
            //    {
            //        break;
            //    }
            //}
        }

        //public string GetUser()
        //{
        //    string askIfNewUser = "Are you a new user?";
        //    byte[] newUserQuestion = Encoding.ASCII.GetBytes(askIfNewUser);
        //    stream.Write(newUserQuestion, 0, newUserQuestion.Length);

        //    byte[] newUser = new byte[256];
        //    stream.Read(newUser, 0, newUser.Length);
        //    string newUsr = Encoding.ASCII.GetString(newUser);
        //    //string newUser = Console.ReadLine().ToLower();
        //    if (newUsr == "yes" || newUsr == "y")
        //    {
        //        byte[] userName = new byte[256];
        //        stream.Write(userName, 0, userName.Count());
        //        byte[] usrName = new byte[256];
        //        stream.Read(usrName, 0, usrName.Length);
        //        //string usrName = Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(usrName)); // TODO: then assign user id on server
        //        stream.Write(userName, 0, userName.Count()); //send/save to dictionary on server
        //        // TODO: get userID from server
        //        Console.WriteLine($"Your user ID is 01. Keep this handy to login again. \nPress enter to continue.");
        //        Console.ReadLine();
        //        return newUsr;
        //    }
        //    else if (newUsr == "no" || newUsr == "n")
        //    {
        //        Console.WriteLine("Please enter your user ID.");
        //        byte[] currentUser = Encoding.ASCII.GetBytes(Console.ReadLine());
        //        // TODO: find user in dictionary
        //        //if (current user is in dictionary){
        //        // Console.WriteLine("Enter a message to begin chatting.");
        //        //}
        //        return "userName";
        //    }
        //    return " ";
        //}

            //public void KeepConnectionOpen()
            //{
            //    client.GetUser();
            //    while (true)
            //    {
            //        byte[] input = new byte[256];
            //        //string usrInput = stream.Read(input, 0, input.Length).ToString();
            //        string inputCommand = Encoding.ASCII.GetString(input);
            //        if (inputCommand.Equals("exit"))
            //        {
            //            break;
            //        }

            //        //byte[] buffSend = Encoding.ASCII.GetBytes(inputCommand);

            //        //client.Send(inputCommand);

            //        //byte[] buffReceived = new byte[256];
            //        //int nRecv = client.ReceiveMessage(buffReceived);

            //        //Console.WriteLine($"Data received: {Encoding.ASCII.GetString(buffReceived, 0, nRecv)}");

            //    }
            //}

            public void VerifyConnection(TcpClient clientSocket)
        {
            string connectionMessage = "Connected\n";
            byte[] connectionMsg = Encoding.ASCII.GetBytes(connectionMessage);
            //NetworkStream stream;
            stream = clientSocket.GetStream();
            stream.Write(connectionMsg, 0, connectionMsg.Length);
            //Netw/*orkStream */stream = clientSocket.GetStream();
            client.NewClient(stream, clientSocket);
            //string user = GetUser();
            //KeepConnectionOpen();
        }

        public void Respond(string newMessage)
        {
            client.Send(newMessage); //maybe Client - Client??
        }

    }
}
