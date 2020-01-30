using LeafLit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LeafLit.Data
{
    public class GoogleBookAPI
    {
        private HttpClient client;
        public void Initialize()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://www.googleapis.com/books/v1/");
            //return client;
        }

        public Volumes GetVolumes(string queryString)
        {
            Volumes volOut = new Volumes();
            Task<string> retrieveVolumes = Task.Run<string>(async () =>
            {
               //HttpClient client = Initialize();
               var jsonResponse = await client.GetStringAsync(queryString);
               return jsonResponse;
            });
            retrieveVolumes.Wait();
            volOut = JsonConvert.DeserializeObject<Volumes>(retrieveVolumes.Result);
            return volOut;
        }

    }
}
