using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text.Json;
using Raptorious.SharpMt940Lib;
//ADD NUGET PACKAGE SharpMt940Lib.Core 1.0.2

namespace MT940Parser
{
    class Parser
    {

        var jsonObject = null;
        //ADD THE FILEPATH MANUALLY FOR NOW FOR TESTING PURPOSES
        // const string FILENAME = @"/Users/DavidHlavacek/Documents/NHL_Stenden/Year2/Period3/IT2A/Project6.1/Project-6.1/parserTest/parserTest/MT940Sample.txt";
        public Parser(string filePath) {
            //RAW MT940 OBJECT
            var start = new Raptorious.SharpMt940Lib.Mt940Format.Separator("STARTUMSE");
            var end = new Raptorious.SharpMt940Lib.Mt940Format.Separator("-");
            var genericFomat = new Raptorious.SharpMt940Lib.Mt940Format.GenericFormat(start, end);
            ICollection<CustomerStatementMessage> parsed = null;
            try {
                parsed = Mt940Parser.Parse(genericFomat, filePath, CultureInfo.CurrentCulture);
            }
            catch
            {
                Console.WriteLine("Invalid.");
            }

            var output = "";
            if(Raptorious.SharpMt940Lib.Mt940Parser.valid) {
                this.jsonObject = JsonSerializer.Serialize(parsed);
            } else {    
                Console.WriteLine("Invalid.");
            }  
            //JSON OBJECT
            // var output = "";
            // if(mt940.Checker()) {
            //     output = JsonSerializer.Serialize(mt940);
            // } else {
            //     output = "invalid.";
            // }
            // string output = JsonConvert.SerializeObject(mt940);

            //TEST
        }

        public var getJson() {
            if(this.jsonObject != null) {return this.jsonObject;}
            return "Invalid.";
        }
    }   
}