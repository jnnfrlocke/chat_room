using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using ChatRoom;

namespace Server
{
    public class Client
    {
        NetworkStream stream;
        TcpClient client;
        public string UserId;
        public int userID;

        //public void SendMesage(byte[] message)
        //{
        //    stream.Write(message, 0, message.Length);
        //}
        //public void GetInput()
        //{
        //    byte[] receivedInput = new byte[256];
        //    stream.Read(receivedInput, 0, receivedInput.Length);
        //    string receivedString = Encoding.ASCII.GetString(receivedInput).TrimEnd('\0');
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
            string receivedString = Encoding.ASCII.GetString(received).TrimEnd('0');
            //Console.WriteLine(receivedString);
            return receivedString;
        }

        public void AddNewClient(NetworkStream Stream, TcpClient Client)
        {
            stream = Stream;
            client = Client;
            UserId = "495933b6-1762-47a1-b655-483510072e73";
        }

        public string GetUser() 
        {
            string askIfNewUser = "Are you a new user?";
            Send(askIfNewUser);
            
            byte[] newUser = new byte[256];
            stream.Read(newUser, 0, newUser.Length);

            string newUsr = Encoding.ASCII.GetString(newUser).ToLower().TrimEnd('\0');
            if (newUsr == "yes" || newUsr == "y")
            {
                string askForUserName = "Please choose and enter your user name.";
                Send(askForUserName);

                byte[] usrName = new byte[256];
                stream.Read(usrName, 0, usrName.Length);
                string userToAdd = Encoding.ASCII.GetString(usrName).TrimEnd('\0');
                AddUserToDictionary(userToAdd);
 
                // TODO: get userID from server
                string newUserName = $"Your user ID is {newID}. Keep this handy to login again. \nPress enter to continue.";//stream
                //byte[] newUsrName = Encoding.ASCII.GetBytes(newUserName);
                Send(newUserName);
                //Console.ReadLine();//stream
                return newUsr;
            }
            else if (newUsr == "no" || newUsr == "n")
            {
                string askUserId = "Please enter your user ID.";
                //byte[] askForUserID = Encoding.ASCII.GetBytes(askUserId);
                Send(askUserId);
                byte[] currentUser = new byte[256];
                stream.Read(currentUser, 0, currentUser.Length);
                string currentUsrID = Encoding.ASCII.GetString(currentUser).TrimEnd('0');
                // TODO: find user in dictionary

                //if (current user is in dictionary){
                // stream.write("Enter a message to begin chatting.");
                //}
                return currentUsrID;
                //begin chat
                //after a message is sent write it to a queue
                //in queue method, write queue to file
            }
            return "nothing";
         
        }

        //public void Chat()
        //{
        //    string message = 
        //    Send();
        //}

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

        public Dictionary<int, string> dictionary = new Dictionary<int, string>();
        int newID;

        public int AddUserToDictionary(string userName)
        {
            dictionary.Add(CreateUserID(), userName);
            // save to file
            return newID;
        }

        public void SaveUserToFile(int newId, string userName)
        {
            //StringBuilder userInfo = new StringBuilder();
            //foreach (KeyValuePair<int, string>)
            File.WriteAllLines(@"C:\Users\jnnfr\Documents\Visual Studio 2015\Projects\ChatRoom\Server\Users.txt", dictionary.Select(kvp => string.Format(kvp.Key.ToString(), kvp.Value)));
        }

        private int CreateUserID()
        {
            int dictionaryLength = dictionary.Count();
            if (dictionary.ContainsKey(dictionaryLength))
            {
                newID = dictionaryLength++;
                return newID;
            }
            return dictionaryLength;
        }
    



    


        

    }
}
