//using MongoDB.Driver;
//using MongoDB.Bson;
//using System.IO;
//using System;
//using System.Collections;
//using api;
//using Parser;

//namespace SportsAccounting
//{
//    class sportsAccounting
//    {
//        public static void Main(string[] args)
//        {
//            /*API api = new API();

//            string[] arr = { @"C:\Users\dimit\source\repos\APIlite\samplemt940.txt" };

//            api.postToDB(arr);

//            var read = api.readDB();

//            for (int i = 0; i < read.Count; i++)
//            {
//                Console.WriteLine(read[i]);
//            }*/

//            MT940 mt940 = new MT940(@"C:\Users\dimit\Source\Repos\Project-6.1\samplemt940.txt");
//            ParserAPI parser = new ParserAPI(mt940);
//            Console.WriteLine(parser.parseMT940_TO_JSON());
//            Console.WriteLine(parser.getJSON());
//            Console.ReadKey();
//        }
//    }

//}
