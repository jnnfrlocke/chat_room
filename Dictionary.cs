﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    class Dictionary
    {
        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        int newID;

        public int AddUserToDictionary(string userName)
        {
            dictionary.Add(CreateUserID(), userName);
            return newID;
        }

        private int CreateUserID()
        {
            int dictionaryLength = dictionary.Count();
            string dictLength = dictionaryLength.ToString();
            if (dictionary.ContainsValue(dictLength))
            {
                newID = dictionaryLength ++;
                return newID;
            }
            return dictionaryLength;
        }
    }
}
