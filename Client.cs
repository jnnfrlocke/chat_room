﻿using System;
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
        TcpClient clientSocket;
        NetworkStream stream;
        //int userID;
        //login

        public Client(string IP, int port)
        {
            clientSocket = new TcpClient();
            clientSocket.Connect(IPAddress.Parse("127.0.0.1"), port);
            stream = clientSocket.GetStream();
            //StayConnected();
            VerifyConnection();
        }

        //send notification to server, server sends notification to users

        //public void 

            private void VerifyConnection()
        {
            byte[] connectionMessage = new byte[256];
            stream.Read(connectionMessage, 0, connectionMessage.Length);
            UI.DisplayMessage(Encoding.ASCII.GetString(connectionMessage));
            SendUserIDAnswer();
        }

        //private void StayConnected()
        //{
        //    //string usrInput = stream.Read(input, 0, input.Length).ToString();
        //    while (true)
        //    {
        //        string inputCommand = UI.GetInput().ToLower();
        //        if (inputCommand == "exit" || inputCommand == "x")
        //        {
        //            break;
        //        }
        //    }
        //}
        private void SendUserIDAnswer()
        {
            byte[] userNameRequest = new byte[256];
            stream.Read(userNameRequest, 0, userNameRequest.Length);
            UI.DisplayMessage(Encoding.ASCII.GetString(userNameRequest));
            string newUser = UI.GetInput();
            byte[] newUsr = Encoding.ASCII.GetBytes(newUser);
            stream.Write(newUsr, 0, newUsr.Length);
        }

        public void Send()
        {
            string messageString = UI.GetInput();
            byte[] message = Encoding.ASCII.GetBytes(messageString);
            stream.Write(message, 0, message.Length);
        }

        public void Recieve()
        {
            byte[] recievedMessage = new byte[256];
            stream.Read(recievedMessage, 0, recievedMessage.Length);
            UI.DisplayMessage(Encoding.ASCII.GetString(recievedMessage));
        }

    }
}
