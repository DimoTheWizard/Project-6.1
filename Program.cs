using Amazon.Auth.AccessControlPolicy;
using api;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sports_Accounting
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            //This is needed to allow await functions to wait instead of causing errors,
            //Have to turn main into an async task aswell so that it functions properly
            Task.Run(async () => await MainAsync(args));



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        }
        static async Task MainAsync(string[] args)
        {
            XmlAPI xmlAPI = new XmlAPI();
            JsonAPI jsonAPI = new JsonAPI();

            var xmlDocs = xmlAPI.XMLConverter(await jsonAPI.GetAll());
        }
    }
}
