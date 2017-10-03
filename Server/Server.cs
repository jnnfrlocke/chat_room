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

        public async void Run()
        {
            Task establishConnection = AcceptClient();
            await establishConnection;
            client.GetUser();
            //run main chat method
        }

        public Task AcceptClient() //this should go in a thread
        {
            TcpClient clientSocket = default(TcpClient); 
            clientSocket = server.AcceptTcpClient();
            VerifyConnection(clientSocket);
        }

        public void VerifyConnection(TcpClient clientSocket)
        {
            string connectionMessage = "Connected";
            byte[] connectionMsg = Encoding.ASCII.GetBytes(connectionMessage);
            stream = clientSocket.GetStream();
            stream.Write(connectionMsg, 0, connectionMsg.Length);
            client.AddNewClient(stream, clientSocket);
        }



        //public void Respond(string newMessage)
        //{
        //    client.Send(newMessage); //maybe Client - Client??
        //}


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

    }
}
