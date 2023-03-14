using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using Raptorious.SharpMt940Lib;

namespace Parser
{
    class ParserAPI
   {
       MT940 mt940;
       JSON json;
       public ParserAPI(MT940 mt940)
       {
           this.mt940 = mt940;
       }

       public bool parseMT940_TO_JSON()
       {
           object output = "";
           var start = new Raptorious.SharpMt940Lib.Mt940Format.Separator("STARTUMSE");
           var end = new Raptorious.SharpMt940Lib.Mt940Format.Separator("-");
           var genericFomat = new Raptorious.SharpMt940Lib.Mt940Format.GenericFormat(start, end);
           ICollection<CustomerStatementMessage> parsed = null;
           try
           {
               parsed = Mt940Parser.Parse(genericFomat, this.mt940.getMT940(), CultureInfo.CurrentCulture);
           }
           catch
           {
               return false;
           }

           if(Mt940Parser.valid) {
               output = JsonSerializer.Serialize(parsed);
               JSON json = new JSON(output);
               this.json = json;
               return true;
           } 
            
           return false;
       }

       public string getJSON() 
       {
           return this.json.getJson();
       }
   }   
}
