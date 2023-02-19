using MongoDB.Driver;
using MongoDB.Bson;
using System.IO;
using System;
using System.Collections;
using api;

namespace SportsAccounting
{
    class sportsAccounting
    {
        public static void Main(string[] args)
        {
            API api = new API();

            string[] arr = { @"C:\Users\dimit\source\repos\APIlite\samplemt940.txt" };

            api.postToDB(arr);

            var read = api.readDB();

            for (int i = 0; i < read.Count; i++)
            {
                Console.WriteLine(read[i]);
            }
        }
    }
        
}