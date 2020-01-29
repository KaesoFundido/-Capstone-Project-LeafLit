using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LeafLit.Data
{
    public class GoogleBookAPI
    {
        public HttpClient Initialize()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.googleapis.com/books/v1/volumes?q=");
            return client;
        }
    }
}
