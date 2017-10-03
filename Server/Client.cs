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


namespace Server
{
    public class Client
    {
        NetworkStream stream;
        TcpClient client;
        public string UserId;
        public int userID;
        
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
 
                string newUserName = $"{userToAdd} Your user ID is {newID}. Keep this handy to login again. \nPress enter to continue.";
                Send(newUserName);
                return newUsr;
            }
            else if (newUsr == "no" || newUsr == "n")
            {
                string askUserId = "Please enter your user ID.";
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
        

        //    public void newUserInChatRoom()
        //{
        //    TODO: alert the chat room about new user
        //}

        public Dictionary<int, string> dictionary = new Dictionary<int, string>();
        int newID;

        public int AddUserToDictionary(string userName)
        {
            dictionary.Add(CreateUserID(), userName);
            SaveUserToFile();
            // save to file
            return newID;
        }

        public void SaveUserToFile()
        {
            //StringBuilder userInfo = new StringBuilder();
            //foreach (KeyValuePair<int, string>)
            File.AppendAllLines(@"C:\Users\jnnfr\Documents\Visual Studio 2015\Projects\ChatRoom\Server\Users.txt", dictionary.Select(kvp => string.Format("{0};{1}", kvp.Key, kvp.Value)));
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
