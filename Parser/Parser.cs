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

namespace Parser
{
    class Parser
    {
        MT940 mt940;
        JSON json;
        ICollection<CustomerStatementMessage> parsed = null;
        public void Parser(MT940 mt940)
        {
            this.mt940 = mt940;
            var start = new Raptorious.SharpMt940Lib.Mt940Format.Separator("STARTUMSE");
            var end = new Raptorious.SharpMt940Lib.Mt940Format.Separator("-");
            var genericFomat = new Raptorious.SharpMt940Lib.Mt940Format.GenericFormat(start, end);
        }

        public bool parseMT940_TO_JSON()
        {
            try {
                this.parsed = Mt940Parser.Parse(genericFomat, this.mt940.getMT940, CultureInfo.CurrentCulture);
            }
            catch
            {
                return false;
            }

            if(Raptorious.SharpMt940Lib.Mt940Parser.valid) {
                this.json = JsonSerializer.Serialize(parsed);
                return true;
            } 
            
            return false;
        }

        public JSON getJSON() 
        {
            return this.json;
        }
    }   
}