using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text.Json;


namespace MT940Parser
{
    class Program
    {
        //ADD THE FILEPATH MANUALLY FOR NOW FOR TESTING PURPOSES
        const string FILENAME = @"MT940_FILEPATH";
        static void Main(string[] args)
        {
            //RAW MT940 OBJECT
            MT940 mt940 = new MT940(FILENAME);
            
            //JSON OBJECT
            var output = "";
            if(mt940.valid) {
            output = JsonSerializer.Serialize(mt940);
            } else {output = "invalid.";}
            // string output = JsonConvert.SerializeObject(mt940);

            //TEST
            Console.WriteLine(output);

        }
    }
    public class MT940
    {
        const string TAG_PATTERN = @"^:(?'tag'[^:]+):(?'value'.*)";

        const int requiredFields = 5;

        public string transactionReferenceNumber { get; set; }  // 20 *
                                                                // 21
        public string accountIdentification { get; set; }               // 25 *
        public string messageIndexTotal { get; set; }           // 28C *
        public Currency openingBalance { get; set; }            // 60a * 
        public string firstTransaction { get; set; }            // 61
        public string secondTransaction { get; set; }           // 61    
                                                                 // 86                
        public Currency closingBalance { get; set; }            // 62a *
                                                                //64
                                                                // 65                
                                                                // 86
        public Boolean valid;

        public MT940(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            string line = "";
            int transactionCount = 0;
            int checkCount = 0;
            Boolean error = false;
            this.valid = false;

            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith(":"))
                {
                    Match match = Regex.Match(line, TAG_PATTERN);
                    string tag = match.Groups["tag"].Value;
                    string value = match.Groups["value"].Value;

                    switch (tag)
                    {
                        case "20":
                            transactionReferenceNumber = value;
                            checkCount++;
                            // if(transactionReferenceNumber.Length != 16){error = true;} 
                            break;

                        case "25":
                            accountIdentification = value;
                            checkCount++;
                            // if(accountIdentification.Length != 35){error = true;}
                            break;

                        case "28C":
                            messageIndexTotal = value;
                            checkCount++;
                            break;

                        case "60F":
                            openingBalance = new Currency(value);
                            checkCount++;
                            break;
                        case "61":
                            if (++transactionCount == 1)
                            {
                                firstTransaction = value;
                            }
                            else
                            {
                                secondTransaction = value;
                            }
                            break;

                        case "62F":
                            checkCount++;
                            closingBalance = new Currency(value);
                            break;
                        default:
                            break;
                    }
                }
            }

            if(checkCount == this.requiredFields && !error) {this.valid = true;}
        }

    }
    public class Currency
    {
        const string BALANCE_PATTERN = @"^(?'credit_debit'.)(?'date'.{6})(?'country_code'.{3})(?'amount'.*)";
        static CultureInfo culture = CultureInfo.GetCultureInfoByIetfLanguageTag("da");

        public DateTime date { get; set; }
        public string currencyCode { get; set; }
        public decimal amount { get; set; }

        public Currency(string input)
        {
            Match match = Regex.Match(input, BALANCE_PATTERN);

            string credit_debit = match.Groups["credit_debit"].Value;

            string dateStr = match.Groups["date"].Value;
            date = DateTime.ParseExact(dateStr, "yyMMdd", CultureInfo.InvariantCulture);

            currencyCode = match.Groups["country_code"].Value;

            string amountStr = match.Groups["amount"].Value;
            amount = decimal.Parse(amountStr, culture);
            amount *= credit_debit == "D" ? -1 : 1;
        }
    }
}