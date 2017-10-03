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
    public class Client
    {
        NetworkStream stream;
        TcpClient client;
        public string UserId;
        public int userID;

        public void NewClient(NetworkStream Stream, TcpClient Client)
        {
            stream = Stream;
            client = Client;
            UserId = "495933b6-1762-47a1-b655-483510072e73";
        }

        public string GetUser()
        {
            string askIfNewUser = "Are you a new user?";
            byte[] newUserQuestion = Encoding.ASCII.GetBytes(askIfNewUser);
            stream.Write(newUserQuestion, 0, newUserQuestion.Length);

            
            byte[] newUser = new byte[256];
            stream.Read(newUser, 0, newUser.Length);

            string newUsr = Encoding.ASCII.GetString(newUser).ToLower().TrimEnd('\0');
            //string newUser = Console.ReadLine().ToLower();
            if (newUsr == "yes" || newUsr == "y")
            {
                string askForUserName = "Please choose and enter your user name.";
                byte[] userName = Encoding.ASCII.GetBytes(askForUserName);
                stream.Write(userName, 0, userName.Count());

                byte[] usrName = new byte[256];
                stream.Read(usrName, 0, usrName.Count());
                //string usrName = Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(usrName)); // TODO: then assign user id on server
                stream.Write(userName, 0, userName.Count()); //send/save to dictionary on server
                // TODO: get userID from server
                Console.WriteLine($"Your user ID is {userID}. Keep this handy to login again. \nPress enter to continue.");
                Console.ReadLine();
                return newUsr;
            }
            else if (newUsr == "no" || newUsr == "n")
            {
                Console.WriteLine("Please enter your user ID.");
                byte[] currentUser = Encoding.ASCII.GetBytes(Console.ReadLine());
                // TODO: find user in dictionary
                //if (current user is in dictionary){
                // Console.WriteLine("Enter a message to begin chatting.");
                //}
                return "userName";
            }
            return "nothing";
        }

        //private int userID;
        //private string userName;
        // TODO: get username through network stream
        //TODO: dynamically create userID if new user

        //Dictionary<int, string> users = new Dictionary<int, string>(); //instantiate dictionary

        //public void AddUsers()
        //{
        //    users.Add(userID, userName); //Make this dynamic later
        //} 

        //    public void newUserInChatRoom()
        //{
        //    TODO: alert the chat room about new user
        //}

        public void Send(string newMessage)
        {
            byte[] message = Encoding.ASCII.GetBytes(newMessage);
            stream.Write(message, 0, message.Count());
        }
        public string ReceiveMessage()
        {
            byte[] received = new byte[256];
            stream.Read(received, 0, received.Length);
            string receivedString = Encoding.ASCII.GetString(received);
            Console.WriteLine(receivedString);
            return receivedString;
        }


        

    }
}
