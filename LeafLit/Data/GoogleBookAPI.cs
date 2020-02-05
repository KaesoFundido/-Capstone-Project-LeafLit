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
                var response = await client.GetAsync(queryString);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "QueryFail";
                }
                //var jsonResponse = await client.GetStringAsync(queryString);
                //return jsonResponse;
            });
            retrieveVolumes.Wait();
            if(retrieveVolumes.Result == "QueryFail")
            {
                return new Volumes();
            }
            else
            {
                volOut = JsonConvert.DeserializeObject<Volumes>(retrieveVolumes.Result);
                foreach (Volume vol in volOut.items)
                {
                    vol.selected = false;
                }
                return volOut;
            }
        }

    }
}
