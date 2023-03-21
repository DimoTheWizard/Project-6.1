using api;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sports_Accounting
{
    public class XmlAPI
    {
        JsonAPI jsonAPI= new JsonAPI();


        public XmlAPI()
        {
        }

        public async Task<List<XDocument>> Get(BsonDocument criteria)
        {
            var BsonDoc = jsonAPI.Get(criteria);
            return null;
        }

        public async Task<List<XDocument>> GetAll()
        {
            var BsonDoc = jsonAPI.GetAll();
            return null;
        }

        public XDocument XMLConverter(BsonDocument BsonDoc) 
        {
            return null;
        }
    }
}
