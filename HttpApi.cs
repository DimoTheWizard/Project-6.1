using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using api;
using MongoDB.Bson;
using SimpleHttp;

namespace Sports_Accounting
{
    internal class HttpApi
    {
        private HttpListener listener= new HttpListener(); 

        HttpListenerContext context ;

        HttpListenerRequest request;
        HttpListenerResponse response;

        public HttpApi()
        {
           StartConnection();
        }

        public async Task<List<string>> getValue()
        {
            JsonAPI jsonAPI = new JsonAPI();
            var xmlDocs = await jsonAPI.GetAll();

            List<string> stringValues = xmlDocs.Select(x => x.ToString()).ToList();
            return stringValues;
        }

        public void StartConnection()
        {
            //SimpleGet
            Route.Add("/json/transactions/", async (req, res, props) =>
            {
                JsonAPI jsonAPI = new JsonAPI();
                var xmlDocs = await jsonAPI.GetAll();
                List<string> stringValues = xmlDocs.Select(x => x.ToString()).ToList();

                res.ContentType = "application/json";
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(stringValues);

                byte[] buffer = Encoding.UTF8.GetBytes(json);
                res.ContentLength64 = buffer.Length;
                res.OutputStream.Write(buffer, 0, buffer.Length);
                res.OutputStream.Close();
            });

            //SimplePost
            Route.Add("/json/transactions/{id}", (req, res, props) =>
            {
                res.AsText($"You have requested  #{props["id"]}");
            }, "POST");



            HttpServer.ListenAsync(
                    8080,
                    CancellationToken.None,
                    Route.OnHttpRequestAsync
                );
        }
    }

}
